using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;

public partial class usercontrols_content_header_HeadingSuburb : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Suburb name. Comes from the querystring.
    /// </summary>
    protected String SuburbName
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["su"]))
                return Request.QueryString["su"];

            return String.Empty;
        }
    }
    private string _suburbName;

    /// <summary>
    /// Property suburb
    /// </summary>
    protected REIQ.Entities.Suburb Suburb { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Suburb = REIQ.Access.Suburb.GetFromName(SuburbName);
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion
}