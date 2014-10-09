using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Dapper;
using System.Data;

namespace REIQ.Access
{
    public class Suburb
    {
        public class StreetNames
        {
            private String _streetNameString;
            public String StreetName
            {
                get
                {
                    if (!String.IsNullOrEmpty(_streetNameString))
                        return _streetNameString.Trim();
                    else return String.Empty;
                }
                set { _streetNameString = value; }
            }
            public String StreetType { get; set; }
        }
       
        public static List<StreetNames> GetAllStreets()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<StreetNames>(
                    @"SELECT p.rdName AS StreetName, 
                    p.rdType AS StreetType
                    FROM tblProperty p WITH (NOLOCK)
                    group by p.rdName , 
                    p.rdType 
                    ORDER BY len(p.rdName) desc").ToList<StreetNames>();
            }
        }

        public static List<StreetNames> GetAllStreetsBySuburb(String suburb)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<StreetNames>(
                    @"SELECT p.rdName AS StreetName, 
                    p.rdType AS StreetType
                    FROM tblProperty p WITH (NOLOCK)
                    where p.suburb = @suburb
                    group by p.rdName , 
                    p.rdType",
                    new { suburb = suburb }).ToList<StreetNames>();
            }
        }

        public static List<string> GetAllSuburbs()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<String>("SELECT DISTINCT (p.suburb) FROM tblProperty p WITH (NOLOCK)").ToList<string>();
            }
        }

        public static List<REIQ.Entities.Suburb> GetSearchedSuburbs()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<REIQ.Entities.Suburb>("SELECT DISTINCT (name) FROM tblLogSuburbSearch WITH (NOLOCK) ORDER BY name").ToList();
            }
        }

        public class SuburbAutoCompleteResults
        {
            public List<Entities.Suburb> Suburbs {get; set; }
            public List<string> Regions {get; set; }
        }

        public static SuburbAutoCompleteResults ListMatching(string str)
        {
            var results = new SuburbAutoCompleteResults();

            results.Suburbs = new List<Entities.Suburb>();
            results.Regions = new List<string>();

            if (String.IsNullOrWhiteSpace(str))
                return results;

            using (var conn = Data.CreateConnection())
            {
                string qry = @"
SELECT TOP 100 sID, name, postcode, region FROM tblSuburb WHERE postcode LIKE @Str + '%' OR name LIKE @Str + '%'; -- matching suburbs
SELECT DISTINCT region FROM tblSuburb WHERE region LIKE @Str + '%'                                          -- matching regions";
                using (var multi = conn.QueryMultiple(qry, new { Str = str.Replace('-', ' ') }))
                {
                    results.Suburbs = multi.Read<Entities.Suburb>().ToList();
                    results.Regions = multi.Read<string>().ToList();
                }
                if (results.Suburbs.Count == 0 && results.Regions.Count == 0)
                {
                    qry = @"
SELECT TOP 100 sID, name, postcode, region FROM tblSuburb WHERE postcode LIKE @Str + '%' OR name LIKE @Str + '%'; -- matching suburbs
SELECT DISTINCT region FROM tblSuburb WHERE region LIKE @Str + '%'                                          -- matching regions";
                    using (var multi = conn.QueryMultiple(qry, new { Str = str }))
                    {
                        results.Suburbs = multi.Read<Entities.Suburb>().ToList();
                        results.Regions = multi.Read<string>().ToList();
                    }
                }
            }

            return results;
        }

        public static Entities.Suburb GetFromName(string suburb)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>(
                    @"
                    SELECT      *    
                    FROM        tblSuburb s 
                    WHERE name = @name;",
                    new { name = suburb }).FirstOrDefault();
            }
        }

        public static Entities.Suburb GetFromPropertyId(Int32 propertyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>(
                    @"
                    SELECT      s.*    
                    FROM        tblSuburb s 
                    INNER JOIN  tblProperty p on s.name = p.suburb
                    WHERE p.pid = @pid;",
                    new { pid = propertyId }).FirstOrDefault();
            }
        }

        public static List<Entities.Suburb> GetAllSuburbsByTop(int top)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>(
                    "SELECT TOP "+ top +@" tblSuburb.* FROM tblSuburb inner join tblsuburbchart  
                    on name=suburbname and  tblSuburb.postcode=tblsuburbchart.postcode  
                    WHERE country='AU' AND state ='QLD'          
                    and (isnull(descriptionlong,'') != '' or suburbid in (select suburbid from tblGraphEntry where isnull(amount,0)>0 and type is not null ))    
                    order by name ").ToList();
            }
        }

        public static Entities.Suburb Get(string suburb, int postcode)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>("SELECT * FROM tblSuburb WHERE name LIKE @Name AND postcode = @PostCode", new { Name = suburb, PostCode = postcode }).FirstOrDefault();
            }
        }

        public static List<int> ListIdsOfSuburbsByPostCode(int postcode)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<int>("SELECT CAST(SID as int) Id FROM tblSuburb WHERE postcode = @PC;", new { PC = postcode }).ToList();
            }
        }

        public static Entities.Suburb GetFromPostcode(int postcode)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>("SELECT CAST(SID as int) Id FROM tblSuburb WHERE postcode = @PC;", new { PC = postcode }).FirstOrDefault();
            }
        }

        public static IEnumerable<int> ListIdsOfSurroundingSuburbs(string suburb, int postcode)
        {
            using (var conn = Data.CreateConnection())
            {
                var data = conn.Query<Entities.SurroundingSuburb>(@"SELECT * FROM tblSuroundingSuburb WHERE suburb LIKE @Suburb AND  postcode = @PC;", 
                    new 
                    { 
                        Suburb = suburb, 
                        PC = postcode 
                    })
                    .FirstOrDefault();

                if(data == null)
                {
                    yield break;
                }

                Func<string, int, int> getSuburb =  delegate(string sub, int pc) 
                {
                    return conn.Query<int>("SELECT CAST(SID as int) Id FROM tblSuburb WHERE name LIKE @Name AND postcode = @PostCode", new { Name = sub, PostCode = pc }).FirstOrDefault();
                };

                yield return getSuburb(suburb, postcode);

                if(data.suburbs1 != null && data.postcode1.HasValue)
                    yield return getSuburb(data.suburbs1, data.postcode1.Value );

                if(data.suburbs2 != null && data.postcode2.HasValue)
                    yield return getSuburb(data.suburbs2, data.postcode2.Value );

                if(data.suburbs3 != null && data.postcode3.HasValue)
                    yield return getSuburb(data.suburbs3, data.postcode3.Value );

                if(data.suburbs4 != null && data.postcode4.HasValue)
                    yield return getSuburb(data.suburbs4, data.postcode4.Value );

                if(data.suburbs5 != null && data.postcode5.HasValue)
                    yield return getSuburb(data.suburbs5, data.postcode5.Value );

                if(data.suburbs6 != null && data.postcode6.HasValue)
                    yield return getSuburb(data.suburbs6, data.postcode6.Value );

                if(data.suburbs7 != null && data.postcode7.HasValue)
                    yield return getSuburb(data.suburbs7, data.postcode7.Value );

                if(data.suburbs8 != null && data.postcode8.HasValue)
                    yield return getSuburb(data.suburbs8, data.postcode8.Value );

                if(data.suburbs9 != null && data.postcode9.HasValue)
                    yield return getSuburb(data.suburbs9, data.postcode9.Value );

                if(data.suburbs10 != null && data.postcode10.HasValue)
                    yield return getSuburb(data.suburbs10, data.postcode10.Value );

                if(data.suburbs11 != null && data.postcode11.HasValue)
                    yield return getSuburb(data.suburbs11, data.postcode11.Value );
            }
        }

        public static List<int> ListIdsOfSuburbsByRegion(string region)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<int>("SELECT CAST(SID as int) Id FROM tblSuburb WHERE region LIKE @Region;", new { Region = region }).ToList();
            }
        }

        //Try to Determine current Suburb
        public static Entities.Suburb TryGetSuburbFromSearchString(String keyword)
        {
            REIQ.Entities.Suburb suburb = null;

            var match = Regex.Match(keyword, "(.*), (4\\d{3})"); // in format "Suburb Name, 4XXX"
            //Try get the current searched suburb
            if (match.Success)
            {
                var su = match.Groups[1].Value;
                var pc = Convert.ToInt32(match.Groups[2].Value);
                suburb = REIQ.Access.Suburb.Get(su, pc);
            }
            else // check to see if this is the name of a suburb or region
            {
                var matchingItems = REIQ.Access.Suburb.ListMatching(keyword);
                if (matchingItems != null && matchingItems.Suburbs != null && matchingItems.Suburbs.Count() > 0)
                {
                    suburb = matchingItems.Suburbs[0];
                }
            }

            return suburb;
        }

        public static String TryGetSuburbOrRegionFromSearchstring(String keyword)
        {
            String output = String.Empty;
            String region = String.Empty;
            REIQ.Entities.Suburb suburb = null;

            var match = Regex.Match(keyword, "(.*), (4\\d{3})"); // in format "Suburb Name, 4XXX"
            //Try get the current searched suburb
            if (match.Success)
            {
                var su = match.Groups[1].Value;
                var pc = Convert.ToInt32(match.Groups[2].Value);
                suburb = REIQ.Access.Suburb.Get(su, pc);
            }
            else // check to see if this is the name of a suburb or region
            {
                var matchingItems = REIQ.Access.Suburb.ListMatching(keyword);
                if (matchingItems != null && matchingItems.Suburbs != null && matchingItems.Suburbs.Count() == 1)
                {
                    suburb = matchingItems.Suburbs[0];
                }
                if (matchingItems != null && matchingItems.Regions != null && matchingItems.Regions.Count() == 1)
                {
                    region = matchingItems.Regions[0];
                }
            }

            //what have we found?
            if (suburb != null && !String.IsNullOrEmpty(suburb.name) && !String.IsNullOrEmpty(suburb.postcode.ToString()))
            {
                output = suburb.name + ", " + suburb.postcode.ToString();
            }
            else if (!String.IsNullOrEmpty(region))
            {
                output = region;
            }

            return output;
        }

        #region Featured Properties determination methods

        public static IEnumerable<KeyValuePair<String, String>> ListSurroundingSuburbs(string suburb, int postcode)
        {
            using (var conn = Data.CreateConnection())
            {
                var data = conn.Query<Entities.SurroundingSuburb>(@"SELECT * FROM tblSuroundingSuburb WHERE suburb LIKE @Suburb AND  postcode = @PC;",
                    new
                    {
                        Suburb = suburb,
                        PC = postcode
                    })
                    .FirstOrDefault();

                if (data == null)
                {
                    yield break;
                }

                if (data.suburbs1 != null && data.postcode1.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs1, data.postcode1.Value.ToString());

                if (data.suburbs2 != null && data.postcode2.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs2, data.postcode2.Value.ToString());

                if (data.suburbs3 != null && data.postcode3.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs3, data.postcode3.Value.ToString());

                if (data.suburbs4 != null && data.postcode4.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs4, data.postcode4.Value.ToString());

                if (data.suburbs5 != null && data.postcode5.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs5, data.postcode5.Value.ToString());

                if (data.suburbs6 != null && data.postcode6.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs6, data.postcode6.Value.ToString());

                if (data.suburbs7 != null && data.postcode7.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs7, data.postcode7.Value.ToString());

                if (data.suburbs8 != null && data.postcode8.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs8, data.postcode8.Value.ToString());

                if (data.suburbs9 != null && data.postcode9.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs9, data.postcode9.Value.ToString());

                if (data.suburbs10 != null && data.postcode10.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs10, data.postcode10.Value.ToString());

                if (data.suburbs11 != null && data.postcode11.HasValue)
                    yield return new KeyValuePair<String, String>(data.suburbs11, data.postcode11.Value.ToString());
            }
        }

        #endregion

        public static void LogSuburbSearch(Entities.Suburb suburb)
        {
            using (var conn = Data.CreateConnection())
            {
                string query = @"INSERT INTO tblLogSuburbSearch (sId, name) VALUES (@sId, @name)";

                conn.Execute(query, new { sId = suburb.sID, name = suburb.name });
            }
        }
        
        public static List<String> GetSuburbsByStatusAndRegion(string state, string region, string mapArea, string status)
        {
            var query = new System.Text.StringBuilder(@"SELECT DISTINCT LOWER(LTRIM(RTRIM(tprt.suburb)) + ', ' + tprt.postcode) AS NameAndCode, suburb FROM tblProperty tprt WHERE isWebdisplay=1");
            query.AppendLine();

            //set state in SQL query
            if (String.IsNullOrEmpty(state))
                state = "QLD";

            query.AppendLine(" AND tprt.state = @state");

            //set region in SQL query
            if (!String.IsNullOrEmpty(region))
            {                
                //can be several regions in querystring from the "search by map" page
                string[] rgs = region.Split(',');
                if (rgs.Length > 1)
                {
                    string tmpRegion = String.Empty;
                    foreach (var rg in rgs)
                    {
                        tmpRegion += "'" + rg + "',";                        
                    }
                    region = tmpRegion.TrimEnd(',');
                    string qr = " AND tprt.suburb IN (SELECT name FROM tblsuburb tsbb WHERE tsbb.region IN (" + region + ")) AND tprt.postcode IN (SELECT postcode FROM tblsuburb tsbb WHERE tsbb.region IN (" + region + "))";
                    query.AppendLine(qr);
                }
                else query.AppendLine(" AND tprt.suburb IN (SELECT name FROM tblsuburb tsbb WHERE tsbb.region LIKE @region) AND tprt.postcode IN (SELECT postcode FROM tblsuburb tsbb WHERE tsbb.region LIKE @region)");
            }
            //set mapArea in SQL query
            if (!String.IsNullOrEmpty(mapArea))
                query.AppendLine(" AND tprt.suburb IN (SELECT name FROM tblsuburb tsbb WHERE tsbb.maparea LIKE @maparea) AND tprt.postcode IN (SELECT postcode FROM tblsuburb tsbb WHERE tsbb.maparea LIKE @maparea)");
            
            //set status in SQL query
            if (!String.IsNullOrEmpty(status))
            {
                if (status == "fs")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer', 'Sold') AND type NOT IN ('Commercial','Business')");
                else if (status == "fr")
                    query.AppendLine(" AND status IN ('For Rent', 'Rented') AND type NOT IN ('Commercial','Business')");
                else if (status == "sa")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer') AND type NOT IN ('Commercial','Business')");
                else if (status == "ra")
                    query.AppendLine(" AND status IN ('For Rent') AND type NOT IN ('Commercial','Business')");
                else if (status == "au")
                    query.AppendLine(" AND priceOption IN ('Auction')");
                else if (status == "po")
                    query.AppendLine(" AND priceOption IN ('POA')");
                else if (status == "uo")
                    query.AppendLine(" AND status IN ('Under Offer')");
                else if (status == "so")
                    query.AppendLine(" AND status IN ('Sold')");
                else if (status == "co")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer', 'Sold') AND type IN ('Commercial')");
                else if (status == "inv")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer', 'Sold') AND isInvestment = 1");
                else if (status == "bu")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer', 'Sold') AND type IN ('Business')");
                else if (status == "ru")
                    query.AppendLine(" AND status IN ('For Sale', 'Under Offer', 'Sold') AND type IN ('Acreage/Rural')");
                else if (status == "cr")
                    query.AppendLine(" AND status IN ('For Rent', 'Rented') AND type IN ('Commercial')");
                else query.AppendLine(" AND status IN @status");
            }

            query.AppendLine(" ORDER BY suburb");

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<String>(query.ToString(),
                    new
                    {
                        state = state,
                        region = region,
                        maparea = mapArea,
                        status = status
                    }).ToList();                
            }
        }

        public static List<String> GetRegionByMaparea(string mapArea)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<String>("SELECT DISTINCT region FROM tblSuburb WHERE maparea LIKE @maparea AND region IS NOT NULL", new { maparea = mapArea }).ToList();
            }
        }

        public class SuburbChartData
        {
            public int NumberOfClicks { get; set; }
            public DateTime Date { get; set; }
        }

        public static List<SuburbChartData> GetChartSuburbSearchStats(string suburbName, string startDate, string endDate)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<SuburbChartData>("SELECT COUNT(date) AS NumberOfClicks,  DATEADD(dd, 0, DATEDIFF(dd, 0, date)) AS Date FROM tblLogSuburbSearch WHERE name LIKE @name AND date BETWEEN @startDate AND DATEADD(day, 1, @endDate) GROUP BY  DATEADD(dd, 0, DATEDIFF(dd, 0, date)) ORDER BY date ASC",
                    new { name = suburbName, startDate = startDate, endDate = endDate }).ToList();
            }
        }

        public static List<String> GetAllRegions()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<String>("SELECT DISTINCT (region) FROM tblSuburb WITH (NOLOCK)").ToList<string>();
            }
        }

        public static List<Entities.Suburb> GetAlllocations()
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Suburb>("SELECT DISTINCT (s.name), s.postcode, s.region FROM tblSuburb s WITH (NOLOCK)").ToList<Entities.Suburb>();
            }
        }
    }
}