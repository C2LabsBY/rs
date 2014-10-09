using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_InjectGARemarketingScript : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool injectGARemarketingScript = false;
        if (ConfigurationManager.AppSettings["injectGARemarketingScript"] != null)
            Boolean.TryParse(ConfigurationManager.AppSettings["injectGARemarketingScript"].ToString(), out injectGARemarketingScript);
        ShowGARemarketing.Visible = injectGARemarketingScript;
    }
}