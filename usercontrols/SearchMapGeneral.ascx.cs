using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SearchMapGeneral : REIQ.usercontrols.PropertySearchBase
{
    //public REIQ ahc = new REIQ();

    //Here you can specify the hadler of the form (handler "BuildSearchSeoUrl.ashx" or "results" page)
    protected String SearchResultsUrl = "BuildSearchSeoUrl.ashx";
    //protected whereToSumbitForm = "results";

    public showproperty prop = new showproperty();
    public string searchstatus;
    public string searchmaps;
    public string statestring, strFileName, txtTitle, ser;
    public string searchstatusForscript = "fs";
    public DataTable dtFeature;
    public string regionurl = "";
    public string regionlist = "";
    public string flagrent = "";
    public string searchtextDefault = REIQ.usercontrols.PropertySearchBase.DefaultSearchText;

    protected void Page_Load(object sender, EventArgs e)
    {
        #region Get parameters from query string

        //get "map" parameter from querystring and set visibility of different maps
        if (!String.IsNullOrEmpty(Request.QueryString["map"]))
        {
            if (Request.QueryString["map"] == "seqld")
            {
                Qld.Visible = false;
                Brisbane.Visible = false;
                SouthEast.Visible = true;
            }
            else if (Request.QueryString["map"] == "brisbane")
            {
                Qld.Visible = false;
                Brisbane.Visible = true;
                SouthEast.Visible = false;
            }
            else
            {
                Qld.Visible = true;
                Brisbane.Visible = false;
                SouthEast.Visible = false;
            }
        }
        else
        {
            Qld.Visible = true;
            Brisbane.Visible = false;
            SouthEast.Visible = false;
        }

        //get "st" and "ser" parameters and set region url
        if (!String.IsNullOrEmpty(Request.QueryString["st"]))
            regionurl = Request.Path.ToString() + "?st=" + Request.QueryString["st"];
        else
            regionurl = Request.Path.ToString() +"?st=fs";

        if (!String.IsNullOrEmpty(Request.QueryString["ser"]))
            regionurl += "&ser=" + Request.QueryString["ser"];

        //get or set (if not exists) "state" parameter from session
        if (Session["state"] == null)
        {
            Session["state"] = "QLD";
        }
        //to place text into the title
        statestring = "QLD";

        //get and set "st" parameter
        if (String.IsNullOrEmpty(Request.QueryString["st"]))
            searchstatus = "fs";
        else
            searchstatus = Request.QueryString["st"];

        //check if it's "map" or "text" search
        if (String.IsNullOrEmpty(Request.QueryString["ser"]))
            ser = "text";
        else
            ser = Request.QueryString["ser"];
        
        #endregion

        if (!IsPostBack)
        {
            searchtext.Text = searchtextDefault;

            #region Additional search variables based on search status. Possible will be re-writed.
            //Based on search type assiging other variables
            switch (searchstatus)
            {
                // Rental Properties
                case "ra":
                    //chkSoldRent.Text = "exclude rented/leased properties";
                    txtTitle = "Properties For Rent";
                    //lblRentPets.Visible = true;
                    //rblRentPets.Visible = true;
                    chkUnderOffer.Visible = true;
                    //chkSoldRent.Visible = true;
                    flagrent = "1";
                    searchstatusForscript = "fr";
                    Session["page"] = "search rent";
                    //chkhomeopen.Visible = false;
                    break;

                // Commercial Rental Properties !
                case "cr":
                    cboOrder.Items[4].Enabled = false;
                    //chkSoldRent.Text = "exclude leased properties";
                    txtTitle = "Commercial Properties For Leased";
                    chkUnderOffer.Visible = false;
                    //chkSoldRent.Visible = false;
                    flagrent = "1";
                    searchstatusForscript = "fr";
                    Session["page"] = "comm rent";
                    //chkhomeopen.Visible = false;
                    chksalerent.Visible = true;
                    chksalerent.SelectedValue = "cr";
                    break;
                // Commercial sales Properties !
                case "co":
                    cboOrder.Items[4].Enabled = false;
                    //chkSoldRent.Text = "exclude sold properties";
                    txtTitle = "Commercial Properties For Sale";
                    Session["page"] = "comm sale";
                    chkUnderOffer.Visible = true;
                    chksalerent.Visible = true;
                    chksalerent.SelectedValue = "co";
                    //chkhomeopen.Visible = false;
                    break;
                // Business sales Properties
                case "bu":
                    ///cboOrder.Items[4].Enabled = false;
                    //chkSoldRent.Text = "exclude sold properties";
                    txtTitle = "Business Properties For Sale";
                    Session["page"] = "Business";
                    chkUnderOffer.Visible = true;
                    //chkhomeopen.Visible = false;
                    break;
                // Business sales Properties
                // investment sales Properties
                case "inv":
                    //chkSoldRent.Text = "exclude sold properties";
                    txtTitle = "Investment Properties For Sale";
                    Session["page"] = "Investment";
                    chkUnderOffer.Visible = true;
                    //chkhomeopen.Visible = false;
                    break;
                // Rural Properties
                case "ru":
                    //chkSoldRent.Text = "exclude sold properties";
                    txtTitle = "Rural Properties For Sale";
                    Session["page"] = "search sale";
                    chkUnderOffer.Visible = true;
                    //chkhomeopen.Visible = true;
                    break;
                // Sale Properties
                default:
                    //chkSoldRent.Text = "exclude sold properties";
                    txtTitle = "Properties For Sale";
                    Session["page"] = "search sale";
                    chkUnderOffer.Visible = true;
                    //chkhomeopen.Visible = false;
                    break;
            }
            #endregion
        }

        #region Get Suburbs
        //binding suburbs
        string tempstatus = "fs";
        if (!string.IsNullOrEmpty(Request.QueryString["st"]))
        {
            tempstatus = Request.QueryString["st"];
        }

        List<String> suburbs = null;

        if (!string.IsNullOrEmpty(Request.QueryString["re"]))
        {
            suburbs = REIQ.Access.Suburb.GetSuburbsByStatusAndRegion(Session["state"].ToString(), Request.QueryString["re"], null, tempstatus);
        }
        else if (Request.QueryString["map"] != null)
        {
            suburbs = REIQ.Access.Suburb.GetSuburbsByStatusAndRegion(Session["state"].ToString(), null, Request.QueryString["map"], tempstatus);            
        }
        else
        {
            suburbs = REIQ.Access.Suburb.GetSuburbsByStatusAndRegion(Session["state"].ToString(), null, null, tempstatus); 
        }

        lbSuburb.Items.Add(new ListItem("--Suburb--", ""));
        foreach (string suburb in suburbs)
        {
            lbSuburb.Items.Add(new ListItem(suburb, suburb));
        }

        #endregion

        #region Property options

        //adding property types
        List<String> pTypes = REIQ.Access.Lookups.ListPropertyTypes().ToList();
        foreach (var pType in pTypes)
        {
            cboPropertyType.Items.Add(new ListItem(pType, pType));
        }
        
        //adding bedrooms quantities
        IEnumerable<KeyValuePair<int, string>> bedrooms = REIQ.Access.Lookups.ListNumberOfBedrooms();
        foreach (var br in bedrooms)
        {
            cboBeds.Items.Add(new ListItem(br.Value, br.Key.ToString()));
        }

        //adding bathrooms quantities
        IEnumerable<KeyValuePair<int, string>> bathrooms = REIQ.Access.Lookups.ListNumberOfBathrooms();
        foreach (var br in bathrooms)
        {
            cboBaths.Items.Add(new ListItem(br.Value, br.Key.ToString()));
        }

        //adding lot sizes
        //IEnumerable<KeyValuePair<string, string>> lotSizes = REIQ.Access.Lookups.ListLotSizes();
        //foreach (var ls in lotSizes)
        //{
        //    cboLotSize.Items.Add(new ListItem(ls.Value, ls.Key));
        //}

        #endregion

        #region Prices

        IEnumerable<int> prices = null;
        if (searchstatus == "ra")
        {
            prices = REIQ.Access.Lookups.ListPrices(REIQ.Enum.SearchTab.Rent);
        }
        else
        {
            prices = REIQ.Access.Lookups.ListPrices(REIQ.Enum.SearchTab.Buy);
        }
        
        foreach (var pr in prices)
        {
            if (pr < 1000)
            {
                minPrice.Items.Add(new ListItem(pr.ToString(), pr.ToString()));
                maxPrice.Items.Add(new ListItem(pr.ToString(), pr.ToString()));
            }
            else
            {
                minPrice.Items.Add(new ListItem(pr.ToString("0,000"), pr.ToString()));
                maxPrice.Items.Add(new ListItem(pr.ToString("0,000"), pr.ToString()));
            }
        }

        #endregion

        #region Agencies list

        //get agencies
        List<REIQ.Access.Agency.OneAgency> dtagencydistinct = null;

        if (!string.IsNullOrEmpty(Request.QueryString["re"]))
        {
            dtagencydistinct = REIQ.Access.Agency.GetAgenciesList(Session["state"].ToString(), Request.QueryString["re"], null, tempstatus);
        }
        else if (!string.IsNullOrEmpty(Request.QueryString["map"]))
        {
            dtagencydistinct = REIQ.Access.Agency.GetAgenciesList(Session["state"].ToString(), null, Request.QueryString["map"], tempstatus);
        }
        else
        {
            dtagencydistinct = REIQ.Access.Agency.GetAgenciesList( Session["state"].ToString(), null, null, tempstatus);
        }

        // adding agencies
        foreach (var agency in dtagencydistinct)
        {
            cboAgency.Items.Add(new ListItem(agency.AgencyName, agency.AgencyId));
        }

        #endregion
    }

    protected void btnSearchPropList_Click(object sender, EventArgs e)
    {
        string strPets = "";
        //if (rblRentPets.Visible == true && lblRentPets.Visible == true)
        //{
        //    strPets = "&pt=" + rblRentPets.SelectedValue;
        //}

        redirectUrl("text", strPets);
    }

    //protected void btnSearchPropMap_Click(object sender, ImageClickEventArgs e)
    //{
    //    string strPets = "";
    //    //if (rblRentPets.Visible == true && lblRentPets.Visible == true)
    //    //{
    //    //    strPets = "&pt=" + rblRentPets.SelectedValue;
    //    //}
    //    //redirectUrl("map", strPets);
    //}

    //submit form - redirect to results page with set query string
    void redirectUrl(string strUrl, string strPets)
    {
        string selectedSuburbs = String.Empty;
        string paramKeyword = String.Empty;

        //reset searchText if default value was specified
        if (searchtext.Text == REIQ.usercontrols.PropertySearchBase.DefaultSearchText) searchtext.Text = "";

        //get suburbs if selected
        if (lbSuburb.Items.Count > 0)
        {
            for (int i = 0; i < lbSuburb.Items.Count; i++)
            {
                if (lbSuburb.Items[i].Value != "" && lbSuburb.Items[i].Selected == true)
                {
                    if (String.IsNullOrEmpty(selectedSuburbs))
                    {
                        selectedSuburbs = lbSuburb.Items[i].Text;
                    }
                    else
                    {
                        selectedSuburbs = selectedSuburbs + "!!" + lbSuburb.Items[i].Text;
                    }
                }
            }
        }

        string strtypelist = "";
        if (cboPropertyType.Visible)
        {
            for (int i = 0; i < cboPropertyType.Items.Count; i++)
            {
                if (cboPropertyType.Items[i].Selected)
                {
                    strtypelist += cboPropertyType.Items[i].Value + ",";
                }
            }
            if (strtypelist.Contains(","))
                strtypelist = strtypelist.Substring(0, strtypelist.Length - 1);
        }
        if (String.IsNullOrEmpty(strtypelist))
        {
            strtypelist = "";
        }


        string surr;
        if (chkSurroundingSale.Checked.Equals(true) && selectedSuburbs != "")
        {
            surr = "1";
        }
        else
        {
            surr = "0";
        }

        string exclude;
        exclude = "1"; //remove when uncomment text under
        //if (chkSoldRent.Checked.Equals(true))
        //{
        //    exclude = "1";

        //}
        //else
        //{
        //    exclude = "0";
        //    if (searchstatus.Equals("sa"))
        //    {
        //        searchstatus = "fs";
        //    }
        //    else
        //    {
        //        if (searchstatus.Equals("ra"))
        //        {
        //            searchstatus = "fr";
        //        }
        //    }
        //}
        string strUnderOffer = "0";
        if (chkUnderOffer.Checked == true)
        {
            strUnderOffer = "1";
        }

        string hasVT;
        hasVT = ""; //remove when uncomment text under
        //if (chkhasVT.Checked.Equals(true))
        //{
        //    hasVT = "1";
        //}
        //else
        //{
        //    hasVT = "";
        //}

        if (maxPrice.SelectedValue == "3000000")
            maxPrice.SelectedValue = "";

        string hoonly = "";
        //if (chkhomeopen.Checked && chkhomeopen.Visible == true)
        //    hoonly = "&hoonly=1";

        //set ParamKeyword for query string
        if (!String.IsNullOrWhiteSpace(searchtext.Text))
        {
            paramKeyword = searchtext.Text.ToString();
        }
        else if (!String.IsNullOrEmpty(selectedSuburbs))
        {
            paramKeyword = selectedSuburbs;
        }
        else if (!String.IsNullOrEmpty(Request.QueryString["re"]))
        {
            paramKeyword = Request.QueryString["re"];
        }
        else if (!String.IsNullOrEmpty(Request.QueryString["map"]))
        {
            List<String> regionsList = REIQ.Access.Suburb.GetRegionByMaparea(Request.QueryString["map"]);
            foreach (var region in regionsList)
            {
                if (String.IsNullOrEmpty(paramKeyword))
                {
                    paramKeyword += region;
                }
                else paramKeyword += "::" + region;
            }
        }

        //temporarily removed (+ "&fur=" + cboFurnished.SelectedValue) (+ "&da=" + cboListed.SelectedValue) (+ "&num=" + cboNumItems.SelectedValue) 
        // (+ "&ba=" + cboBaths.SelectedValue) (+ "&lot=" + cboLotSize.SelectedValue)
        Response.Redirect("/" + SearchResultsUrl + "?st=" + searchstatus + "&txt=" + paramKeyword + "&acid=" + cboAgency.SelectedValue + "&ex=" + exclude +
            "&exoffer=" + strUnderOffer + "&surr=" + surr + "&prl=" + minPrice.SelectedValue + "&prh=" + maxPrice.SelectedValue + "&be=" + cboBeds.SelectedValue + "&ba=" + cboBaths.SelectedValue + "&ty=" + strtypelist + "&ob=" + cboOrder.SelectedValue + "&vt=" +
            hasVT + strPets + "&flagsort=1" + hoonly);
    }    

    //when tab with search types was clicked
    protected void chksalerent_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("/dynamic/search-map-general/?st=" + chksalerent.SelectedValue + "&ser=text");
    }
}


