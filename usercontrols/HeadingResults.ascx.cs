using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_Heading : System.Web.UI.UserControl
{
    protected override void OnLoad(EventArgs e)
    {        
        String searchstatus = String.Empty;
        String keyword = String.Empty;
        String outputString = String.Empty;
        String type = String.Empty;
        String forAction = String.Empty;
        String location = String.Empty;
        List<String> urlPartsArray = new List<String>();
        String urlParts = String.Empty;

        #region Url rewriting doesn't use
        
        if (!String.IsNullOrEmpty(Request.QueryString["st"]))
        {
            searchstatus = Request.QueryString["st"].ToString();
            //else
            //    searchstatus = "fs";
            if (searchstatus.Equals("Any"))
                searchstatus = "fs";

            //Exclude Sold and rented 
            if (!String.IsNullOrEmpty(Request.QueryString["ex"]))
            {
                if (Request.QueryString["ex"].ToString() == "1")
                {
                    if (searchstatus == "fs")
                        searchstatus = "sa";
                    if (searchstatus == "fr")
                        searchstatus = "ra";
                }
            }

            #region Old way to format heading and content
            //lblsearchheading.Text = "Residential properties for sale";
            //Based on search type assiging other variables
            //switch (searchstatus)
            //{
            //    case "ra":
            //        lblsearchheading.Text = "Residential properties for rent";
            //        forSearchkey.Text = "rent";
            //        break;
            //    case "fr":
            //        lblsearchheading.Text = "Residential properties for rent";
            //        forSearchkey.Text = "rent";
            //        break;
            //    // Commercial Rental Properties
            //    case "cr":
            //        lblsearchheading.Text = "Commercial properties for lease";
            //        forSearchkey.Text = "lease";
            //        break;
            //    // Commercial sales Properties
            //    case "co":
            //        lblsearchheading.Text = "Commercial properties for sale";
            //        forSearchkey.Text = "sale";
            //        break;
            //    // Business sales Properties
            //    case "bu":
            //        lblsearchheading.Text = "Businesses for sale";
            //        forSearchkey.Text = "sale";
            //        break;
            //    // investment sales Properties
            //    case "inv":
            //        lblsearchheading.Text = "Investment Properties for Sale";
            //        forSearchkey.Text = "sale";
            //        break;
            //    case "invso":
            //        lblsearchheading.Text = "Sold Investment properties";
            //        forSearchkey.Text = "investment";
            //        break;
            //    case "au":
            //        lblsearchheading.Text = "Properties for Auction";
            //        forSearchkey.Text = "auction";
            //        break;
            //    // Rural Properties
            //    case "ru":
            //        lblsearchheading.Text = "Rural properties for sale";
            //        forSearchkey.Text = "sale";
            //        break;
            //    // Sale Properties
            //    default:
            //        lblsearchheading.Text = "Residential properties for sale";
            //        forSearchkey.Text = "sale";
            //        break;
            //}
            //if (!String.IsNullOrEmpty(Request.QueryString["txt"]))
            //{
            //    keyword = Request.QueryString["txt"];
            //    if (keyword.Contains("::"))
            //    {
            //        outputString += GetOutputString("::", keyword);
            //    }
            //    else if (keyword.Contains("!!"))
            //    {
            //        outputString += GetOutputString("!!", keyword);
            //    }
            //    else if (Regex.Match(keyword, "(.*), (4\\d{3})").Success)
            //    {
            //        outputString += " in suburb \"" + keyword + "\"";
            //    }
            //    else outputString += " by keyword \"" + keyword + "\"";
            //}

            //keyWord.Text = outputString;
            #endregion

            //property type selected
            if (!String.IsNullOrEmpty(Request.QueryString["ty"]))
            {
                type = Request.QueryString["ty"].ToLower().Trim();
            }

            //get property status (for action)
            forAction = GetForAction(searchstatus, type, false);

            //format type
            type = FormatTypeForHeading(searchstatus, type);

            //txt parameter specified
            if (!String.IsNullOrEmpty(Request.QueryString["txt"]) && Request.QueryString["txt"] != REIQ.usercontrols.PropertySearchBase.DefaultSearchText)
            {
                keyword = Request.QueryString["txt"];
            }

            //search region or suburb in querystring 
            if (!String.IsNullOrEmpty(type)) location = REIQ.Access.Suburb.TryGetSuburbOrRegionFromSearchstring(keyword);

            lblsearchheading.Text = FormatHeadingH1(type, searchstatus, forAction, location);

            lblSearchHeadingContent.Text = FormatHeadingContent(type, searchstatus, forAction, location);
        }
        #endregion
        #region Url rewriting use
        else
        {
            string region = String.Empty;
            string suburb = String.Empty;

            urlPartsArray = Request.RawUrl.ToString().ToLower().Trim('/').Split('/').ToList();

            //commercial property (+1 url part)
            if (urlPartsArray[0].ToString().Contains("commercial"))
            {
                if (urlPartsArray.Count == 2)
                {
                    urlParts = urlPartsArray[1];
                }
                if (urlPartsArray.Count == 3)
                {
                    urlParts = urlPartsArray[1];
                    region = urlPartsArray[2];
                }
                else if (urlPartsArray.Count == 4)
                {
                    urlParts = urlPartsArray[1];
                    suburb = urlPartsArray[3];
                }
            }
            else
            {
                //no keywords were specified
                if (urlPartsArray.Count == 1)
                {
                    urlParts = urlPartsArray[0];
                }
                //region search
                if (urlPartsArray.Count == 2)
                {
                    urlParts = urlPartsArray[0];
                    region = urlPartsArray[1];
                }
                //suburb search
                else if (urlPartsArray.Count == 3)
                {
                    urlParts = urlPartsArray[0];
                    suburb = urlPartsArray[2];
                }
            }

            //get for Action
            forAction = GetForAction(null, urlParts, true);

            List<REIQ.Entities.Suburb> allLocations = REIQ.Access.Suburb.GetAlllocations();

            if (!String.IsNullOrEmpty(suburb))
            {
                List<string> suburbParts = suburb.Split('-').ToList();

                foreach (var s in allLocations)
                {
                    for (var i = 0; i < suburbParts.Count; i++)
                    {
                        if (!s.name.ToLower().Contains(suburbParts[i])) break;
                        else if (i == suburbParts.Count-1)
                        {
                            location = s.name + ", " + s.postcode;
                        }
                    }
                    if (!String.IsNullOrEmpty(location)) break;
                }
            }
            else if (!String.IsNullOrEmpty(region))
            {
                List<string> regionParts = region.Split('-').ToList();

                foreach (var r in allLocations)
                {
                    for (var i = 0; i < regionParts.Count; i++)
                    {
                        if (!r.region.ToLower().Contains(regionParts[i])) break;
                        else if (i == regionParts.Count - 1)
                        {
                            location = r.region;
                        }
                    }
                    if (!String.IsNullOrEmpty(location)) break;
                }
            }

            //get type of property
            if (urlPartsArray[0].ToString().Contains("commercial")) type = GetPropertyType(urlParts, "search", true);
            else type = GetPropertyType(urlParts, "search", false);
            //format meta title
            lblsearchheading.Text = FormatHeadingH1(type, null, forAction, location);

            lblSearchHeadingContent.Text = FormatHeadingContentUrlRewrited(type, forAction, location);
        }
        #endregion
        base.OnLoad(e);
    }

    protected string GetPropertyType(string type, string pageType, bool isCommercial)
    {
        String gotType = String.Empty;

        if (type.Contains("property") && !isCommercial) gotType = "Residential Property";
        else if (type.Contains("property") && isCommercial) gotType = "Commercial Real Estate - Property";

        if (type.Contains("house") && !type.Contains("town"))
        {
            if (pageType == "search") gotType = "Houses";
            else gotType = "House";
        }
        if (type.Contains("apartments"))
        {
            if (pageType == "search") gotType = "Apartments & Units";
            else gotType = "Apartment & Unit";
        }
        if (type.Contains("block")) gotType = "Block of Units";
        if (type.Contains("house") && type.Contains("town")) gotType = "Villas & Townhouses";
        if (type.Contains("rural"))
        {
            if (pageType == "search") gotType = "Rural Properties";
            else gotType = "Rural Property";
        }
        if (type.Contains("land")) gotType = "Land";
        if (type.Contains("rental")) gotType = "Residential Rental Properties";
        if (type.Contains("business")) gotType = "Business";

        return gotType;
    }

    protected string FormatHeadingH1(string type, string status, string forAction, string location)
    {
        String formattedHeadingH1 = String.Empty;

        formattedHeadingH1 = type + " ";

        if (type.ToLower().Contains("rental")) forAction = String.Empty;

        if (!String.IsNullOrEmpty(forAction)) formattedHeadingH1 += "for " + forAction + " ";
        
        formattedHeadingH1 += location;

        return formattedHeadingH1;
    }

    protected string GetForAction(string status, string type, bool isUrlRewrited)
    {
        String forAction = String.Empty;

        if (!isUrlRewrited)
        {
            forAction = String.Empty;
            //buy or business or rural or commercial for sale
            if (status == "sa" || status == "bu" || status == "ru" || status == "co") forAction = "Sale";
            //rent
            if (status == "ra" && !String.IsNullOrEmpty(type) && type.Contains("land")) forAction = "Lease";
            else if (status == "ra" && !String.IsNullOrEmpty(type) && !type.Contains("land")) forAction = "Rent";
            else if (status == "ra" && String.IsNullOrEmpty(type)) forAction = "";
            //commercial for lease
            if (status == "cr") forAction = "Lease";
        }
        else
        {
            if (type.Contains("sale")) forAction = "Sale";
            if (type.Contains("rent")) forAction = "Rent";
            if (type.Contains("lease")) forAction = "Lease";
        }

        return forAction;
    }

    protected string FormatTypeForHeading(string status, string type)
    {
        if (status == "sa" || status == "ra")
        {
            if (!String.IsNullOrEmpty(type))
            {
                if (type.Contains("house") && !type.Contains("town")) type = "Houses";
                else if (type.Contains("apartment")) type = "Apartments & Units";
                else if (type.Contains("block")) type = "Block of Units";
                else if (type.Contains("villa")) type = "Villas & Townhouses";
                else if (type.Contains("rural")) type = "Rural Properties";
                else if (type.Contains("land")) type = "Land";
            }
            else
            {
                if (status == "sa") type = "Residential Property";
                if (status == "ra") type = "Residential Rental Properties";
            }
        }

        if (status == "co" || status == "cr") type = "Commercial Real Estate - Property";
        if (status == "bu") type = "Business";
        if (status == "ru") type = "Rural Properties";

        return type;
    }

    protected string FormatHeadingContent(string type, string status, string forAction, string location)
    {
        String formattedMetaDescription = String.Empty;

        type = type.ToLower();

        if (status == "co" || status == "cr") formattedMetaDescription = ContentTexts(location, "commercial", forAction);
        else if (status == "bu") formattedMetaDescription = ContentTexts(location, "business", forAction);
        else if (status == "ru") formattedMetaDescription = ContentTexts(location, "rural", forAction);
        else if (status == "sa" || status == "ra")
        {
            if (type.Contains("property")) formattedMetaDescription = ContentTexts(location, "property", forAction);
            else if (type.Contains("rental")) formattedMetaDescription = ContentTexts(location, "rental", forAction);
            else if (type.Contains("villa")) formattedMetaDescription = ContentTexts(location, "villa", forAction);
            else if (type.Contains("house")) formattedMetaDescription = ContentTexts(location, "house", forAction);
            else if (type.Contains("apartment")) formattedMetaDescription = ContentTexts(location, "apartment", forAction);
            else if (type.Contains("block")) formattedMetaDescription = ContentTexts(location, "block", forAction);
            else if (type.Contains("rural")) formattedMetaDescription = ContentTexts(location, "acreage", forAction);
            else if (type.Contains("land")) formattedMetaDescription = ContentTexts(location, "land", forAction);
        }

        return formattedMetaDescription;
    }

    protected string FormatHeadingContentUrlRewrited(string type, string forAction, string location)
    {
        String formattedMetaDescription = String.Empty;

        type = type.ToLower();

        if (type.Contains("commercial")) formattedMetaDescription = ContentTexts(location, "commercial", forAction);
        else if (type.Contains("business")) formattedMetaDescription = ContentTexts(location, "business", forAction);
        else if (type.Contains("rural") && !type.Contains("acreage")) formattedMetaDescription = ContentTexts(location, "rural", forAction);
        else if (type.Contains("property") || type.Contains("rental")) formattedMetaDescription = ContentTexts(location, "property", forAction);
        else if (type.Contains("house") && !type.Contains("town")) formattedMetaDescription = ContentTexts(location, "house", forAction);
        else if (type.Contains("house") && type.Contains("town")) formattedMetaDescription = ContentTexts(location, "villa", forAction);
        else if (type.Contains("apartment")) formattedMetaDescription = ContentTexts(location, "apartment", forAction);
        else if (type.Contains("block")) formattedMetaDescription = ContentTexts(location, "block", forAction);
        else if (type.Contains("villa")) formattedMetaDescription = ContentTexts(location, "villa", forAction);
        else if (type.Contains("acreage")) formattedMetaDescription = ContentTexts(location, "acreage", forAction);
        else if (type.Contains("land")) formattedMetaDescription = ContentTexts(location, "land", forAction);

        return formattedMetaDescription;
    }

    protected string ContentTexts(string location, string propertyType, string propertyStatus)
    {
        String content = String.Empty;

        propertyStatus = propertyStatus.ToLower();

        if (!String.IsNullOrEmpty(location)) location = "in " + location + " ";

        if (propertyType == "commercial")
            content = "Browse through commercial real estate and commercial property for " + propertyStatus + " " + location + "listed exclusively by REIQ accredited agents.";
        else if (propertyType == "business")
            content = "Results for business for " + propertyStatus + " " + location + "listed exclusively by REIQ accredited agents.";
        else if (propertyType == "rural")
        {
            if (propertyStatus == "sale")
                content = "Discover rural properties for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find rural properties for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "property" || propertyType == "rental")
        {
            if (propertyStatus == "sale")
                content = "Discover residential property for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find residential rental properties " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "house")
        {
            if (propertyStatus == "sale")
                content = "Discover houses for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find houses for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "apartment")
        {
            if (propertyStatus == "sale")
                content = "Discover apartments & units for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find apartments & units for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "block")
        {
            if (propertyStatus == "sale")
                content = "Discover block of units for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find block of units for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "villa")
        {
            if (propertyStatus == "sale")
                content = "Discover villas & townhouses for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find villas & townhouses for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "acreage")
        {
            if (propertyStatus == "sale")
                content = "Discover rural properties for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find rural properties for rent " + location + "listed exclusively by REIQ accredited agents.";
        }
        else if (propertyType == "land")
        {
            if (propertyStatus == "sale")
                content = "Discover vacant land for sale " + location + "listed exclusively by REIQ accredited agents.";
            else content = "Find vacant land for lease " + location + "listed exclusively by REIQ accredited agents.";
        }

        return content;
    }

    public String GetOutputString(String sep, string keyword)
    {
        String str = String.Empty;
        String[] listItems;
        listItems = keyword.Split(new string[] { sep }, StringSplitOptions.None);

        if (sep == "::") str += " in regions ";
        if (sep == "!!") str += " in suburbs ";

        for (var i = 0; i < listItems.Length; i++)
        {
            if (i < listItems.Length - 1) str += "\"" + listItems[i] + "\", ";
            else str += "\"" + listItems[i] + "\"";
        }
        return str;
    }
}