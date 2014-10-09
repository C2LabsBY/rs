using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Access;
using umbraco.presentation.nodeFactory;

public partial class usercontrols_SideBarRefineResults : REIQ.usercontrols.PropertySearchBase
{
    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Node CurrentPage = Node.GetCurrent();

            if (CurrentPage.GetProperty("showRefineSearch") == null)
                return;

            if (CurrentPage.GetProperty("showRefineSearch").Value != "1")
                return;
            else phSearchRefineForm.Visible = true;

            if (!IsPostBack)
            {
                InitControls();
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    protected void btnSearchProp_Click(object sender, EventArgs e)
    {
        #region Old code commented
        //string selectedSuburbs = "";
        //string keyword = "";
        //string regionlist = "";
        //string pids = "";
        //string txt = "";
        //string textsearch = "";

        //if (ParamKeyword != "" && ParamKeyword != "Type in a suburb, postcode, region or property ID to begin your search")
        //{
        //    string[] strtextbox = txtHomeSearch.Text.Split(';');

        //    //check if the list are for suburbs start
        //    for (int i = 0; i < strtextbox.Length; i++)
        //    {
        //        string stritem = strtextbox[i];

        //        if (stritem != "")
        //        {
        //            DataTable dtsuburbkey = prop.getSuburbbyname(stritem);
        //            if (dtsuburbkey.Rows.Count == 0)
        //            {
        //                dtsuburbkey = prop.SelectSuburbBySynonymousName(stritem);
        //            }
        //            if (dtsuburbkey.Rows.Count == 0)
        //            {
        //                dtsuburbkey = prop.getSuburbbypostcode(stritem);
        //            }

        //            char ch = ',';
        //            if (stritem.Contains(';'))
        //                ch = ';';

        //            if (dtsuburbkey.Rows.Count == 0 && stritem.Contains(ch))
        //            {
        //                string[] strsplitcomma = stritem.Split(ch);

        //                if (strsplitcomma.Length == 2)
        //                {
        //                    dtsuburbkey = prop.getSuburbbynamepostcode(strsplitcomma[0].Trim(), strsplitcomma[1].Trim());

        //                    if (dtsuburbkey.Rows.Count == 0)
        //                    {
        //                        dtsuburbkey = prop.getSuburbbynamepostcode(strsplitcomma[1].Trim(), strsplitcomma[0].Trim());
        //                    }
        //                    if (dtsuburbkey.Rows.Count == 0)
        //                    {
        //                        dtsuburbkey = prop.SelectSuburbBySynonymousName(strsplitcomma[0].Trim());
        //                    }
        //                    if (dtsuburbkey.Rows.Count == 0)
        //                    {
        //                        dtsuburbkey = prop.SelectSuburbBySynonymousName(strsplitcomma[1].Trim());
        //                    }
        //                }
        //            }
        //            for (int j = 0; j < dtsuburbkey.Rows.Count; j++)
        //            {
        //                selectedSuburbs += dtsuburbkey.Rows[j]["name"].ToString() + "-" + dtsuburbkey.Rows[j]["postcode"].ToString() + ",";
        //            }
        //        }
        //    }
        //    if (selectedSuburbs.Contains(","))
        //    {
        //        selectedSuburbs = selectedSuburbs.Substring(0, selectedSuburbs.Length - 1);
        //    }
        //    //check if the list are for suburbs END

        //    //check if the list are for region start (it only consider first region entered)
        //    if (selectedSuburbs == "")
        //    {
        //        if (strtextbox.Length > 0)
        //        {
        //            string stritem = strtextbox[0];

        //            if (stritem != "")
        //            {
        //                DataTable dtregionkey = prop.getRegionbyName(stritem);

        //                if (dtregionkey.Rows.Count > 0)
        //                {
        //                    regionlist = dtregionkey.Rows[0]["region"].ToString();
        //                }
        //            }
        //        }
        //    }
        //    //check if the list are for region END

        //    //check if the list are for pid start
        //    if (selectedSuburbs == "" && regionlist == "")
        //    {
        //        for (int i = 0; i < strtextbox.Length; i++)
        //        {
        //            string stritem = strtextbox[i].Trim();

        //            if (stritem != "")
        //            {
        //                int result;
        //                if (int.TryParse(stritem, out result))
        //                {
        //                    pids += stritem + ",";
        //                }
        //            }
        //        }
        //        if (pids.Contains(","))
        //        {
        //            pids = pids.Substring(0, pids.Length - 1);
        //        }
        //    }
        //    //check if the list are for pid END


        //    if (selectedSuburbs == "" && regionlist == "" && pids == "")
        //    {
        //        Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script >alert('Type in a suburb, postcode, region or property ID to begin your search');</script>");
        //        return;
        //    }

        //    searchregion = regionlist;
        //    su1 = selectedSuburbs;
        //    searchkeyword = keyword;

        //    txt = "&txt=" + txtHomeSearch.Text;
        //    textsearch = txtHomeSearch.Text;

        //}

        //if (ParamKeyword != null && txt == "")
        //{
        //    txt += "&txt=" + ParamKeyword;
        //    textsearch = ParamKeyword;
        //}
        //if (ParamIncludeOpenHomesOnly != null)
        //    txt += "&hoonly=" + ParamIncludeOpenHomesOnly;

        //if (pids != "")
        //    pids = "&pids=" + pids;

        ////One must be selected out of 4
        //if (textsearch == "" || textsearch == "Type in a suburb, postcode, region or property ID to begin your search")
        //{
        //    if (ddlMaxPrice.SelectedIndex == 0)
        //    {
        //        if (ddlMinPrice.SelectedIndex == 0)
        //        {
        //            if (ddlBedrooms.SelectedIndex == 0)
        //            {
        //                if (searchtype == "" || searchtype == "Any")
        //                {
        //                    Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", "<script >alert('Type in a suburb, postcode, region or property ID to begin your search');</script>");
        //                    return;
        //                }
        //            }
        //        }
        //    }
        //}
        #endregion

        string searchtype;

        string strtypelist = "";
        for (int i = 0; i < cboPropertyType.Items.Count; i++)
        {
            if (cboPropertyType.Items[i].Selected)
            {
                strtypelist += cboPropertyType.Items[i].Value + ",";
            }
        }

        if (strtypelist.Contains(","))
            strtypelist = strtypelist.Substring(0, strtypelist.Length - 1);

        if (!String.IsNullOrEmpty(strtypelist))
        {
            searchtype = strtypelist;
        }
        else
        {
            searchtype = String.Empty;
        }

        Response.Redirect("~/results?st=" + ParamSearchType
            + "&txt=" + ParamKeyword
            + "&ty=" + searchtype
            + "&acid=" + ParamAgencyId
            //+ "&ex=" + strExclude
            + "&exoffer=" + ParamExcludePropertiesUnderOffer
            //+ "&re=" + searchregion
            //+ "&su=" + su1
            + "&surr=" + ParamIncludeSurroundingSuburbs
            //+ "&da=" + searchdays
            + "&prl=" + ddlMinPrice.SelectedValue
            + "&prh=" + ddlMaxPrice.SelectedValue
            + "&be=" + ddlBedrooms.SelectedValue
            + "&ba=" + ddlBaths.SelectedValue
            //+ "&ca=" + searchcar
            //+ "&ls=" + searchlifestyle
            //+ "&lot=" + searchlot
            //+ "&key=" + searchkeyword
            + "&ob=" + ParamSort
            //+ "&num=" + searchnumberoflisting
            //+ "&fur=" + searchfurnished
            //+ "&heatmap=" + (heatmap ? "true" : "false")
            //+ "&vt=" + hasVT + txt + pids
            );
    }

    #endregion

    #region Page Methods

    private void InitControls()
    {
        //Property Type setup
        cboPropertyType.DataSource = REIQ.Access.Lookups.ListPropertyTypes();
        cboPropertyType.DataBind();

        foreach (var propertyType in ParamPropertyType)
        {
            int index = cboPropertyType.Items.IndexOf(cboPropertyType.Items.FindByValue(propertyType));
            if (index >= 0)
                cboPropertyType.Items[index].Selected = true;
        }

        //Bedrooms setup
        ddlBedrooms.Items.Add(new ListItem("Min. Bedrooms", ""));
        foreach (var item in Lookups.ListNumberOfBedrooms())
        {
            ddlBedrooms.Items.Add(new ListItem(item.Value, item.Key.ToString()));
        }
        ddlBedrooms.DataBind();

        ddlBedrooms.SelectedValue = ParamMinimumBeds.ToString();

        //Bedrooms setup
        ddlBaths.Items.Add(new ListItem("Min. Bathrooms", ""));
        foreach (var item in Lookups.ListNumberOfBathrooms())
        {
            ddlBaths.Items.Add(new ListItem(item.Value, item.Key.ToString()));
        }
        ddlBaths.DataBind();

        ddlBaths.SelectedValue = ParamMinimumBaths.ToString();
        

        //Min/Low Price setup
        ddlMinPrice.Items.Add(new ListItem("Min. Price", ""));
        if (ParamSearchType == REIQ.Enum.SearchType.ra)
        {
            foreach (var item in Lookups.ListPrices(REIQ.Enum.SearchTab.Rent))
            {
                ddlMinPrice.Items.Add(new ListItem(item.ToString().Length > 3 ? item.ToString("0,000") : item.ToString(), item.ToString()));
            }
            ddlMinPrice.DataBind();
        }
        else
        {
            foreach (var item in Lookups.ListPrices(REIQ.Enum.SearchTab.Buy))
            {
                ddlMinPrice.Items.Add(new ListItem(item.ToString("0,000"), item.ToString()));
            }
            ddlMinPrice.DataBind();
        }

        ddlMinPrice.SelectedValue = ParamPriceLow.ToString();

        ddlMaxPrice.Items.Add(new ListItem("Max. Price", ""));
        if (ParamSearchType == REIQ.Enum.SearchType.ra)
        {
            foreach (var item in Lookups.ListPrices(REIQ.Enum.SearchTab.Rent))
            {
                ddlMaxPrice.Items.Add(new ListItem(item.ToString().Length > 3 ? item.ToString("0,000") : item.ToString(), item.ToString()));
            }
            ddlMaxPrice.DataBind();
        }
        else
        {
            foreach (var item in Lookups.ListPrices(REIQ.Enum.SearchTab.Buy))
            {
                ddlMaxPrice.Items.Add(new ListItem(item.ToString("0,000"), item.ToString()));
            }
            ddlMaxPrice.DataBind();
        }

        ddlMaxPrice.SelectedValue = ParamPriceHigh.ToString();
    }

    #endregion
}