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


public partial class usercontrols_SuburbProfile : System.Web.UI.UserControl
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
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int ChartType
    {
        get
        {
            if (Int32.TryParse(Request.QueryString["type"], out _chartType))
                return _chartType;
            return 1;
        }
    }
    private int _chartType;

    /// <summary>
    /// Property suburb
    /// </summary>
    protected REIQ.Entities.Suburb Suburb { get; set; }

    // for chart
    public string maxvalue = "0";
    public string rotate = "1";
    public DataTable dt = new DataTable();
    ChartClass ch;
    public int charttype = 6;
    public int[] suburbid = { 0, 0, 0, 0, 0 };
    public int intNoOfRow = 12;
    public string[] suburbName = { "", "", "", "", "" };
    public string StrPrCission = "decimalPrecision = '0' formatNumberScale='0'";

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Suburb = REIQ.Access.Suburb.GetFromName(SuburbName);

            if (!IsPostBack)
            {
                //Binding Suburbs
                //DataTable dtsuburb = ch.GetAllSubrubWithdesc("1000");

                //ahc.connection.Close();

                //for (int i = 0; i < dtsuburb.Rows.Count; i++)
                //{
                //    cboSuburbInfo.Items.Add(new ListItem(dtsuburb.Rows[i]["name"].ToString() + ", " + dtsuburb.Rows[i]["postcode"].ToString(), dtsuburb.Rows[i]["sid"].ToString()));
                //}

                //cboSuburbInfo.DataSource = REIQ.Access.Suburb.GetAllSuburbsByTop(1000);

                //cboSuburbInfo.Items.Insert(0, new ListItem("-Select Suburb-", ""));
                //cboSuburbInfo.DataBind();


                //Bedrooms setup
                cboSuburbInfo.Items.Add(new ListItem("Select Suburb", ""));
                foreach (REIQ.Entities.Suburb suburb in REIQ.Access.Suburb.GetAllSuburbsByTop(2000))
                {
                    cboSuburbInfo.Items.Add(new ListItem(suburb.name, suburb.name));
                }
                cboSuburbInfo.DataBind();

                cboSuburbInfo.SelectedValue = SuburbName;


                //if (!String.IsNullOrEmpty(Request.QueryString["su"]) && Request.QueryString["postcode"] != null)
                //{
                //    strSearchSuburb = Request.QueryString["su"].ToString();
                //    strSearchPostcode = Request.QueryString["postcode"].ToString();
                //}
                //else
                //{
                //    //cboSuburbInfo.SelectedIndex = 1;

                //    //DataRow[] drsuburb = dtsuburb.Select("sid=" + cboSuburbInfo.SelectedValue);

                //    //strSearchSuburb = drsuburb[0]["name"].ToString();
                //    //strSearchPostcode = drsuburb[0]["postcode"].ToString();
                //}

                //Suburb Chart stuff
                ch = new ChartClass();
                ch.intChartRange = Convert.ToInt32("4");

                cboChartType.SelectedValue = ChartType.ToString();

                if (Suburb != null)
                {
                    DataTable dtsuburbChart = ch.GetSubrub("any", Suburb.name, Suburb.postcode == null ? "0" : Suburb.postcode.ToString());

                    if(dtsuburbChart.Rows.Count > 0)
                        chartwork(int.Parse(dtsuburbChart.Rows[0]["suburbid"].ToString()), dtsuburbChart.Rows[0]["suburbname"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            AutoMail.sendErrorMail(ex);
        }
    }

    protected void btnView_onClick(object sender, EventArgs e)
    {
        String redirectUrl = Request.RawUrl;
        if (redirectUrl.Contains("?")) redirectUrl = redirectUrl.Remove(redirectUrl.IndexOf('?'));
        Response.Redirect(redirectUrl + "?su=" + cboSuburbInfo.SelectedValue + "&type=" + cboChartType.SelectedValue);
    }

    #endregion

    #region Page Methods

    public string GetQtrName()
    {
        string str = "";
        if (dt != null)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str += "<category name='" + dt.Rows[i]["qtrName"].ToString() + "' />,";
            }
        }
        if (str.Length > 0)
            str = str.Substring(0, str.Length - 1);
        return str + " ";

    }

    private void chartwork(int suburbId, string suburbName)
    {
        dt = ch.GetChartingData(suburbId, ChartType);
        intNoOfRow = dt.Rows.Count;

        DataView temp = dt.DefaultView;
        temp.Sort = "Amount desc";

        if (Convert.ToInt32(maxvalue) < Convert.ToInt32(temp.Table.Rows[0][1]))
        {
            maxvalue = temp.Table.Rows[0][1].ToString();

            int tempmaxvalue = Convert.ToInt32(maxvalue);
            string mod = "1";
            for (int g = 0; g < maxvalue.Length - 1; g++)
            {
                mod += "0";
            }

            tempmaxvalue = tempmaxvalue + (Convert.ToInt32(mod) - (tempmaxvalue % Convert.ToInt32(mod)));

            maxvalue = tempmaxvalue.ToString();
        }
    }

    public string SuburbAmount()
    {
        string str = "";
        if (dt != null)
        {
            int countdata = 0;
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["Amount"].ToString() != "" && dt.Rows[j]["Amount"].ToString() != "0")
                {
                    countdata++;
                }
            }
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (countdata > 0)
                {
                    str += dt.Rows[j]["Amount"].ToString() + ",";
                }
            }
        }

        if (str.Length > 0)
            str = str.Substring(0, str.Length - 1);
        return str;
    }

    #endregion
}
