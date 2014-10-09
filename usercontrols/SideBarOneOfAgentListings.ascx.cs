using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SideBarOneOfAgentListings : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
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

    protected int NumOfProps { get; set; }
    protected int FPid { get; set; }

    protected REIQ.Entities.Agent Agent { get; set; }
    protected REIQ.Entities.Property Property { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Agent = REIQ.Access.Agent.GetFromAgentId(this.AgentId);
            if (Agent  != null)
            {
                Int32 featuredPropertyID = 0;
                //Getting featured propertyID
                if (Agent.featurepid != null)
                {
                    if (Agent.featurepid > 0)
                        featuredPropertyID = (int)Agent.featurepid;
                }
                //If no featured PropertyId defined - try get random PropertyID for this agent
                if(featuredPropertyID == 0) featuredPropertyID = REIQ.Access.Agent.GetRandomPropertyIdByAgent(AgentId);

                if (featuredPropertyID > 0)
                {
                    Property = REIQ.Access.Property.GetFromPropertyId(featuredPropertyID);
                }
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    #endregion
}