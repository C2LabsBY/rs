using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;

public partial class usercontrols_ResultIframe : REIQ.usercontrols.PropertySearchBase
{
    #region Properties

    public Int32 PageSize { get; set; }
    //Banner Ads variables
    //protected String BannerAdString { get; set; }
    /// <summary>
    /// Banner Ad List
    /// </summary>
    List<REIQ.Entities.Advertisement> Advertisements { get; set; }
    #endregion

    #region Page Events

    protected override void OnInit(EventArgs e)
    {
        var propertyIds = REIQ.Access.Property.Search(ParamSearchType, ParamPropertyType, ParamExcludePropertiesUnderOffer, ParamIncludeSurroundingSuburbs, ParamIncludeOpenHomesOnly, ResetKeywordIfDefault(ParamKeyword).Trim(), ParamPriceLow, ParamPriceHigh, ParamMinimumBeds, ParamMinimumBaths, ParamSort, ParamAgencyId);

        if (propertyIds.Count() == 0)
        {
            lblNoResults.Visible = true;
            return;
        }

        // put the search results into request context so we can access them from the other controls
        if (String.IsNullOrEmpty(Request.QueryString["aid"]))
            base.RememberPropertyIds(propertyIds);

        var properties = REIQ.Access.Property.ListForDisplay(propertyIds, ParamSort, ParamPageNumber, PageSize == null ? PropertiesPerPage : (Int32)PageSize);

        //Init Advertisements
        Advertisements = GetBannerAdvertisements();

        rptProperties.DataSource = properties;
        rptProperties.DataBind();

        base.OnInit(e);
    }

    protected void rptProperties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            REIQ.Entities.Property property = (REIQ.Entities.Property)e.Item.DataItem;

            //Label lblPrice = e.Item.FindControl("lblPrice") as Label;
            Literal litAgencyImage = e.Item.FindControl("litAgencyImage") as Literal;

            if (property.acID > 0)
            {
                REIQ.Entities.Agency agency = REIQ.Access.Agency.GetFromPropertyId(property.pID);
                litAgencyImage.Text = "<a href='/" + REIQ.Helpers.PropertyHelper.GenerateURLAgency(agency.name.ToString(), property.suburb.ToString(), property.acID) + "'><img src=" + Images.GetAgencyImage(property.acID, 196, 88) + " class='agent-logo'/></a>";
            }

            REIQ.Entities.Agent agent = REIQ.Access.Agent.GetFromPropertyId(property.pID);

            if (agent != null)
            {
                Literal litAgentName = e.Item.FindControl("litAgentName") as Literal;
                Literal litAgentPhone = e.Item.FindControl("litAgentPhone") as Literal;
                litAgentName.Text = "<span class='agent-name'>" + (agent.firstname + " " + agent.surname).ToUpper() + "</span><br />";
                litAgentPhone.Text = "<span class='agent-pg' nowrap>" + AgentHelper.GetAgentPhoneWithLog(agent) + "</span>";//"<span class='agent-pg' nowrap>" + agent.phone + "</span>";
            }

            //Showing New span
            Literal ltlNew = e.Item.FindControl("ltlNew") as Literal;
            if (REIQ.Helpers.PropertyHelper.isNewlyAdded(property.dateListed))
                ltlNew.Text = "<span class='new-label'></span>";

