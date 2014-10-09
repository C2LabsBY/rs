using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class usercontrols_SuburbSearchStats : System.Web.UI.UserControl
{
    protected String SuburbName
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["su"]))
                return Request.QueryString["su"];

            return String.Empty;
        }
    }

    //chart variables
    public string maxNumberOfClicks = "0";
    public string rotate = "1";
    public List<REIQ.Access.Suburb.SuburbChartData> chartDataList = new List<REIQ.Access.Suburb.SuburbChartData>();
    public int intNoOfRow = 12;
    public string StrPrCission = "decimalPrecision = '0' formatNumberScale='0'";
    public string Suburb = String.Empty;

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        Suburb = SuburbName;

        if (!IsPostBack)
        {
            //set values for date fields
            DateTime today = DateTime.Today;
            DateTime tmpDate;
            if (!String.IsNullOrEmpty(Request.QueryString["stdate"]))
            {
                DateTime.TryParse(Request.QueryString["stdate"], out tmpDate);
                StartDatePicker.SelectedDate = tmpDate;
            }
            else StartDatePicker.SelectedDate = today.AddYears(-1) < new DateTime(2013, 11, 1) ? new DateTime(2013, 11, 1) : today.AddYears(-1);

            StartDatePicker.MinDate = today.AddYears(-1) < new DateTime(2013, 11, 1) ? new DateTime(2013, 11, 1) : today.AddYears(-1);
            StartDatePicker.MaxDate = today;

            if (!String.IsNullOrEmpty(Request.QueryString["enddate"]))
            {
                DateTime.TryParse(Request.QueryString["enddate"], out tmpDate);
                EndDatePicker.SelectedDate = tmpDate;
            }
            else EndDatePicker.SelectedDate = today;

            EndDatePicker.MinDate = today.AddYears(-1) < new DateTime(2013, 11, 1) ? new DateTime(2013, 11, 1) : today.AddYears(-1);
            EndDatePicker.MaxDate = today;

            FillControls();

            if (!String.IsNullOrEmpty(SuburbName))
            {
                GridView1.Visible = false;
                litTotalTop.Visible = false;
                litTotalSuburbs.Visible = false;
                BuildChart(SuburbName, Request.QueryString["stdate"], Request.QueryString["enddate"]);
            }
            BindForm();

            if (cboSuburbName.SelectedValue.ToString() == "" || cboSuburbName.SelectedValue.ToString() == "%") btnShowAll.Visible = false;
            else btnShowAll.Visible = true;
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        DateTime validDate;

        if (cboSuburbName.SelectedValue.ToString() == "" || cboSuburbName.SelectedValue.ToString() == "%") btnShowAll.Visible = false;
        else btnShowAll.Visible = true;

        //checkValidDate(StartDatePicker.SelectedDate)

        if (StartDatePicker.SelectedDate < StartDatePicker.MinDate || StartDatePicker.SelectedDate > StartDatePicker.MaxDate)
        {
            EmptySummaries();
            return;
        }

        if (EndDatePicker.SelectedDate < EndDatePicker.MinDate || EndDatePicker.SelectedDate > EndDatePicker.MaxDate)
        {
            EmptySummaries();
            return;
        }

        if (!DateTime.TryParse(StartDatePicker.SelectedDate.ToString(), out validDate))
        {
            EmptySummaries();
            return;
        }
        if (!DateTime.TryParse(EndDatePicker.SelectedDate.ToString(), out validDate))
        {
            EmptySummaries();
            return;
        }
        GridView1.Visible = true;
        litTotalTop.Visible = true;
        litTotalSuburbs.Visible = true;
        Suburb = String.Empty;
        BindForm();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            Export("SuburbSearchStats", GridView1);
        }
        catch
        {

        }
    }

    protected void btnBuildChart_Click(object sender, EventArgs e)
    {
        if (cboSuburbName.SelectedValue.ToString() == "")
        {
            Suburb = String.Empty;
            return;
        }

        Response.Redirect(Request.Path.ToString() + "?su=" + cboSuburbName.SelectedValue.ToString() + "&stdate=" + StartDatePicker.SelectedDate.ToString() + "&enddate=" + EndDatePicker.SelectedDate.ToString());
    }

    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.Path.ToString());
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(e.Row.Cells[0].Text.ToLower());
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
                DataView dv = (DataView)dsSuburbSearchStats.Select(args);
                DataView dvTotal = (DataView)dsTotal.Select(args);

                //convet gridview data to datatable type
                DataTable tbl = dv.ToTable();
                DataTable tblTotal = dvTotal.ToTable();

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

    private void FillControls()
    {
        //getting all suburbs for "suburb" dropdown
        cboSuburbName.Items.Add(new ListItem("Select Suburb", "%"));
        foreach (REIQ.Entities.Suburb suburb in REIQ.Access.Suburb.GetSearchedSuburbs())
        {
            cboSuburbName.Items.Add(new ListItem(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(suburb.name.ToLower()), suburb.name));
        }
        cboSuburbName.DataBind();

        cboSuburbName.SelectedValue = SuburbName;
    }

    private void BindForm()
    {
        //String suburbValue = String.Empty;
        //String query = String.Empty;
        //if (cboSuburbName.SelectedValue != "")
        //{
        //    if (dsSuburbSearchStats.SelectParameters.Count < 3)
        //        dsSuburbSearchStats.SelectParameters.Add("SuburbName", cboSuburbName.SelectedValue);
        //    suburbValue = " AND tlss.name LIKE @SuburbName";
        //    query = "SELECT tlss.name as Name, COUNT(tlss.name) as Count FROM tblLogSuburbSearch as tlss WITH (NOLOCK) WHERE tlss.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo)" + suburbValue + " GROUP BY tlss.name ORDER BY tlss.name ASC";
        //}
        //else
        //{
        //    suburbValue = " AND tlss.name is not null";
        //    query = "SELECT tlss.name as Name, COUNT(tlss.name) as Count FROM tblLogSuburbSearch as tlss WITH (NOLOCK) WHERE tlss.date BETWEEN @DateFrom AND DATEADD(day, 1, @DateTo)" + suburbValue + " GROUP BY tlss.name ORDER BY tlss.name ASC";
        //}

        //dsSuburbSearchStats.SelectCommand = query;
        //dsSuburbSearchStats.DataBind();

        //Getting total of all clicks per site
        DataSourceSelectArguments args = new DataSourceSelectArguments();
        DataView dv = (DataView)dsTotal.Select(args);
        DataTable dt = dv.ToTable();

        //Total information top
        int total = 0;
        litTotalSuburbs.Text = "Total Suburbs: ";
        Int32.TryParse(dt.Rows[0]["Name"].ToString(), out total);
        if (total > 0)
            litTotalSuburbs.Text += dt.Rows[0]["Name"].ToString();
        else litTotalSuburbs.Text += "0";

        ////Total clicks
        litTotalTop.Text = "Total Searches: ";
        Int32.TryParse(dt.Rows[0]["Total"].ToString(), out total);
        if (total > 0)
            litTotalTop.Text += dt.Rows[0]["Total"].ToString();
        else litTotalTop.Text += "0";
    }

    private void BuildChart(string suburbName, string startDate, string endDate)
    {
        chartDataList = REIQ.Access.Suburb.GetChartSuburbSearchStats(suburbName, startDate, endDate);
        intNoOfRow = chartDataList.Count;

        maxNumberOfClicks = FindMaxRange(chartDataList);
    }

    public string FindMaxRange(List<REIQ.Access.Suburb.SuburbChartData> list)
    {
        int max = 0;
        foreach (REIQ.Access.Suburb.SuburbChartData row in list)
        {
            if (row.NumberOfClicks > max)
            {
                max = row.NumberOfClicks;
            }
        }

        if (max * 10 / 100 == 0) max++;
            else max = max + max * 10 / 100;
        return max.ToString() ;
    }

    public string ChartAmounts()
    {
        string str = "";
        if (chartDataList != null)
        {
            foreach (REIQ.Access.Suburb.SuburbChartData row in chartDataList)
            {
                str += row.NumberOfClicks.ToString() + ",";
            }
        }

        if (str.Length > 0)
            str = str.Substring(0, str.Length - 1);
        return str;
    }

    public string GetQtrName()
    {
        string str = "";
        if (chartDataList != null)
        {
            foreach (REIQ.Access.Suburb.SuburbChartData row in chartDataList)
            {
                str += "<category name='" + row.Date.ToString("MMMM, dd yyyy") + "' />,";
            }
        }
        if (str.Length > 0)
            str = str.Substring(0, str.Length - 1);
        return str + " ";
    }

    private void EmptySummaries()
    {
        GridView1.Visible = false;
        litTotalTop.Text = "Total Searches: 0";
        litTotalSuburbs.Text = "Total Suburbs: 0";
    }

    #endregion
}