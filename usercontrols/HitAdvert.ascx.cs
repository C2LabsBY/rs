using System;

public partial class usercontrols_HitAdvert : System.Web.UI.UserControl
{
    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["adid"]) && !string.IsNullOrEmpty(Request.QueryString["url"]))
        {
            REIQ.Access.Advertisement.UpdateAdvertHit(DataUtility.Decrypt(Request.QueryString["adid"]));

            string url = Request.QueryString["url"].Replace("@@", "/");

            Response.Redirect(url);
        }
    }
    #endregion
}
