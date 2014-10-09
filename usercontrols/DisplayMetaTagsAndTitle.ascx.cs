using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_DisplayMetaTagsAndTitle : REIQ.usercontrols.PropertySearchBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var currentNode = umbraco.NodeFactory.Node.GetCurrent();
        
        if (currentNode != null)
        {
            String type = String.Empty;
            String keyword = String.Empty;
            String address = String.Empty;
            String status = String.Empty;
            String urlParts = String.Empty;
            String outputMetaTitle = String.Empty;
            String outputMetaDescription = String.Empty;
            String suburbOrRegion = String.Empty;
            String forAction = String.Empty;
            List<String> urlPartsArray = new List<String>();
            String region = String.Empty;
            String suburb = String.Empty;
            string location = string.Empty;

            #region Property Details
            //Set meta tags            
            if (currentNode.NodeTypeAlias.ToString() == "IframePropertyDetails" || currentNode.NodeTypeAlias.ToString() == "PropertyDetail")
            {   
                if (!String.IsNullOrEmpty(Request.QueryString["pid"].ToString()))
                {
                    //Get property
                    REIQ.Entities.Property property = REIQ.Access.Property.GetFromPropertyId(Convert.ToInt32(Request.QueryString["pid"]));
                    if (property != null)
                    {
                        //Make property address
                        address = REIQ.Helpers.PropertyHelper.GetAddress(property);
                        string ty = Request.QueryString["ty"];
                        //Prepare type of property
                        urlParts = Request.RawUrl.ToString().ToLower().TrimStart('/').Split('/').ToList()[0];
                        if (urlParts.Contains("house") && !urlParts.Contains("town")) type = "House ";
                        else if (urlParts.Contains("land")) type = "Land ";
                        else if (urlParts.Contains("apartment")) type = "Apartment & Unit ";
                        else if (urlParts.Contains("block")) type = "Block of Units ";
                        else if (urlParts.Contains("town")) type = "Villa & Townhouse ";
                        else if (urlParts.Contains("business")) type = "Business ";
                        else if (urlParts.Contains("rural")) type = "Rural Property ";
                        else if (urlParts.Contains("commercial"))
                        {
                            type = "Commercial Property for ";
                            string urlPartsCommercial = Request.RawUrl.ToString().ToLower().TrimStart('/').Split('/').ToList()[1];
                            if (urlPartsCommercial.Contains("sale")) status += "Sale ";
                            if (urlPartsCommercial.Contains("lease")) status += "Lease ";
                        }

                        //Prepare status of property
                        if (!urlParts.Contains("commercial"))
                        {
                            if (urlParts.Contains("sale")) status += "for Sale ";
                            if (urlParts.Contains("rent")) status += "for Rent ";
                            if (urlParts.Contains("lease")) status += "for Lease ";
                            if (urlParts.Contains("offer")) status += "under Offer ";
                        }

                        //add additional "hypen" sign for commercial and business properties
                        if (urlParts.Contains("business") || urlParts.Contains("commercial")) status += "- ";

                        //Output meta title tag
                        if (!String.IsNullOrEmpty(type) && !String.IsNullOrEmpty(status) && !String.IsNullOrEmpty(address))
                        {
                            outputMetaTitle = type + status + address + " | REIQ";
                            //MetaTitle.Text = "<meta name='title' content='" + outputMetaTitle + "' />"; 
                            MetaTitle.Text = "<title>" + outputMetaTitle + "</title>";
                        }

                        //Output meta description tag
                        if (!String.IsNullOrEmpty(property.descriptionLong))
                        {
                            if (property.descriptionLong.Length > 156)
                            {
                                MetaDescription.Text = "<meta name='description' content='" + property.descriptionLong.Substring(0, 156) + "' />";
                            }
                            else
                            {
                                MetaDescription.Text = "<meta name='description' content='" + property.descriptionLong + "' />";
                            }
                        }
                        else if (!String.IsNullOrEmpty(property.descriptionShort))
                        {
                            if (property.descriptionShort.Length > 156)
                            {
                                MetaDescription.Text = "<meta name='description' content='" + property.descriptionShort.Substring(0, 156) + "' />";
                            }
                            else
                            {
                                MetaDescription.Text = "<meta name='description' content='" + property.descriptionShort + "' />";
                            }
                        }
                    }
                }
            }
            #endregion

            #region Search Results
            else if (currentNode.NodeTypeAlias.ToString() == "SearchResults" || currentNode.NodeTypeAlias.ToString() == "IframeListings")
            {
                #region Url rewriting doesn't use
                //bool test = false;
                //if (test)
                if (!String.IsNullOrEmpty(Request.QueryString["st"]))
                {
                    status = Request.QueryString["st"];

                    //Exclude Sold and rented 
                    if (!String.IsNullOrEmpty(Request.QueryString["ex"]))
                    {
                        if (Request.QueryString["ex"].ToString() == "1")
                        {
                            if (status == "fs")
                                status = "sa";
                            if (status == "fr")
                                status = "ra";
                        }
                    }

                    //property type selected
                    if (!String.IsNullOrEmpty(Request.QueryString["ty"]))
                    {
                        type = Request.QueryString["ty"].ToLower().Trim();
                    }

                    //determine for which action property is intended 
                    forAction = GetForAction(status, type, false);

                    //format type
                    if (!String.IsNullOrEmpty(type) && type.Split(',').Length > 1)
                    {
                        type = String.Empty;
                    }
                    
                    type = FormatTypeForMetaTitle(status, type, "search");

                    //txt parameter specified
                    if (!String.IsNullOrEmpty(Request.QueryString["txt"]) && Request.QueryString["txt"] != REIQ.usercontrols.PropertySearchBase.DefaultSearchText)
                    {
                        keyword = Request.QueryString["txt"];
                    }

                    //search region or suburb in querystring 
                    if (!String.IsNullOrEmpty(type)) suburbOrRegion = REIQ.Access.Suburb.TryGetSuburbOrRegionFromSearchstring(keyword);

                    //format meta title
                    outputMetaTitle = FormatMetaTitle(type, status, forAction, suburbOrRegion, null);
                    //display meta title
                    //MetaTitle.Text = "<meta name='title' content='" + outputMetaTitle + "' />";
                    MetaTitle.Text = "<title>" + outputMetaTitle + "</title>";

                    //format meta description
                    outputMetaDescription = FormatMetaDescription(type, status, forAction, suburbOrRegion);
                    //display meta description
                    MetaDescription.Text = "<meta name='description' content='" + outputMetaDescription + "' />";
                }
                #endregion
                #region Url rewriting use
                else
                {
                    //string testString = "property-for-sale/brisbane-eastern-suburbs";
                    //string testString = "property-for-sale/brisbane-eastern-suburbs/yam-island";
                    //string testString = "business-for-sale/brisbane-eastern-suburbs/yam-island";
                    //string testString = "land-for-lease/brisbane-cbd/yam-island";            
                    //string testString = "rental-properties/brisbane-eastern-suburbs";
                    //string testString = "rental-properties/brisbane-eastern-suburbs/yam-island";
                    //string testString = "rural-properties-for-sale/brisbane-eastern-suburbs";
                    //string testString = "rural-properties-for-sale/"; 
                    //string testString = "commercial-real-estate/property-for-lease/brisbane-eastern-suburbs";
                    //string testString = "commercial-real-estate/property-for-lease/brisbane-eastern-suburbs/yam-island";

                    //urlPartsArray = testString.ToLower().Trim('/').Split('/').ToList();
                    urlPartsArray = Request.RawUrl.ToString().ToLower().TrimStart('/').Split('/').ToList();

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

                    //get location
                    if (!urlPartsArray[0].ToString().Contains("commercial") && urlPartsArray.Count > 1 || urlPartsArray[0].ToString().Contains("commercial") && urlPartsArray.Count > 2)
                    {
                        List<REIQ.Entities.Suburb> allLocations = REIQ.Access.Suburb.GetAlllocations();

                        if (!String.IsNullOrEmpty(suburb))
                        {
                            List<string> suburbParts = suburb.Split('-').ToList();

                            foreach (var s in allLocations)
                            {
                                for (var i = 0; i < suburbParts.Count; i++)
                                {
                                    if (!s.name.ToLower().Contains(suburbParts[i])) break;
                                    else if (i == suburbParts.Count - 1)
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
                    }

                    //get type of property
                    if (urlPartsArray[0].ToString().Contains("commercial")) type = GetPropertyType(urlParts, "search", true);
                    else type = GetPropertyType(urlParts, "search", false);

                    //format meta title
                    if (urlPartsArray[0].ToString().Contains("commercial")) outputMetaTitle = FormatMetaTileUrlRewrited(type, forAction, location, true);
                    else outputMetaTitle = FormatMetaTileUrlRewrited(type, forAction, location, false);
                    //display meta title
                    //MetaTitle.Text = "<meta name='title' content='" + outputMetaTitle + "' />";
                    MetaTitle.Text = "<title>" + outputMetaTitle + "</title>";

                    //format meta description
                    outputMetaDescription = FormatMetaDescriptionUrlRewrited(type, forAction, location);
                    //display meta description
                    MetaDescription.Text = "<meta name='description' content='" + outputMetaDescription + "' />";
                }
                #endregion
            }
            #endregion
            else
            {
                if (currentNode.GetProperty("metaDescription") != null && !String.IsNullOrEmpty(currentNode.GetProperty("metaDescription").Value))
                    MetaDescription.Text = "<meta name='description' content='" + currentNode.GetProperty("metaDescription").Value + "' />";
                if (currentNode.GetProperty("metaKeywords") != null && !String.IsNullOrEmpty(currentNode.GetProperty("metaKeywords").Value))
                    MetaKeywords.Text = "<meta name='keywords' content='" + currentNode.GetProperty("metaKeywords").Value + "' />";
                if (currentNode.GetProperty("seoTitle") != null)
                    MetaTitle.Text = "<title>" + currentNode.GetProperty("seoTitle").Value + "</title>";
                else MetaTitle.Text = "<title>" + currentNode.GetProperty("PageName").Value + "</title>";
            }
        }
    }

    protected string GetPropertyType(string type, string pageType, bool isCommercial)
    {
        String gotType = String.Empty;

        if (type.Contains("property") && !isCommercial) gotType = "Property";
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
        if (type.Contains("rental")) gotType = "Rental Properties";
        if (type.Contains("business")) gotType = "Business";        

        return gotType;
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

    protected string FormatTypeForMetaTitle(string status, string type, string pageType)
    {
        if (status == "sa" || status == "ra")
        {
            if (!String.IsNullOrEmpty(type))
            {
                if (type.Contains("house") && !type.Contains("town"))
                {
                    if (pageType == "search") type = "Houses";
                    else type = "House";
                }
                else if (type.Contains("apartment"))
                {
                    if (pageType == "search") type = "Apartments & Units";
                    else type = "Apartment & Unit";
                }
                else if (type.Contains("block"))
                {
                    type = "Block of Units";
                }
                else if (type.Contains("villa"))
                {
                    if (pageType == "search") type = "Villas & Townhouses";
                    else type = "Villa & Townhouse";
                }
                else if (type.Contains("rural"))
                {
                    if (pageType == "search") type = "Rural Properties";
                    else type = "Rural Property";
                }
                else if (type.Contains("land"))
                {
                    type = "Land";
                }
            }
            else
            {
                if (status == "sa") type = "Property";
                if (status == "ra") type = "Rental Properties";
            }
        }

        if (status == "co" || status == "cr")
        {
            if (pageType == "search") type = "Commercial Real Estate - Property";
            else type = "Commercial Property";
        }

        if (status == "bu") type = "Business";

        if (status == "ru")
        {
            if (pageType == "search") type = "Rural Properties";
            else type = "Rural Property";
        }

        return type;
    }

    protected string FormatMetaTitle(string type, string status, string forAction, string suburbOrRegion, string address)
    {
        String formattedMetaTitle = String.Empty;

        formattedMetaTitle = type + " "; ;

        type = type.ToLower();

        if (type.ToLower().Contains("rental")) forAction = String.Empty;

        if (!String.IsNullOrEmpty(forAction)) formattedMetaTitle += "for " + forAction + " ";

        if (!String.IsNullOrEmpty(suburbOrRegion)) formattedMetaTitle += suburbOrRegion + " ";

        if (!String.IsNullOrEmpty(address)) formattedMetaTitle += address + " ";

        if (status == "sa" && type.ToLower().Contains("property") || (status == "sa" && type.ToLower().Contains("house") && !type.ToLower().Contains("town"))) formattedMetaTitle += "- Search ";
        if (status == "ra" && type.ToLower().Contains("rental") || (status == "ra" && type.ToLower().Contains("house") && !type.ToLower().Contains("town"))) formattedMetaTitle += "- Search ";
        if (type.ToLower().Contains("land")) formattedMetaTitle += "- Real Estate QLD ";

        formattedMetaTitle += "| REIQ";

        return formattedMetaTitle;
    }

    protected string FormatMetaTileUrlRewrited(string type, string forAction, string location, bool isComercial)
    {
        String formattedMetaTitle = String.Empty;

        formattedMetaTitle = type + " "; ;

        type = type.ToLower();

        if (type.ToLower().Contains("rental")) forAction = String.Empty;

        if (!String.IsNullOrEmpty(forAction)) formattedMetaTitle += "for " + forAction + " ";

        if (!String.IsNullOrEmpty(location)) formattedMetaTitle += location + " ";

        if (!isComercial && type.Contains("property") || (type.Contains("house") && !type.Contains("town")) || type.Contains("rental")) formattedMetaTitle += "- Search ";
        if (type.Contains("land")) formattedMetaTitle += "- Real Estate QLD ";

        formattedMetaTitle += "| REIQ";

        return formattedMetaTitle;
    }

    protected string FormatMetaDescription(string type, string status, string forAction, string location)
    {
        String formattedMetaDescription = String.Empty;

        type = type.ToLower();

        if (status == "co" || status == "cr") formattedMetaDescription = MetaDescriptionTexts(location, "commercial", forAction);
        else if (status == "bu") formattedMetaDescription = MetaDescriptionTexts(location, "business", forAction);
        else if (status == "ru") formattedMetaDescription = MetaDescriptionTexts(location, "rural", forAction);
        else if (status == "sa" || status == "ra")
        {
            if (type.Contains("property")) formattedMetaDescription = MetaDescriptionTexts(location, "property", forAction);
            else if (type.Contains("rental")) formattedMetaDescription = MetaDescriptionTexts(location, "rental", forAction);
            else if (type.Contains("villa")) formattedMetaDescription = MetaDescriptionTexts(location, "villa", forAction);
            else if (type.Contains("house")) formattedMetaDescription = MetaDescriptionTexts(location, "house", forAction);
            else if (type.Contains("apartment")) formattedMetaDescription = MetaDescriptionTexts(location, "apartment", forAction);
            else if (type.Contains("block")) formattedMetaDescription = MetaDescriptionTexts(location, "block", forAction);
            else if (type.Contains("rural")) formattedMetaDescription = MetaDescriptionTexts(location, "acreage", forAction);
            else if (type.Contains("land")) formattedMetaDescription = MetaDescriptionTexts(location, "land", forAction);
        }

        return formattedMetaDescription;
    }

    protected string FormatMetaDescriptionUrlRewrited(string type, string forAction, string location)
    {
        String formattedMetaDescription = String.Empty;

        type = type.ToLower();

        if (type.Contains("commercial")) formattedMetaDescription = MetaDescriptionTexts(location, "commercial", forAction);
        else if (type.Contains("business")) formattedMetaDescription = MetaDescriptionTexts(location, "business", forAction);
        else if (type.Contains("rural") && !type.Contains("acreage")) formattedMetaDescription = MetaDescriptionTexts(location, "rural", forAction);
        else if (type.Contains("property") || type.Contains("rental")) formattedMetaDescription = MetaDescriptionTexts(location, "property", forAction);
        else if (type.Contains("house") && !type.Contains("town")) formattedMetaDescription = MetaDescriptionTexts(location, "house", forAction);
        else if (type.Contains("house") && type.Contains("town")) formattedMetaDescription = MetaDescriptionTexts(location, "villa", forAction);
        else if (type.Contains("apartment")) formattedMetaDescription = MetaDescriptionTexts(location, "apartment", forAction);
        else if (type.Contains("block")) formattedMetaDescription = MetaDescriptionTexts(location, "block", forAction);
        else if (type.Contains("villa")) formattedMetaDescription = MetaDescriptionTexts(location, "villa", forAction);
        else if (type.Contains("acreage")) formattedMetaDescription = MetaDescriptionTexts(location, "acreage", forAction);
        else if (type.Contains("land")) formattedMetaDescription = MetaDescriptionTexts(location, "land", forAction);

        return formattedMetaDescription;
    }

    protected string MetaDescriptionTexts(string location, string propertyType, string propertyStatus)
    {
        String description = String.Empty;

        propertyStatus = propertyStatus.ToLower();

        if (!String.IsNullOrEmpty(location)) location = "in " + location + " ";

        if (propertyType == "commercial")
            description = "Browse through commercial real estate and commercial property for " + propertyStatus + " " + location + "listed exclusively by REIQ accredited agents.";
        else if (propertyType == "business")
            description = "Results for business for " + propertyStatus + " " + location + "listed exclusively by REIQ accredited agents.";
        else if (propertyType == "rural")
        {
            if (propertyStatus == "sale")
                description = "Discover rural properties for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find rural properties for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";

        }
        else if (propertyType == "property" || propertyType == "rental")
        {
            if (propertyStatus == "sale")
                description = "Discover residential property for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find residential rental properties " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "house")
        {
            if (propertyStatus == "sale")
                description = "Discover houses for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find houses for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "apartment")
        {
            if (propertyStatus == "sale")
                description = "Discover apartments & units for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find apartments & units for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "block")
        {
            if (propertyStatus == "sale")
                description = "Discover block of units for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find block of units for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "villa")
        {
            if (propertyStatus == "sale")
                description = "Discover villas & townhouses for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find villas & townhouses for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "acreage")
        {
            if (propertyStatus == "sale")
                description = "Discover rural properties for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find rural properties for rent " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }
        else if (propertyType == "land")
        {
            if (propertyStatus == "sale")
                description = "Discover vacant land for sale " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
            else description = "Find vacant land for lease " + location + "listed exclusively by REIQ accredited agents. REIQ - The home of real estate in QLD.";
        }

        return description;
    }
}