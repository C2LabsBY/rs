using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SideBarTowerAdvert : REIQ.usercontrols.PropertySearchBase
{
    #region Properties

    protected String TowerAdString { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            TowerAdString = GetTowerAdvertisements();
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion

    #region Page Methods

    /// <summary>
    /// Shows Tower Adverts if present
    /// </summary>
    private String GetTowerAdvertisements()
    {
        //tower ad (it includes suburbs ad and displayed randomly.if no booking for suburbs or surrounding suburbs then region ad will come)
        string strtowerad = String.Empty;
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
            //Get tower ads per region we are searching
            ads = REIQ.Access.Advertisement.GetTowerAdsByRegion(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), region);

            //If there are no tower ads per region we are searching -> then get the random tower ad assigned to any suburb of that region
            if (ads.Count == 0)
            {
                //Get suburbIDs of current region
                List<int> suburbIDs = REIQ.Access.Suburb.ListIdsOfSuburbsByRegion(region);

                foreach (Int32 suburbID in suburbIDs)
                {
                    ads.AddRange(REIQ.Access.Advertisement.GetTowerAdsBySuburb(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburbID));
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
                //get tower ads per suburb we are searching
                ads = REIQ.Access.Advertisement.GetTowerAdsBySuburb(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburb.sID);

                //if we got no tower ads per suburb we searching -> check if we have a tower ad per region of current suburb
                if (ads.Count == 0)
                {
                    ads = REIQ.Access.Advertisement.GetTowerAdsByRegion(REIQ.Access.Advertisement.GetCategoryParam(ParamSearchType.ToString()), suburb.region);
                }
            }
        }

        if (ads.Count > 0)
        {
            REIQ.Entities.Advertisement advert = new REIQ.Entities.Advertisement();

            //Init reiqAdminUrl needed for showing ads images
            String reiqAdminURL = "http://psadmin.reiq.com/";
            if (ConfigurationManager.AppSettings["REIQAdmin"] != null)
                reiqAdminURL = ConfigurationManager.AppSettings["REIQAdmin"].ToString();

            //If we found one tower ad - just show it
            if (ads.Count == 1)
                advert = ads[0];
            else //show random one
            {
                Random RandomClass = new Random();
                int rndNo = RandomClass.Next(ads.Count);
                advert = ads[rndNo];
            }

            if (!String.IsNullOrEmpty(advert.link))
                strtowerad =
                    "<a href='/hitadvert.aspx?adid=" + DataUtility.Encrypt(advert.AdId.ToString())
                    + "&url=" + advert.link
                    + "' target='_blank' ><img alt='" + advert.alttext
                    + "' title='" + advert.alttext
                    + "' border='0' src='" + reiqAdminURL
                    + "advimg/" + advert.AdId.ToString()
                    + "/" + advert.imgurl + "'/></a><br><br>";
            else
                strtowerad =
                    "<img alt='" + advert.alttext
                    + "' title='" + advert.alttext
                    + "' border='0' src='" + reiqAdminURL
                    + "advimg/" + advert.AdId.ToString()
                    + "/" + advert.imgurl + "'/><br><br>";
        }
        return HttpUtility.HtmlDecode(strtowerad);
    }

    private string ResetKeywordIfDefault(string keyword)
    {
        if (string.IsNullOrEmpty(keyword) || ParamKeyword.Trim().Equals(REIQ.usercontrols.PropertySearchBase.DefaultSearchText, StringComparison.CurrentCultureIgnoreCase))
        {
            return "";
        }
        return ParamKeyword;
    }

    #endregion
}