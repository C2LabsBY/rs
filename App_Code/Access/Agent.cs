using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access
{
    /// <summary>
    /// Summary description for Agent
    /// </summary>
    public class Agent
    {
        public static Entities.Agent GetFromPropertyId(int propertyId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agent>(
                    @"
                    SELECT * FROM tblAgent WHERE aID IN
                    (
                        SELECT COALESCE(aID1, aID2, aID3) AS aID FROM tblProperty WHERE pID = @pID
                    )", new { pID = propertyId }).FirstOrDefault();
            }
        }

        public static Entities.Agent GetFromAgentId(int agentId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Agent>("SELECT * FROM tblAgent WHERE aID = @aID", new { aID = agentId }).FirstOrDefault();
            }
        }

        public static Int32 GetRandomPropertyIdByAgent(int agentId)
        {
            Int32 propertyId = 0;
            using (var conn = Data.CreateConnection())
            {
                var properties = conn.Query<Entities.Property>(
                    @"
                    SELECT * FROM tblProperty 
                    WHERE COALESCE(aID1, aID2, aID3) = @aID AND isWebDisplay = 1 AND hasPhotoSmall = 1", new { aID = agentId });

                int NoOfProp = properties.Count();

                Random RandomClass = new Random();
                int rndNo = RandomClass.Next(NoOfProp);

                if (NoOfProp > 0)
                    propertyId = properties.ToList()[rndNo].pID;
            }
            return propertyId;
        }

        public static List<Entities.Property> GetPropertiesByAgentId(int agentId)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<Entities.Property>(
                    @"
                    SELECT * FROM tblProperty 
                    WHERE COALESCE(aID1, aID2, aID3) = @aID AND golive = 0 and isWebDisplay = 1 and hideahc = 0", new { aID = agentId }).ToList();
            }
        }

        public static IEnumerable<int> GetPropertiesIdByAgentId(int agentId)
        {
            using (var conn = Data.CreateConnection())
            {
                return from p in conn.Query<Entities.Property> (@"
                    SELECT pId FROM tblProperty 
                    WHERE COALESCE(aID1, aID2, aID3) = @aID AND golive = 0 and isWebDisplay = 1 and hideahc = 0", new { aID = agentId })
                       select p.pID;
            }
        }
    }
}