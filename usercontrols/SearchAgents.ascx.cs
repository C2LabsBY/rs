using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FindAnAgent.BusinessLogic;
using Utilities;
using System.Configuration;


public partial class usercontrols_SearchAgents : System.Web.UI.UserControl
{
    #region Properties

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                int gridSize = 0;
                if (!int.TryParse(ConfigurationManager.AppSettings["FindAnAgent.GridSize"], out gridSize)) gridSize = 20;
                ResultsGridView.PageSize = gridSize;

                OfficeActivityListBox.DataSource = ActivityHelper.GetActivities();
                OfficeActivityListBox.DataBind();

                OfficeActivityListBox.Items.Insert(0, new ListItem("(Any)", string.Empty));
                OfficeActivityListBox.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }
    protected void SearchCustomValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = AgencyNameTextBox.Text.Length > 0 || TownSuburbTextBox.Text.Length > 0 || PostCodeTextBox.Text.Length > 0 || FirstNameTextBox.Text.Length > 0 || LastNameTextBox.Text.Length > 0 || GetSelectedActivities().Count > 0;
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                ResultsGridView.PageIndex = 0;
                GridBind();
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    protected void ResultsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
        {
            Agent agent = e.Row.DataItem as Agent;

            if (agent != null)
            {

                if (string.IsNullOrWhiteSpace(agent.Email))
                    e.Row.Cells[4].Text = "";

                if (string.IsNullOrWhiteSpace(agent.Website))
                    e.Row.Cells[5].Text = "";
            }

        }
    }

    protected void ResultsGridView_DataBound(object sender, EventArgs e)
    {
        if (ResultsGridView.BottomPagerRow != null)
            ResultsGridView.BottomPagerRow.Visible = true;
    }

    protected void ResultsObjectDataSource_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        Agents agents;

        agents = Session["AgentsViewState"] as Agents;

        if (agents == null)
        {
            agents = new Agents();
        }
        e.ObjectInstance = agents;
    }

    protected void ResultsObjectDataSource_OnSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["activities"] = GetSelectedActivities();
    }

    private List<string> GetSelectedActivities()
    {
        List<string> selectedActivities = new List<string>();
        foreach (ListItem item in OfficeActivityListBox.Items)
            if (item.Selected && !string.IsNullOrWhiteSpace(item.Value)) selectedActivities.Add(item.Value);
        return selectedActivities;
    }

    protected void ResultsObjectDataSource_ObjectDisposing(object sender, ObjectDataSourceDisposingEventArgs e)
    {
        Agents agents = e.ObjectInstance as Agents;

        if (Session["AgentsViewState"] as Agents == null)
        {
            Session["AgentsViewState"] = agents;
        }

        e.Cancel = true;
    }

    #endregion

    #region Page Methods

    private void GridBind()
    {
        //ResultsObjectDataSource.Select();
        if (string.IsNullOrWhiteSpace(ResultsGridView.DataSourceID)) ResultsGridView.DataSourceID = "ResultsObjectDataSource";
        //int hhh = ResultsGridView.Rows.Count; ;
        ResultsDiv.Visible = true;
        ResultsUpdatePanel.Update();
    }

    #endregion
}
