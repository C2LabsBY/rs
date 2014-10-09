using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SearchForm : REIQ.usercontrols.PropertySearchBase
{
    #region Page Properties

    //default max count of banners to show
    public int MaxCountAds = 8;
    //default scroll speed
    public int ScrollSpeed = 15;
    //banners list
    public List<REIQ.Access.Advertisement.AdvertisementExtended> Advertisements { get; set; }
    public int LeftBannersCount { get; set; }
    public int RightBannersCount { get; set; }
    

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        LeftBannersCount = 0;
        RightBannersCount = 0;
        String leftAdstoHtml = String.Empty;
        String rightAdstoHtml = String.Empty;
        List<REIQ.Access.Advertisement.AdvertisementExtended> randAds = new List<REIQ.Access.Advertisement.AdvertisementExtended>();
        
        //get scroll speed from the page property Scroll Speed
        var currentNode = umbraco.NodeFactory.Node.GetCurrent();
        if (currentNode != null)
        {
             if (currentNode.GetProperty("scrollSpeed") != null && !String.IsNullOrEmpty(currentNode.GetProperty("scrollSpeed").Value))
             {
                 ScrollSpeed = Convert.ToInt32(currentNode.GetProperty("scrollSpeed").Value) * 1000;
             }
             if (currentNode.GetProperty("amountHomeBanners") != null && !String.IsNullOrEmpty(currentNode.GetProperty("amountHomeBanners").Value))
             {
                 MaxCountAds = Convert.ToInt32(currentNode.GetProperty("amountHomeBanners").Value);
             }
        }

        if (Request.QueryString["nomatches"] == "1")
            Response.Write("<script>alert('Please type in correct suburb, postcode, region or property ID to begin your search');</script>");
        
        //Get banners adverts if present
        Advertisements = REIQ.Access.Advertisement.GetBannerAdsHomePage();

        if (Advertisements.Count > 0)
        {
            if (Advertisements.Count < MaxCountAds)
                MaxCountAds = Advertisements.Count;

            Random RandomClass = new Random();
            for (var i = 0; i <= (MaxCountAds - 1); i++)
            {
                int rndNo = RandomClass.Next(0, Advertisements.Count);
                randAds.Add(Advertisements[rndNo]);
                Advertisements.Remove(Advertisements[rndNo]);                
            }

            //leftAdstoHtml = "<ul>";
            //rightAdstoHtml = "<ul>";

            foreach (var randAd in randAds)
            {
                if (randAds.IndexOf(randAd) % 2 == 0)
                {
                    leftAdstoHtml += BannerImageToString(randAd);
                    LeftBannersCount++;
                }
                else
                {
                    rightAdstoHtml += BannerImageToString(randAd);
                    RightBannersCount++;
                }
            }

            //leftAdstoHtml += "</ul>";
            //rightAdstoHtml += "</ul>";

            leftAds.Text = HttpUtility.HtmlDecode(leftAdstoHtml);
            rightAds.Text = HttpUtility.HtmlDecode(rightAdstoHtml);
            
        }
    }
    /// <summary>
    /// Make element of list with one image
    /// </summary>
    /// <param name="ad">Advertisement banner</param>
    /// <returns></returns>
    private String BannerImageToString(REIQ.Access.Advertisement.AdvertisementExtended ad)
    {
        String str = String.Empty; // "<li>";
        bool hasUrl = false;            

        //Init reiqAdminUrl needed for showing ads images
        String reiqAdminURL = "http://psadmin.reiq.com/";
        //String reiqAdminURL = "http://localhost:8010/";
        if (ConfigurationManager.AppSettings["REIQAdmin"] != null)
            reiqAdminURL = ConfigurationManager.AppSettings["REIQAdmin"].ToString();

        //banner has url
        if (!String.IsNullOrEmpty(ad.link))
        {
            str += "<a href='/hitadvert.aspx?adid=" + DataUtility.Encrypt(ad.AdId.ToString())
                    + "&url=" + ad.link + "' target='_blank' >";
            hasUrl = true;
        }
        else str += "<div>";
        //agency has url        
        //else if (!String.IsNullOrEmpty(ad.AgencyWeb))
        //{
        //    str += "<a href='http://" + ad.AgencyWeb.Replace("http://", "") + "'>";
        //    hasUrl = true;
        //}
        ////default url for image if agency's banner
        //else if (!String.IsNullOrEmpty(ad.acid.ToString()))
        //{
        //    str += "<a href='/agencydetails.aspx?acId=" + ad.acid.ToString() + "'>";
        //    hasUrl = true;
        //}

        //banner has image url
        if (!String.IsNullOrEmpty(ad.imgurl))
        {
            str += "<img src='" + reiqAdminURL + "advimg/" + ad.AdId.ToString() + "/" + ad.imgurl + "' width='140px' height='140px' data-adv-id='" + ad.AdId.ToString() + "' data-is-saved='0'";
        }
        //banner is an agency image
        else if (!String.IsNullOrEmpty(ad.acid.ToString()))
        {
            str += "<img src='" + REIQ.Helpers.Images.GetAgencyImage(Convert.ToInt32(ad.acid), 196, 88) + "' width='140px' height='140px' data-adv-id='" + ad.AdId.ToString() + "' data-is-saved='0'";
        }

        //banner has "alt" text
        if (!String.IsNullOrEmpty(ad.alttext))
        {
            str += " alt='" + ad.alttext + "'";
        }

        //show title
        if (!String.IsNullOrEmpty(ad.AgencyName))
            str += " title='" + ad.AgencyName + "'";
        else if (!String.IsNullOrEmpty(ad.ThirdPartyName))
            str += " title='" + ad.ThirdPartyName + "'";

        str += "/>";

        if (hasUrl) str += "</a>";
            else str += "</div>";

        //str += "</li>";
        return str;
    }

    #endregion
}