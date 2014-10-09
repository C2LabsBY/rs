using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_OurTeam : System.Web.UI.UserControl
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

    /// <summary>
    /// The Agency itself
    /// </summary>
    protected REIQ.Entities.Agency Agency { get; set; }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide Our Team unless the "showTeam=1" parameter provided in queryString
        if (Request.QueryString["showTeam"] == "1")
            pnlOurTeam.Visible = true;
        else return;

        try
        {
            if (!IsPostBack)
            {
                Agency = REIQ.Access.Agency.GetFromAgencyId(this.AgencyId);

                //Our team init
                if (Agency != null)
                {
                    rptAgent.DataSource = REIQ.Access.Agency.GetOfficeAgentsImisProfile(this.AgencyId);
                    rptAgent.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    protected void rptAgent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            REIQ.Entities.Agent agent = (REIQ.Entities.Agent)e.Item.DataItem;

            Literal litTeamContent = e.Item.FindControl("litTeamContent") as Literal;

            litTeamContent.Text = REIQ.Helpers.AgencyHelper.GetAgentDetail(
                agent.acID.ToString(),
                agent.aID.ToString(),
                agent.firstname + " " + agent.surname,
                bool.Parse(agent.hasPhoto.ToString()),
                agent.phone,
                agent.mobile,
                agent.email,
                (bool?)agent.hidemobile,
                Agency.suburb);
        }
    }
    #endregion
}