using System;
using REIQ.Access;
using Dapper;
using System.Web;

namespace REIQ.Handlers
{
    public class LogMobilePhoneClick : IHttpHandler
    {
        public LogMobilePhoneClick() { }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string aID = context.Request["aID"];
            string acID = context.Request["acID"];

            using (var conn = Data.CreateConnection())
            {
                //                 IF (SELECT aID from tblLogMobilePhoneClick where (aID = @aID) ) <> '' -- there is an entry  
                //                  UPDATE tblLogMobilePhoneClick SET total = (total + 1) WHERE aID = @aID  
                //                 ELSE -- new entry  
                string query = @"INSERT INTO tblLogMobilePhoneClick (acID,aID,total) VALUES (@acID, @aID, 1)";

                conn.Execute(query, new { acID = acID, aID = aID });
            }
        }
    }
}