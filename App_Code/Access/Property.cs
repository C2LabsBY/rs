using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using Dapper;
using System.Text;

namespace REIQ.Access
{
    public class Property
    {
        public static Entities.Property GetFromPropertyId(int propertyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Property>(
                    @"
                    SELECT      *    
                    FROM        tblProperty p WITH (NOLOCK)
                    WHERE       p.pID = @pID
                                and golive = 0 
                                and isWebDisplay = 1;", 
                    new { pID = propertyId }).FirstOrDefault();
            }
        }

        //get property for security property info page
        public static Entities.Property SecurityGetFromPropertyId(int propertyId)
        {
            using (var conn = Data.CreateConnection())
            {

                return conn.Query<Entities.Property>(
                    @"
                    SELECT      *    
                    FROM        tblProperty p WITH (NOLOCK)
                    WHERE       p.pID = @pID",
                    new { pID = propertyId }).FirstOrDefault();
            }
        }

        //Returns actual StreetName if does exist in DB
        public static String GetStreetName(String key, String rdType)
        {
            using (var conn = Data.CreateConnection())
            {
                string query = 
                @"SELECT     TOP 1 p.rdName    
                 FROM        tblProperty p WITH (NOLOCK)
                 WHERE       p.rdName = '" + key.ToLower() + "'";
                
                if(!String.IsNullOrEmpty(rdType))
                    query += " AND p.rdType LIKE '%" + rdType.ToLower() + "%'"; 

                return conn.Query<String>(query).FirstOrDefault();
            }
        }

