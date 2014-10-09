using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_ClickToCallStats : System.Web.UI.UserControl
{
    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //set default values for date fields
            DateTime today = DateTime.Today;
            StartDatePicker.SelectedDate = today.AddYears(-1);
            StartDatePicker.MinDate = today.AddYears(-1);
            StartDatePicker.MaxDate = today;
            EndDatePicker.SelectedDate = today;
            EndDatePicker.MinDate = today.AddYears(-1);
            EndDatePicker.MaxDate = today;

            BindForm();
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DateTime validDate;
        if(!DateTime.TryParse(StartDatePicker.SelectedDate.ToString(), out validDate))
        {
            EmptySummaries();
            return;
        }
        if (!DateTime.TryParse(EndDatePicker.SelectedDate.ToString(), out validDate))
        {
            EmptySummaries();
            return;
        }
        BindForm();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Export("ClickToCallStats", GridView1);
        }
        catch
        {

        }
    }

    #endregion

    #region Page Methods

    public void Export(string fileName, GridView gv)
    {
        DataSourceSelectArguments args = new DataSourceSelectArguments();
        fileName = fileName.Replace(" ", "-") + ".xls";
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //get grid data from sql data source
                DataView dv = (DataView)dsCalickToCallStats.Select(args);
                DataView dvTotal = (DataView)dsTotal.Select(args);

                //convet gridview data to datatable type
                DataTable tbl = dv.ToTable();
                DataTable tblTotal = dvTotal.ToTable();

                //remove excess columns
                tbl.Columns.Remove("aID");
                tbl.Columns.Remove("acID");

                //fill list of clicks
                foreach (DataRow r in tbl.Rows)
                {
                    TableRow tr = new TableRow();
                        
                    for (int i = 0; i < tbl.Columns.Count; i++)
                    {
                        TableCell tc = new TableCell();
                        tc.Text = Server.HtmlEncode(r[i].ToString());
                        tr.Cells.Add(tc);
                    }
                    table.Rows.Add(tr);
                }

                //fill total information
                foreach (DataRow r in tblTotal.Rows)
                {
                    TableRow tr = new TableRow();

                    for (int i = 0; i < tblTotal.Columns.Count; i++)
                    {
                        TableCell tc = new TableCell();
                        tc.Text = Server.HtmlEncode(r[i].ToString());
                        tr.Cells.Add(tc);
                    }
                    table.Rows.Add(tr);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                PrepareControlForExport(current);
            }
        }
    }

    private void BindForm()
    {
        //Getting total of all clicks per site
        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)dsTotal.Select(args);
        DataTable dt = dv.ToTable();

        //Total information top
        int total = 0;
        litTotalAgenciesTop.Text = "Total Agencies: ";
        Int32.TryParse(dt.Rows[0]["Agencies"].ToString(), out total);
        if (total > 0)
            litTotalAgenciesTop.Text += dt.Rows[0]["Agencies"].ToString();
        else litTotalAgenciesTop.Text += "0";

        //Total agents
        total = 0;
        litTotalAgentsTop.Text = "Total Agents: ";
        Int32.TryParse(dt.Rows[0]["Agents"].ToString(), out total);
        if (total > 0)
            litTotalAgentsTop.Text += dt.Rows[0]["Agents"].ToString();
        else litTotalAgentsTop.Text += "0";

        //Total clicks
        litTotalTop.Text = "Total Clicks: ";
        Int32.TryParse(dt.Rows[0]["Total"].ToString(), out total);
        if (total > 0)
            litTotalTop.Text += dt.Rows[0]["Total"].ToString();
        else litTotalTop.Text += "0";
    }

    private void EmptySummaries()
    {
        litTotalTop.Text = "Total Clicks: 0";
        litTotalAgenciesTop.Text = "Total Agencies: 0";
        litTotalAgentsTop.Text = "Total Agents: 0";
    }

    #endregion
}