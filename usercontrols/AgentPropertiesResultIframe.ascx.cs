using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using REIQ.Access;
using REIQ.Helpers;

public partial class usercontrols_AgentPropertiesResultIframe : REIQ.usercontrols.PropertySearchBase
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

    public Int32 PageSize { get; set; }

    /// <summary>
    /// The Agent itself
    /// </summary>
    protected REIQ.Entities.Agent Agent { get; set; }

    #endregion

    #region Page Events

    protected override void OnInit(EventArgs e)
    {
        Agent = REIQ.Access.Agent.GetFromAgentId(this.AgentId);

        if (Agent != null)
        {
            var propertyIds = REIQ.Access.Agent.GetPropertiesIdByAgentId(AgentId);

            if (propertyIds.Count() == 0)
            {
                lblNoResults.Visible = true;
                return;
            }

            // put the search results into request context so we can access them from the other controls
            base.RememberPropertyIds(propertyIds);

            var properties = REIQ.Access.Property.ListForDisplay(propertyIds, ParamSort, ParamPageNumber, PageSize);

            rptProperties.DataSource = properties;
            rptProperties.DataBind();

            base.OnInit(e);
        }
    }

    protected void rptProperties_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            REIQ.Entities.Property property = (REIQ.Entities.Property)e.Item.DataItem;

            Literal litAgencyImage = e.Item.FindControl("litAgencyImage") as Literal;

            if (property.acID > 0)
            {
                REIQ.Entities.Agency agency = REIQ.Access.Agency.GetFromPropertyId(property.pID);
                litAgencyImage.Text = "<a href='/" + REIQ.Helpers.PropertyHelper.GenerateURLAgency(agency.name.ToString(), property.suburb.ToString(), property.acID) + "'><img src=" + Images.GetAgencyImage(property.acID, 196, 88) + " class='agent-logo'/></a>";
            }
        }
    }

    #endregion

    #region Page Methods

    protected string getPriceText(object item)
    {
        REIQ.Entities.Property property = (REIQ.Entities.Property)item;

        return PropertyHelper.GetPropertyPrice(property);
    }

    #endregion
}