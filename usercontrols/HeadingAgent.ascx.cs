using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

public partial class usercontrols_content_header_AgentHeading : System.Web.UI.UserControl
{
    #region Properties

    protected int AgentId
    {
        get
        {
            if (_agentId == 0)
            {
                Int32.TryParse(Request.QueryString["aid"], out _agentId);
            }
            return _agentId;
        }
        set { _agentId = value; }
    }
    private int _agentId;

    protected String AgentAddress { get; set; }

    /// <summary>
    /// The Agent itself
    /// </summary>
    protected REIQ.Entities.Agent Agent { get; set; }
    /// <summary>
    /// Corresponded agency
    /// </summary>
    protected REIQ.Entities.Agency Agency { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Agent = REIQ.Access.Agent.GetFromAgentId(this.AgentId);
            if (Agent != null)
            {
                if(Agent.acID != null)
                    Agency = REIQ.Access.Agency.GetFromAgencyId((int)Agent.acID);
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion
}