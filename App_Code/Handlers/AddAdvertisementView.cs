using System;
using REIQ.Access;
using Dapper;
using System.Web;

namespace REIQ.Handlers
{
    public class AddAdvertisementView : IHttpHandler
    {
	    public AddAdvertisementView() { }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string adid = context.Request["AdId"];

            using (var conn = Data.CreateConnection())
            {
                string query = @"INSERT INTO tblAdvertisementViews (adid, viewdate) VALUES (@adid, GETDATE())";

                conn.Execute(query, new { adid = adid });
            }
        }
    }
}