using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace REIQ.Handlers
{
    /// <summary>
    /// Takes an input via the "q" querystring parameter and returns a list of matching suburbs
    /// </summary>
    public class SuburbAutoComplete : IHttpHandler
    {
        public SuburbAutoComplete() { }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var q = context.Request.QueryString["q"];
            //Needed to determine what type (Suburbs||Regions||All) was requested
            var type = context.Request.QueryString["type"];

            if (String.IsNullOrWhiteSpace(q))
            {
                return;
            }

            //Getting results depending on what type (Suburbs||Regions||All) was requested
            var results = getResultsByType(q, type); 

            context.Response.ContentType = "application/json";
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            context.Response.Write(new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(results));
        }

        private object getResultsByType(String q, String type)
        {
            var results = Access.Suburb.ListMatching(q);

            switch (type)
            {
                case "suburb": return results.Suburbs.Select(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.name.ToLower()) + ", " + s.postcode).ToList();
                case "region": return results.Regions;
                default:
                    var formatted = new
                    {
                        Suburbs = from s in results.Suburbs select new { name = s.name, region = s.region, postcode = s.postcode },
                        Regions = results.Regions
                    };

                    return formatted;
            }
        }
    }
}