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


public partial class usercontrols_SuburbProfileSmall : System.Web.UI.UserControl
{
    #region Properties

    /// <summary>
    /// Id of the property we want to find the agent for.  Comes from the querystring
    /// </summary>
    protected int PropertyId
    {
        get
        {
            if (_propertyId == 0)
            {
                Int32.TryParse(Request.QueryString["pID"], out _propertyId);
            }
            return _propertyId;
        }
        set { _propertyId = value; }
    }
    private int _propertyId;

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
    /// The Property itself
    /// </summary>
    protected REIQ.Entities.Property Property { get; set; }

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
            Property = REIQ.Access.Property.GetFromPropertyId(this.PropertyId);

            if (Property != null)
            {
                Suburb = REIQ.Access.Suburb.GetFromName(Property.suburb);

                if (!IsPostBack)
                {
                    //Suburb Chart stuff
                    ch = new ChartClass();
                    ch.intChartRange = Convert.ToInt32("4");

                    cboChartType.SelectedValue = ChartType.ToString();

                    if (Suburb != null)
                    {
                        DataTable dtsuburbChart = ch.GetSubrub("any", Suburb.name, Suburb.postcode == null ? "0" : Suburb.postcode.ToString());

                        if (dtsuburbChart.Rows.Count > 0)
                            chartwork(int.Parse(dtsuburbChart.Rows[0]["suburbid"].ToString()), dtsuburbChart.Rows[0]["suburbname"].ToString());
                    }
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
        if (redirectUrl.Contains("&type=")) redirectUrl = redirectUrl.Remove(redirectUrl.IndexOf('&'));
        Response.Redirect(redirectUrl + "&type=" + cboChartType.SelectedValue);
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
