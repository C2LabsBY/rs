using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace REIQ.Handlers
{
    /// <summary>
    /// gets search form parameters, builds seo url (if needed) and makes redirection to Search Results page
    /// </summary>
    public class BuildSearchSeoUrl : IHttpHandler
    {
        public BuildSearchSeoUrl()
        {
            //
            // TODO: добавьте логику конструктора
            //
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            String searchResultsUrl = "/results";
            String urlParameters = context.Request.RawUrl.Replace("/BuildSearchSeoUrl.ashx/?", "").Replace("/BuildSearchSeoUrl.ashx?", "").Replace("/BuildSearchSeoUrl.ashx", "");
            String suburbOrRegion = String.Empty;
            String status = String.Empty;
            String type = String.Empty;
            String forAction = String.Empty;
            String suburb = String.Empty;
            String region = String.Empty;

            if (!String.IsNullOrEmpty(context.Request.QueryString["txt"]) && context.Request.QueryString["txt"] != REIQ.usercontrols.PropertySearchBase.DefaultSearchText && !String.IsNullOrEmpty(context.Request.QueryString["st"]))
            {
                //first of all check in only one property type was selected
                if (!String.IsNullOrEmpty(context.Request.QueryString["ty"]))
                {
                    type = context.Request.QueryString["ty"].ToLower().Trim();

                    //redirection to general search results page 'couse more than 1 property type was selected
                    if (type.Split(',').Length > 1) context.Response.Redirect(searchResultsUrl + "?" + urlParameters);                    
                }
                //also if no one property type was selected and search type not commercial - make redirection to general search results page too
                else
                {
                    if (!("co,cr").Contains(context.Request.QueryString["st"]))
                        context.Response.Redirect(searchResultsUrl + "?" + urlParameters);
                }                

                //before continue try to determine if region or suburb contains in query string 
                suburbOrRegion = REIQ.Access.Suburb.TryGetSuburbOrRegionFromSearchstring(context.Request.QueryString["txt"]);
                //leave to normal results page if nothing found
                if (String.IsNullOrEmpty(suburbOrRegion)) context.Response.Redirect(searchResultsUrl + "?" + urlParameters);

                //what have we found?
                var match = Regex.Match(suburbOrRegion, "(.*), (4\\d{3})");
                //suburb was found. Try to found a region then.
                if (match.Success)
                {
                    var su = match.Groups[1].Value;
                    var pc = Convert.ToInt32(match.Groups[2].Value);
                    suburb = su.ToLower();
                    region = REIQ.Access.Suburb.Get(su, pc).region.ToLower();
                }
                //region was found
                else region = suburbOrRegion.ToLower();

                if (!String.IsNullOrEmpty(region)) region = REIQ.Helpers.PropertyHelper.PrepareUrlParts(region);
                else context.Response.Redirect(searchResultsUrl + "?" + urlParameters);

                if (!String.IsNullOrEmpty(suburb)) suburb = REIQ.Helpers.PropertyHelper.PrepareUrlParts(suburb);                

                status = context.Request.QueryString["st"];

                //Exclude Sold and rented 
                if (!String.IsNullOrEmpty(context.Request.QueryString["ex"]))
                {
                    if (context.Request.QueryString["ex"].ToString() == "1")
                    {
                        if (status == "fs")
                            status = "sa";
                        if (status == "fr")
                            status = "ra";
                    }
                }
                //only one property type was selected               
                type = REIQ.Helpers.PropertyHelper.PrepareType(type, status, null);

                //get "for" action (for Sale / Lease / Rent)
                forAction = GetForAction(status, type);
                
                //build seo url
                searchResultsUrl = "/" + type;
                if (type.Contains("sale") || type.Contains("lease") || type == "rental-properties")
                {
                    searchResultsUrl += "/";
                }
                else
                {
                    if (!String.IsNullOrEmpty(forAction)) searchResultsUrl += "-for-" + forAction + "/";
                }

                //add region to url
                searchResultsUrl += region + "/";
                
                //add suburb to url
                if (!String.IsNullOrEmpty(suburb)) searchResultsUrl += "/" + suburb + "/";
            }
            
            context.Response.Redirect(searchResultsUrl + "?" + urlParameters);
        }        

        protected string GetForAction(string status, string type)
        {
            String forAction = String.Empty;

            //buy or business or rural or commercial for sale
            if (status == "sa" || status == "bu" || status == "ru" || status == "co") forAction = "sale";
            //rent
            if (status == "ra" && !String.IsNullOrEmpty(type) && type.Contains("land")) forAction = "lease";
            else if (status == "ra" && !String.IsNullOrEmpty(type) && !type.Contains("land")) forAction = "rent";
            else if (status == "ra" && String.IsNullOrEmpty(type)) forAction = "";
            //commercial for lease
            if (status == "cr") forAction = "lease";

            if (type == "rental-properties") forAction = String.Empty;

            return forAction;
        }        
    }
}