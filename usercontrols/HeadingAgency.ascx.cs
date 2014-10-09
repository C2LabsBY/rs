using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Helpers;

public partial class usercontrols_content_header_AgencyHeading : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int AgencyId
    {
        get
        {
            if (_agencyId == 0)
            {
                Int32.TryParse(Request.QueryString["acid"], out _agencyId);
            }
            return _agencyId;
        }
        set { _agencyId = value; }
    }
    private int _agencyId;

    protected String AgencyAddress {get;set;}

    /// <summary>
    /// The Agency itself
    /// </summary>
    protected REIQ.Entities.Agency Agency { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Agency = REIQ.Access.Agency.GetFromAgencyId(this.AgencyId);
            if (Agency != null) AgencyAddress = AgencyHelper.GetAgencyAddress(Agency);
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion

}