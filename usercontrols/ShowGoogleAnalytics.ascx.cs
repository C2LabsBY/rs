using System;
using System.Configuration;
using System.Web;

public partial class usercontrols_ShowGoogleAnalytics : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool injectGoogleAnalyticsScript = false;
        if (ConfigurationManager.AppSettings["injectGoogleAnalyticsScript"] != null)
            Boolean.TryParse(ConfigurationManager.AppSettings["injectGoogleAnalyticsScript"].ToString(), out injectGoogleAnalyticsScript);
        phGACode.Visible = injectGoogleAnalyticsScript;
    }
}