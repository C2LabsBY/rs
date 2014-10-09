using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access{
    public class Agency
    {
        public static Entities.Agency GetFromPropertyId(int propertyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agency>(
                    @"
                    SELECT      *    
                    FROM        tblAgency a
                    INNER JOIN tblProperty p ON p.acID = a.acID 
                    WHERE p.pID = @pID;", new { pID = propertyId }).FirstOrDefault();
            }
        }

        public static Entities.Agency GetFromAgencyId(int agencyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agency>(
                    @"
                    SELECT      *    
                    FROM        tblAgency 
                    WHERE acId = @acId;", new { acId = agencyId }).FirstOrDefault();
            }
        }

        public static Entities.Agency GetFromAgencyName(string agencyName)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agency>(
                    @"
                    SELECT      *    
                    FROM        tblAgency 
                    WHERE name = @name;", new { name = agencyName }).FirstOrDefault();
            }
        }

        public static IEnumerable<Entities.Agent> GetOfficeAgentsImisProfile(int agencyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agent>(
                    @"SELECT * FROM tblAgent WHERE (acID = @acID) 
                    AND (isWebDisplay = 1) 
                    AND (
		                    (ShowOnAgencyProfile is null and imisaid is not null) or 
		                    (ShowOnAgencyProfile=1 and imisaid is not null) or 
		                    (ShowOnAgencyProfile=1 and imisaid is null)	
	                    )
                    AND (isnull(imisaid,0)!=1) ORDER BY orderID,firstname", new { acId = agencyId });
            }
        }

        public class OneAgency
        {
            public String AgencyId { get; set; }
            public String AgencyName { get; set; }
        }

        public static List<OneAgency> GetAgenciesList(string state, string region, string mapArea, string status)
        {
            var query = new System.Text.StringBuilder(@"SELECT DISTINCT a.name AS AgencyName, a.acID as AgencyId FROM tblProperty tprt INNER JOIN tblAgency a ON tprt.acID = a.acID WHERE tprt.goLive = 0 AND tprt.hideAHC = 0 AND tprt.isWebdisplay=1");
            query.AppendLine();

            //set state in SQL query
            if (String.IsNullOrEmpty(state))
                state = "QLD";

            query.AppendLine(" AND tprt.state = @state");

            //set region in SQL query
            if (!String.IsNullOrEmpty(region))
                query.AppendLine(" AND tprt.suburb IN (SELECT name FROM tblsuburb tsbb WHERE tsbb.region LIKE @region) AND tprt.postcode IN (SELECT postcode FROM tblsuburb tsbb WHERE tsbb.region LIKE @region)");

            //set mapArea in SQL query
            if (!String.IsNullOrEmpty(mapArea))
                query.AppendLine(" AND tprt.suburb IN (SELECT name FROM tblsuburb tsbb WHERE tsbb.maparea LIKE @maparea) AND tprt.postcode IN (SELECT postcode FROM tblsuburb tsbb WHERE tsbb.maparea LIKE @maparea)");

            //set status in SQL query
            if (!String.IsNullOrEmpty(status))
            {
                if (status == "fs")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer', 'Sold') AND tprt.type NOT IN ('Commercial','Business')");
                else if (status == "fr")
                    query.AppendLine(" AND tprt.status IN ('For Rent', 'Rented') AND tprt.type NOT IN ('Commercial','Business')");
                else if (status == "sa")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer') AND tprt.type NOT IN ('Commercial','Business')");
                else if (status == "ra")
                    query.AppendLine(" AND tprt.status IN ('For Rent') AND tprt.type NOT IN ('Commercial','Business')");
                else if (status == "au")
                    query.AppendLine(" AND tprt.priceOption IN ('Auction')");
                else if (status == "po")
                    query.AppendLine(" AND tprt.priceOption IN ('POA')");
                else if (status == "uo")
                    query.AppendLine(" AND tprt.status IN ('Under Offer')");
                else if (status == "so")
                    query.AppendLine(" AND tprt.status IN ('Sold')");
                else if (status == "co")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer', 'Sold') AND tprt.type IN ('Commercial')");
                else if (status == "inv")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer', 'Sold') AND tprt.isInvestment = 1");
                else if (status == "bu")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer', 'Sold') AND tprt.type IN ('Business')");
                else if (status == "ru")
                    query.AppendLine(" AND tprt.status IN ('For Sale', 'Under Offer', 'Sold') AND tprt.type IN ('Acreage/Rural')");
                else if (status == "cr")
                    query.AppendLine(" AND tprt.status IN ('For Rent', 'Rented') AND tprt.type IN ('Commercial')");
                else query.AppendLine(" AND tprt.status IN @status");
            }

            query.AppendLine(" ORDER BY a.name");

            using (var conn = Data.CreateConnection())
            {
                return conn.Query<OneAgency>(query.ToString(),
                    new
                    {
                        state = state,
                        region = region,
                        maparea = mapArea,
                        status = status
                    }).ToList();
            }
        }
    }
}