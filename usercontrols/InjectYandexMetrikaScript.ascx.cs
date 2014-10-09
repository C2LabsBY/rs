using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_InjectYandexMetrikaScript : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool injectGoogleAnalyticsScript = false;
        if (ConfigurationManager.AppSettings["injectYandexMetrikaScript"] != null)
            Boolean.TryParse(ConfigurationManager.AppSettings["injectYandexMetrikaScript"].ToString(), out injectGoogleAnalyticsScript);
        ShowYandexMetrika.Visible = injectGoogleAnalyticsScript;
    }
}