            //Banner ads management, showing banner after each 5th property except last (20th)
            if (e.Item.ItemIndex > 0 && e.Item.ItemIndex < (PageSize - 1) && (e.Item.ItemIndex + 1) % 5 == 0)
            {
                Literal ltlBannerAd = e.Item.FindControl("ltlBannerAd") as Literal;
                ltlBannerAd.Text = GetRandomBannerAdFromList();
            }
        }
    }

    #endregion

    #region Page Methods

    private string ResetKeywordIfDefault(string keyword)
    {
        if (string.IsNullOrEmpty(keyword) || ParamKeyword.Trim().Equals(REIQ.usercontrols.PropertySearchBase.DefaultSearchText, StringComparison.CurrentCultureIgnoreCase))
        {
            return "";
        }
        return ParamKeyword;
    }

    protected string getPriceText(object item)
    {
        REIQ.Entities.Property property = (REIQ.Entities.Property)item;

        return PropertyHelper.GetPropertyPrice(property);
    }

    /// <summary>
    /// Shows Tower Adverts if present
    /// </summary>
    private List<REIQ.Entities.Advertisement> GetBannerAdvertisements()
    {
        //banner ad (it includes suburbs ad and displayed randomly.if no booking for suburbs or surrounding suburbs then region ad will come)
        String region = String.Empty;
        REIQ.Entities.Suburb suburb = new REIQ.Entities.Suburb();

        List<REIQ.Entities.Advertisement> ads = new List<REIQ.Entities.Advertisement>();

        //Determine if we are searching by region
        var matchingItems = REIQ.Access.Suburb.ListMatching(ResetKeywordIfDefault(ParamKeyword).Trim());
        if (matchingItems != null && matchingItems.Regions != null && matchingItems.Regions.Count() > 0)
        {
            region = matchingItems.Regions[0];
        }

        //If we are searching by region
        if (!String.IsNullOrEmpty(region))
        {
            //Get banner ads per region we are searching
            ads = REIQ.Access.Advertisement.GetBannerAdsByRegion(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), region);

            //If there are no banner ads per region we are searching -> then get the random banner ad assigned to any suburb of that region
            if (ads.Count == 0)
            {
                //Get suburbIDs of current region
                List<int> suburbIDs = REIQ.Access.Suburb.ListIdsOfSuburbsByRegion(region);

                foreach (Int32 suburbID in suburbIDs)
                {
                    ads.AddRange(REIQ.Access.Advertisement.GetBannerAdsBySuburb(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburbID));
                }
            }
        }
        else
        {
            //Try to Determine current Suburb
            suburb = REIQ.Access.Suburb.TryGetSuburbFromSearchString(ResetKeywordIfDefault(ParamKeyword).Trim());
            //If we are searching by suburb
            if (suburb != null)
            {
                //get banner ads per suburb we are searching
                ads = REIQ.Access.Advertisement.GetBannerAdsBySuburb(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburb.sID);

                //if we got no banner ads per suburb we searching -> check if we have a banner ad per region of current suburb
                if (ads.Count == 0)
                {
                    ads = REIQ.Access.Advertisement.GetBannerAdsByRegion(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburb.region);
                }
            }
        }

        return ads;
    }

    private string GetRandomBannerAdFromList()
    {
        string strbannerad = String.Empty;

        if (Advertisements.Count > 0)
        {
            Random RandomClass = new Random();
            int rndNo = RandomClass.Next(Advertisements.Count());

            REIQ.Entities.Advertisement advert = Advertisements[rndNo];
            Advertisements.Remove(Advertisements[rndNo]);

            //Init reiqAdminUrl needed for showing ads images
            String reiqAdminURL = "http://psadmin.reiq.com/";
            if (ConfigurationManager.AppSettings["REIQAdmin"] != null)
                reiqAdminURL = ConfigurationManager.AppSettings["REIQAdmin"].ToString();

            ////If we found one tower ad - just show it
            //if (ads.Count == 1)
            //    advert = ads[0];
            //else //show random one
            //{
            //    Random RandomClass = new Random();
            //    int rndNo = RandomClass.Next(ads.Count);
            //    advert = ads[rndNo];
            //}

            if (!String.IsNullOrEmpty(advert.link))
                strbannerad =
                    "<a href='/hitadvert.aspx?adid=" + DataUtility.Encrypt(advert.AdId.ToString())
                    + "&url=" + advert.link
                    + "' target='_blank' ><img alt='" + advert.alttext
                    + "' title='" + advert.alttext
                    + "' border='0' src='" + reiqAdminURL
                    + "advimg/" + advert.AdId.ToString()
                    + "/" + advert.imgurl + "'/></a>";
            else
                strbannerad =
                    "<img alt='" + advert.alttext
                    + "' title='" + advert.alttext
                    + "' border='0' src='" + reiqAdminURL
                    + "advimg/" + advert.AdId.ToString()
                    + "/" + advert.imgurl + "'/>";
        }
        return HttpUtility.HtmlDecode(strbannerad);
    }

    #endregion

}