        //Returns actual SuburbName if does exist in DB
        public static String GetSuburbByStreetName(String key, String rdType)
        {
            using (var conn = Data.CreateConnection())
            {
                string query =
                    @"SELECT      TOP 1 p.suburb    
                    FROM        tblProperty p WITH (NOLOCK)
                    WHERE p.rdName = '" + key + "'";

                if (!String.IsNullOrEmpty(rdType))
                    query += " AND p.rdType LIKE '%" + rdType.ToLower() + "%'"; 

                return conn.Query<String>(query).FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets only the ids of the properties we've searched for
        /// </summary>
        public static IEnumerable<int> Search(REIQ.Enum.SearchType searchType, IEnumerable<string> propertyTypes, bool excludeUnderOffer, bool includeSurroundingSuburbs, bool onlyIfOpenHome, string keyword, int minPrice, int maxPrice, int numBedrooms, REIQ.Enum.SortOptions sortOption, int acId = 0)
        {
            // computed values from keyword
            Entities.Suburb suburb = null;      // suburbing matching search keyword
            List<Entities.Suburb> suburbsList = new List<Entities.Suburb>(); // list of suburbs when search string contains several suburbs
            int? postcode = null;               // exact postcode
            Entities.Property property = null;  // exact property id entered into search
            string region = null;               // keyword corresponds to a region
            List<string> regionsList = new List<string>(); //list of regions when query string contains several regions

            // several regions are selected
            if (keyword.Contains("::"))
            {
                foreach (var rg in keyword.Split(new string[] { "::" }, StringSplitOptions.None))
                {
                    regionsList.Add(rg);
                }
            }
            // several suburbs are selected
            else if (keyword.Contains("!!"))
            {
                foreach (var sb in keyword.Split(new string[] { "!!" }, StringSplitOptions.None))
                {
                    var match = Regex.Match(sb, "(.*), (4\\d{3})"); // in format "Suburb Name, 4XXX"
                    if (match.Success)
                    {
                        var su = match.Groups[1].Value;
                        var pc = Convert.ToInt32(match.Groups[2].Value);
                        suburb = REIQ.Access.Suburb.Get(su, pc);
                        //save search query into DB for stats
                        if (suburb != null && !String.IsNullOrEmpty(suburb.name))
                        {
                            Suburb.LogSuburbSearch(suburb);
                            //remember found suburb
                            suburbsList.Add(suburb);
                        }
                    }                    
                }
            }           
            else
            {
                var match = Regex.Match(keyword, "(.*), (4\\d{3})"); // in format "Suburb Name, 4XXX"
                if (match.Success)
                {
                    var su = match.Groups[1].Value;
                    var pc = Convert.ToInt32(match.Groups[2].Value);
                    suburb = REIQ.Access.Suburb.Get(su, pc);
                    //save search query into DB for stats
                    if (suburb != null && !String.IsNullOrEmpty(suburb.name))
                    {
                        Suburb.LogSuburbSearch(suburb);
                    }
                }
                else if (Regex.IsMatch(keyword, "^4[0-9]{3}$")) // postcode only
                {
                    postcode = Convert.ToInt32(keyword);
                }
                else if (Regex.IsMatch(keyword, "^\\d+$"))  // is purely numeric, so check if this is a property id
                {
                    Int32 potentialPropertyID = 0;
                    if (Int32.TryParse(keyword, out potentialPropertyID))//To avoid throwing of errors if the number is very big like "12234456677"
                    {
                        using (var conn = Data.CreateConnection())
                        {
                            property = conn.Query<Entities.Property>("SELECT * FROM tblProperty WITH (NOLOCK) WHERE pId = @pID and golive = 0 and isWebDisplay = 1", new { pID = potentialPropertyID }).FirstOrDefault();
                        }

                        if (property == null) keyword = String.Empty;
                    }
                }
                else // check to see if this is the name of a suburb or region
                {
                    var matchingItems = REIQ.Access.Suburb.ListMatching(keyword);
                    if (matchingItems != null && matchingItems.Regions != null && matchingItems.Regions.Count() > 0)
                    {
                        region = matchingItems.Regions[0];
                    }
                    else if (matchingItems != null && matchingItems.Suburbs != null && matchingItems.Suburbs.Count() > 0)
                    {
                        if (matchingItems.Suburbs.Count() == 1)
                        {
                            suburb = matchingItems.Suburbs[0];
                            Suburb.LogSuburbSearch(suburb);
                        }
                        else
                        {
                            foreach (var sb in matchingItems.Suburbs)
                            {
                                suburbsList.Add(sb);
                                Suburb.LogSuburbSearch(sb);
                            }
                        }
                    }
                }
            }

            if (property != null) // exact property match
            {
                return Enumerable.Repeat<int>(property.pID, 1);
            }

            if (regionsList.Count == 0 && suburbsList.Count == 0 && suburb == null && !postcode.HasValue && String.IsNullOrEmpty(region) && property == null && !String.IsNullOrEmpty(keyword)) // found nothing!
            {
                //if (HttpContext.Current != null)
                //    HttpContext.Current.Response.Redirect("~/?nomatches=1");
                //return Enumerable.Empty<int>();

                //Street Search
                IEnumerable<int> streetSearchList = TryStreetSearch(searchType, propertyTypes, excludeUnderOffer, includeSurroundingSuburbs, onlyIfOpenHome, keyword.Replace(",", " "), minPrice, maxPrice, numBedrooms, sortOption);
                if (streetSearchList.Count() > 0) return streetSearchList;
            }
            
            var query = new System.Text.StringBuilder(@"SELECT TOP 5000 p.pId
                FROM		tblProperty p
                LEFT JOIN   tblSuburb s ON s.name = p.Suburb AND s.postcode = p.postcode
                WHERE		p.isWebDisplay = 1
                AND p.goLive = 0
                AND p.hideAHC = 0
                AND p.status IN @Status
                ");
            query.AppendLine();

            // agencyId
            if (acId > 0)
            {
                query.AppendLine("AND p.acId = @AgencyId");
            }

            //get exact suburbs to search
            List<int> suburbIds = new List<int>();
            if (regionsList != null && regionsList.Count > 0)
            {
                foreach (var rg in regionsList)
                {
                    suburbIds = suburbIds.Concat(Access.Suburb.ListIdsOfSuburbsByRegion(rg)).ToList();
                    //ugly hack for SQL server not accepting more than 200 parameters
                    if (suburbIds.Count > 200) break;
                }
            }
            else if (!String.IsNullOrEmpty(region))
            {
                suburbIds = Access.Suburb.ListIdsOfSuburbsByRegion(region);
            }
            else if (suburbsList != null && suburbsList.Count > 0)
            {
                foreach (var sb in suburbsList)
                {
                    if (includeSurroundingSuburbs)
                    {
                        if (suburbIds.Count == 0)
                            suburbIds = Access.Suburb.ListIdsOfSurroundingSuburbs(sb.name, sb.postcode.Value).ToList();
                        else
                        {
                            List<int> tempSbs = Access.Suburb.ListIdsOfSurroundingSuburbs(sb.name, sb.postcode.Value).ToList();
                            suburbIds = suburbIds.Concat(tempSbs).ToList();
                        }
                    }
                    else
                    {
                        suburbIds.Add(sb.sID);
                    }
                }
            }
            else if (suburb != null)
            {
                if (includeSurroundingSuburbs)
                {
                    suburbIds = Access.Suburb.ListIdsOfSurroundingSuburbs(suburb.name, suburb.postcode.Value).ToList();
                }
                else
                {
                    suburbIds = new List<int> { suburb.sID };
                }
            }
            else if (postcode.HasValue)
            {
                suburbIds = Access.Suburb.ListIdsOfSuburbsByPostCode(postcode.Value);
            }

            // set property type filter
            switch (searchType)
            {
                case Enum.SearchType.bu:
                    query.AppendLine("AND p.type = 'business'");
                    break;
                case Enum.SearchType.co:
                case Enum.SearchType.cr:
                    query.AppendLine("AND p.type = 'commercial'");
                    break;
                case Enum.SearchType.ru:
                    query.AppendLine("AND p.type = 'Acreage/Rural'");
                    break;
                case Enum.SearchType.ra:
                case Enum.SearchType.sa:
                default:
                    query.AppendLine("AND p.type NOT IN ('commercial', 'business')");
                    if (propertyTypes.Count() > 0)
                    {
                        query.AppendLine("AND p.type IN @PropertyTypes");
                    }
                    break;
            }

            // set status filter
            var status = new List<string>();
            switch (searchType)
            {
                case Enum.SearchType.bu:
                    status.Add("For Sale");
                    status.Add("For Rent");
                    break;
                case Enum.SearchType.cr:
                case Enum.SearchType.ra:
                    status.Add("For Rent");
                    break;
                case Enum.SearchType.sa:
                case Enum.SearchType.ru:
                case Enum.SearchType.co:
                default:
                    status.Add("For Sale");
                    break;
            }

            if (!excludeUnderOffer && !status.Contains("For Rent"))
            {
                status.Add("Under offer");
            }
            
            if (onlyIfOpenHome)
            {
                query.AppendLine("AND COALESCE(p.homeopen1From, p.homeopen2From) IS NOT NULL");
            }

            if (numBedrooms > 0)
            {
                query.AppendLine("AND COALESCE(p.numBedrooms, 0) >= @NumBedrooms");
            }

            // price filter
            if (minPrice > 0)
            {
                query.AppendLine("AND COALESCE(p.commercialPriceYearly, ISNULL(p.priceLow, 0)) >= @MinPrice");
            }

            if (maxPrice > 0)
            {
                query.AppendLine("AND COALESCE(p.commercialPriceYearly, p.priceHigh, ISNULL(p.priceLow, 0)) <= @MaxPrice");
            }

            if (suburbIds.Count() > 0)
            {
                query.AppendLine("AND s.SID IN @SuburbIds");
            }

            //sort on the most appropriate price field for the property type
            switch (sortOption)
            {
                default:
                case Enum.SortOptions.Most_recent:
                    query.AppendLine("ORDER BY p.datelisted DESC");
                    break;
                case Enum.SortOptions.By_suburb:
                    query.AppendLine("ORDER BY p.suburb, COALESCE(p.commercialPriceYearly, p.priceLow) DESC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Highest_price:
                    query.AppendLine("ORDER BY COALESCE(p.commercialPriceYearly, p.priceLow) DESC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Lowest_price:
                    query.AppendLine("ORDER BY COALESCE(p.commercialPriceYearly, p.priceLow) ASC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Number_bedrooms:
                    query.AppendLine("ORDER BY p.numBedrooms ASC, p.datelisted DESC");
                    break;
            }

            REIQ.Access.Data.TraceWrite("Search query", query.ToString());
            //foreach (int id in suburbIds)
            //{
            //    REIQ.Access.Data.TraceWrite("SuburbIDS", id.ToString());
            //}
            //REIQ.Access.Data.TraceWrite("Region", region);
            REIQ.Access.Data.TraceWrite("Property types", string.Join(", ", propertyTypes.ToArray()));
            REIQ.Access.Data.TraceWrite("Status", string.Join(", ", status.ToArray()));

            using (var conn = Data.CreateConnection())
            {
                return from p in conn.Query<Entities.Property>(query.ToString(), new
                {
                    AgencyId = acId,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice,
                    NumBedrooms = numBedrooms,
                    PropertyTypes = propertyTypes,
                    Status = status,
                    SuburbIds = suburbIds
                })
                       select p.pID;
            }
        }

        /// <summary>
        /// Given a list of propery Ids from a search, return the details for only those that we want to display on the specified page.
        /// Assumes 20 items per page, and default to first page, unless otherwise specified. 
        /// </summary>
        public static IEnumerable<PropertyExtended> ListForDisplay(IEnumerable<int> propertyIds, REIQ.Enum.SortOptions sortOption, int pageNumber = 0, int itemsPerPage = 20)
        {
            var iStartAt = 0;

            if(pageNumber > 1)
                iStartAt = (pageNumber) * itemsPerPage - itemsPerPage;

            propertyIds = propertyIds.Skip(iStartAt).Take(itemsPerPage);

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<PropertyExtended>("SELECT tPrty.*,tSbrb.region FROM tblProperty tPrty JOIN tblSuburb tSbrb WITH (NOLOCK) ON tPrty.suburb = tSbrb.name AND tPrty.postcode = tSbrb.postcode WHERE tPrty.pId in @Ids", new { Ids = propertyIds })
                //return conn.Query<Entities.Property>("SELECT * FROM tblProperty WITH (NOLOCK) WHERE pId in @Ids", new { Ids = propertyIds })
                    .OrderBy(x => Array.IndexOf(propertyIds.ToArray(), x.pID));
            }
        }        

        //public static IEnumerable<Entities.Property> GetFeaturedProperties(string acID, string status, List<string> suburb, List<string> postcode, string aid, string pid, List<string> type)
        public static IEnumerable<Entities.Property> GetFeaturedProperties(string acID, string status, List<string> suburb, List<string> postcode, string aid, string pid, List<string> type)
        {
            using (var conn = Data.CreateConnection())
            {
                //Determine whether should we search by agent or by propertyIds
                String optionalCondition = String.Empty;
                if (!String.IsNullOrEmpty(pid))
                    optionalCondition = "";
                if (!String.IsNullOrEmpty(aid))
                    optionalCondition = String.Format("AND ((aID1 LIKE {0}) OR (aID2 LIKE {0}))", aid);
                
                //Status filter

                var statusList = new List<string>();

                // set status filter
                switch ((REIQ.Enum.SearchType)System.Enum.Parse(typeof(REIQ.Enum.SearchType), status, true))
                {
                    case  Enum.SearchType.fs:
                        statusList.Add("For Sale");
                        statusList.Add("Under Offer");
                        statusList.Add("Sold");
                        break;
                    case Enum.SearchType.bu:
                        statusList.Add("For Sale");
                        statusList.Add("For Rent");
                        break;
                    case Enum.SearchType.cr:
                    case Enum.SearchType.ra:
                        statusList.Add("For Rent");
                        break;
                    case Enum.SearchType.au:
                        statusList.Add("Auction");
                        break;
                    case Enum.SearchType.po:
                        statusList.Add("POA");
                        break;
                    case Enum.SearchType.uo:
                        statusList.Add("Under Offer");
                        break;
                    case Enum.SearchType.so:
                        statusList.Add("Sold");
                        break;
                    case Enum.SearchType.fr:
                        statusList.Add("For Rent");
                        statusList.Add("Rented");
                        break;
                    case Enum.SearchType.sa:
                        statusList.Add("For Sale");
                        statusList.Add("Under Offer");
                        break;
                    case Enum.SearchType.ru:
                    case Enum.SearchType.co:
                    default:
                        statusList.Add("For Sale");
                        break;
                }

                return conn.Query<Entities.Property>(
                    @"
                    SELECT      *,dbo.forPriority(pid) as commp 
                    FROM        tblProperty 
                    WHERE       golive = 0 and (pid is not null ) 
                    AND         (acID IN (@acId)) 
                    AND         (hideAHC = 0) 
                    AND         type IN @type 
                    AND         suburb IN @suburb 
                    AND         postcode IN @postcode
                    AND         status IN @status
                    AND         (isWebDisplay = 1)" + optionalCondition,
                    new { acId = acID, type = type, suburb = suburb, postcode = postcode, status = statusList });
            }
        }

        #region StreetSearch

        public static IEnumerable<int> TryStreetSearch(REIQ.Enum.SearchType searchType, IEnumerable<string> propertyTypes, bool excludeUnderOffer, bool includeSurroundingSuburbs, bool onlyIfOpenHome, string keyword, int minPrice, int maxPrice, int numBedrooms, REIQ.Enum.SortOptions sortOption)
        {
            //Try search by address
            String rdNum = String.Empty;
            String rdType = String.Empty;
            String streetName = String.Empty;
            String subName = String.Empty;
            String keyWordsForSuburb = String.Empty;
            String keyWordsForStreet = String.Empty;
            String[] parts = keyword.Split(' ');
            //String rdTypeConstant = "(street|st|road|rd|close|cl|avenue|ave|av|path|ph|drive|drv|loop|court|ct|circle|lane|ln|way)";
            IEnumerable<int> list = Enumerable.Empty<int>();
            String region = String.Empty;
            List<string> allSuburbs = null;
            List<Suburb.StreetNames> allStreets = null;

            //get all suburbs from DB
            allSuburbs = Suburb.GetAllSuburbs();
            //Try determine suburb
            String foundSuburb = String.Empty;
            foreach (String suburb in allSuburbs)
            {
                if (String.IsNullOrEmpty(suburb)) continue;

                if (keyword.ToLower().Contains(suburb.ToLower()))
                {
                    foundSuburb = suburb;

                    //Log this suburb search
                    REIQ.Entities.Suburb s = Suburb.GetFromName(suburb);
                    if (s != null) Suburb.LogSuburbSearch(s);

                    break;
                }
            }

            //get all possible combinations of Road Name and Road Type
            if (!String.IsNullOrEmpty(foundSuburb))
                allStreets = Suburb.GetAllStreetsBySuburb(foundSuburb);
            else allStreets = Suburb.GetAllStreets();
            //Trying to determine roadNumber and roadType
            foreach (String part in parts)
            {
                var matchNumber = Regex.Match(part, @"\d");

                if (matchNumber.Captures.Count > 0)
                    rdNum = part;

                //if (rdTypeConstant.Contains(part.Trim().ToLower()))
                //    rdType = part;
            }

            String foundStreetName = String.Empty;
            String foundStreetType = String.Empty;

            //List<Suburb.StreetNames> res = allStreets.Where(s => keyword.ToLower().Contains((String.IsNullOrEmpty(s.StreetName) ? "" : s.StreetName.ToLower()) + " " + (String.IsNullOrEmpty(s.StreetType) ? "" : s.StreetType.ToLower()))).ToList();

            foreach (Suburb.StreetNames street in allStreets)
            {
                if (String.IsNullOrEmpty(street.StreetName)) continue;
                if (Regex.IsMatch(street.StreetName, "^\\d+$")) continue;

                if (keyword.ToLower().Contains((String.IsNullOrEmpty(street.StreetName) ? "" : street.StreetName.ToLower()) + " " + (String.IsNullOrEmpty(street.StreetType) ? "" : street.StreetType.ToLower())))
                {
                    foundStreetName = street.StreetName;
                    foundStreetType = street.StreetType;
                    break;
                }
            }
            if (String.IsNullOrEmpty(foundStreetName))
            {
                foreach (Suburb.StreetNames street in allStreets)
                {
                    if (String.IsNullOrEmpty(street.StreetName)) continue;
                    if (Regex.IsMatch(street.StreetName, "^\\d+$")) continue;

                    if (keyword.ToLower().Contains(street.StreetName.ToLower()))
                    {
                        foundStreetName = street.StreetName;
                        break;
                    }
                }
            }

            #region setUpOptions
            //Set up filter
            StringBuilder queryFilterString = new System.Text.StringBuilder();
            // set property type filter
            switch (searchType)
            {
                case Enum.SearchType.bu:
                    queryFilterString.AppendLine("AND p.type = 'business'");
                    break;
                case Enum.SearchType.co:
                case Enum.SearchType.cr:
                    queryFilterString.AppendLine("AND p.type = 'commercial'");
                    break;
                case Enum.SearchType.ru:
                    queryFilterString.AppendLine("AND p.type = 'Acreage/Rural'");
                    break;
                case Enum.SearchType.ra:
                case Enum.SearchType.sa:
                default:
                    queryFilterString.AppendLine("AND p.type NOT IN ('commercial', 'business')");
                    if (propertyTypes.Count() > 0)
                    {
                        queryFilterString.AppendLine("AND p.type IN @PropertyTypes");
                    }
                    break;
            }

            // set status filter
            var status = new List<string>();
            switch (searchType)
            {
                case Enum.SearchType.bu:
                    status.Add("For Sale");
                    status.Add("For Rent");
                    break;
                case Enum.SearchType.cr:
                case Enum.SearchType.ra:
                    status.Add("For Rent");
                    break;
                case Enum.SearchType.sa:
                case Enum.SearchType.ru:
                case Enum.SearchType.co:
                default:
                    status.Add("For Sale");
                    break;
            }

            if (!excludeUnderOffer && !status.Contains("For Rent"))
            {
                status.Add("Under offer");
            }

            if (onlyIfOpenHome)
            {
                queryFilterString.AppendLine("AND COALESCE(p.homeopen1From, p.homeopen2From) IS NOT NULL");
            }

            if (numBedrooms > 0)
            {
                queryFilterString.AppendLine("AND COALESCE(p.numBedrooms, 0) >= @NumBedrooms");
            }

            // price filter
            if (minPrice > 0)
            {
                queryFilterString.AppendLine("AND COALESCE(p.commercialPriceYearly, p.priceLow) >= @MinPrice");
            }

            if (maxPrice > 0)
            {
                queryFilterString.AppendLine("AND COALESCE(p.commercialPriceYearly, p.priceHigh, p.priceLow) <= @MaxPrice");
            }

            // sort on the most appropriate price field for the property type
            switch (sortOption)
            {
                default:
                case Enum.SortOptions.Most_recent:
                    queryFilterString.AppendLine("ORDER BY p.datelisted DESC");
                    break;
                case Enum.SortOptions.By_suburb:
                    queryFilterString.AppendLine("ORDER BY p.suburb, COALESCE(p.commercialPriceYearly, p.priceLow) DESC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Highest_price:
                    queryFilterString.AppendLine("ORDER BY COALESCE(p.commercialPriceYearly, p.priceLow) DESC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Lowest_price:
                    queryFilterString.AppendLine("ORDER BY COALESCE(p.commercialPriceYearly, p.priceLow) ASC, p.datelisted DESC");
                    break;
                case Enum.SortOptions.Number_bedrooms:
                    queryFilterString.AppendLine("ORDER BY p.numBedrooms ASC, p.datelisted DESC");
                    break;
            }
            #endregion setUpOptions

            #region DBSearch
            if (!String.IsNullOrEmpty(foundStreetName) && !String.IsNullOrEmpty(foundSuburb))
            {

                //Trying to get poperty via it certain address
                if (!String.IsNullOrEmpty(foundStreetName) && !String.IsNullOrEmpty(foundSuburb))
                {
                    if (!String.IsNullOrEmpty(foundStreetType) && !String.IsNullOrEmpty(rdNum))
                        list = DoStreetSearch_By_Suburb_rdNum_strName_strType(queryFilterString.ToString(), foundSuburb, rdNum, foundStreetName, foundStreetType, status, minPrice, maxPrice, numBedrooms, propertyTypes);

                    if (!(list.Count() > 0))
                    {
                        if (!String.IsNullOrEmpty(foundStreetType))
                            list = DoStreetSearch_By_Suburb_strName_strType(queryFilterString.ToString(), foundSuburb, foundStreetName, foundStreetType, status, minPrice, maxPrice, numBedrooms, propertyTypes);
                    }

                    if (!(list.Count() > 0))
                        list = DoStreetSearch_By_Suburb_strName(queryFilterString.ToString(), foundSuburb, foundStreetName, status, minPrice, maxPrice, numBedrooms, propertyTypes);

                    if (!(list.Count() > 0))
                        list = DoStreetSearch_By_Suburb(queryFilterString.ToString(), foundSuburb, status, minPrice, maxPrice, numBedrooms, propertyTypes);
                }
            }
            //Get Property via Suburb if Street name was not found
            if (String.IsNullOrEmpty(foundStreetName))
                list = DoStreetSearch_By_Suburb(queryFilterString.ToString(), foundSuburb, status, minPrice, maxPrice, numBedrooms, propertyTypes);

            //Get Property via Street name if suburb was not found
            if (String.IsNullOrEmpty(foundSuburb))
            {
                //get property via Street name and Street num and Street type
                if (!String.IsNullOrEmpty(foundStreetType) && !String.IsNullOrEmpty(rdNum))
                    list = DoStreetSearch_By_rdNum_strName_strType(queryFilterString.ToString(), rdNum, foundStreetName, foundStreetType, status, minPrice, maxPrice, numBedrooms, propertyTypes);

                //get property via Street name and Street type
                if (!String.IsNullOrEmpty(foundStreetType))
                    list = DoStreetSearch_By_strName_strType(queryFilterString.ToString(), foundStreetName, foundStreetType, status, minPrice, maxPrice, numBedrooms, propertyTypes);

                //get property via Street name if nothing found before
                if (!(list.Count() > 0))
                    list = DoStreetSearch_By_strName(queryFilterString.ToString(), foundStreetName, status, minPrice, maxPrice, numBedrooms, propertyTypes);
            }

            return list;
            #endregion
        }

        private static IEnumerable<Int32> DoStreetSearch_By_Suburb_rdNum_strName_strType(String queryFilterString, String foundSuburb, String rdNum, String foundStreetName, String foundStreetType, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                                   @"
                                SELECT      p.pid   
                                FROM        tblProperty p WITH (NOLOCK)
                                WHERE       p.suburb = @suburb
                                            AND rdNum LIKE @rdNum
                                            AND p.rdName LIKE @rdName
                                            AND p.rdType LIKE @rdType
                                            AND p.status IN @status
                                            AND p.isWebDisplay = 1
                                            AND p.goLive = 0
                                            AND p.hideAHC = 0" + queryFilterString.ToString(),
                               new
                               {
                                   suburb = foundSuburb,
                                   rdNum = "%" + rdNum + "%",
                                   rdName = "%" + foundStreetName + "%",
                                   rdType = "%" + foundStreetType + "%",
                                   status = status,
                                   MinPrice = minPrice,
                                   MaxPrice = maxPrice,
                                   NumBedrooms = numBedrooms,
                                   PropertyTypes = propertyTypes
                               });
            }
        }

        private static IEnumerable<Int32> DoStreetSearch_By_Suburb_strName_strType(String queryFilterString, String foundSuburb, String foundStreetName, String foundStreetType, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                                   @"
                                    SELECT      p.pid   
                                    FROM        tblProperty p WITH (NOLOCK)
                                    WHERE       p.suburb = @suburb
                                                AND p.rdName LIKE @rdName
                                                AND p.rdType LIKE @rdType
                                                AND p.status IN @status
                                                AND p.isWebDisplay = 1
                                                AND p.goLive = 0
                                                AND p.hideAHC = 0" + queryFilterString.ToString(),
                               new
                               {
                                   suburb = foundSuburb,
                                   rdName = "%" + foundStreetName + "%",
                                   rdType = "%" + foundStreetType + "%",
                                   status = status,
                                   MinPrice = minPrice,
                                   MaxPrice = maxPrice,
                                   NumBedrooms = numBedrooms,
                                   PropertyTypes = propertyTypes
                               });
            }
        }
        
        private static IEnumerable<Int32> DoStreetSearch_By_Suburb_strName(String queryFilterString, String foundSuburb, String foundStreetName, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                                   @"
                                    SELECT      p.pid   
                                    FROM        tblProperty p WITH (NOLOCK)
                                    WHERE       p.suburb = @suburb
                                                AND p.rdName LIKE @rdName
                                                AND p.status IN @status
                                                AND p.isWebDisplay = 1
                                                AND p.goLive = 0
                                                AND p.hideAHC = 0" + queryFilterString.ToString(),
                               new
                               {
                                   suburb = foundSuburb,
                                   rdName = "%" + foundStreetName + "%",
                                   status = status,
                                   MinPrice = minPrice,
                                   MaxPrice = maxPrice,
                                   NumBedrooms = numBedrooms,
                                   PropertyTypes = propertyTypes
                               });
            }
        }

        private static IEnumerable<Int32> DoStreetSearch_By_Suburb(String queryFilterString, String foundSuburb, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                           @"
                            SELECT      p.pid    
                            FROM        tblProperty p WITH (NOLOCK)
                            WHERE       p.suburb = @suburb 
                                        AND p.status IN @status
                                        AND p.isWebDisplay = 1
                                        AND p.goLive = 0
                                        AND p.hideAHC = 0" + queryFilterString.ToString(),
                       new
                       {
                           suburb = foundSuburb,
                           status = status,
                           MinPrice = minPrice,
                           MaxPrice = maxPrice,
                           NumBedrooms = numBedrooms,
                           PropertyTypes = propertyTypes
                       });
            }
        }
        
        private static IEnumerable<Int32> DoStreetSearch_By_rdNum_strName_strType(String queryFilterString, String rdNum, String foundStreetName, String foundStreetType, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                               @"
                            SELECT      p.pid    
                            FROM        tblProperty p WITH (NOLOCK)
                            WHERE       p.rdnum = @rdNum
                                        AND p.rdName LIKE @rdName
                                        AND p.rdType LIKE @rdType
                                        AND p.status IN @status
                                        AND p.isWebDisplay = 1
                                        AND p.goLive = 0
                                        AND p.hideAHC = 0" + queryFilterString.ToString(),
                           new
                           {
                               rdNum = rdNum,
                               rdName = "%" + foundStreetName + "%",
                               rdType = "%" + foundStreetType + "%",
                               status = status,
                               MinPrice = minPrice,
                               MaxPrice = maxPrice,
                               NumBedrooms = numBedrooms,
                               PropertyTypes = propertyTypes
                           });
            }
        }

        private static IEnumerable<Int32> DoStreetSearch_By_strName_strType(String queryFilterString, String foundStreetName, String foundStreetType, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                               @"
                            SELECT      p.pid    
                            FROM        tblProperty p WITH (NOLOCK)
                            WHERE       p.rdName LIKE @rdName
                                        AND p.rdType LIKE @rdType
                                        AND p.status IN @status
                                        AND p.isWebDisplay = 1
                                        AND p.goLive = 0
                                        AND p.hideAHC = 0" + queryFilterString.ToString(),
                           new
                           {
                               rdName = "%" + foundStreetName + "%",
                               rdType = "%" + foundStreetType + "%",
                               status = status,
                               MinPrice = minPrice,
                               MaxPrice = maxPrice,
                               NumBedrooms = numBedrooms,
                               PropertyTypes = propertyTypes
                           });
            }
        }

        private static IEnumerable<Int32> DoStreetSearch_By_strName(String queryFilterString, String foundStreetName, List<String> status, Int32 minPrice, Int32 maxPrice, Int32 numBedrooms, IEnumerable<String> propertyTypes)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Int32>(
                               @"
                            SELECT      p.pid    
                            FROM        tblProperty p WITH (NOLOCK)
                            WHERE       p.rdName LIKE @rdName
                                        AND p.status IN @status
                                        AND p.isWebDisplay = 1
                                        AND p.goLive = 0
                                        AND p.hideAHC = 0" + queryFilterString.ToString(),
                           new
                           {
                               rdName = "%" + foundStreetName + "%",
                               status = status,
                               MinPrice = minPrice,
                               MaxPrice = maxPrice,
                               NumBedrooms = numBedrooms,
                               PropertyTypes = propertyTypes
                           });
            }
        }
        #endregion StreetSearch       

        //Get property region
        public static String GetPropertyRegion(int propertyId)
        {
            using (var conn = Data.CreateConnection())
            {
                string query =
                @"SELECT     region    
                 FROM        tblSuburb s 
                 JOIN        tblProperty p WITH (NOLOCK)
                 ON          s.name = p.suburb
                 WHERE       p.pID = '" + propertyId.ToString() + "'";
                
                return conn.Query<String>(query).FirstOrDefault();
            }
        }
    }

    public class PropertyExtended : Entities.Property
    {
        public string region { get; set; }
    }
}