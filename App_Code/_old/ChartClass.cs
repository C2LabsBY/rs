//**************************************************************************************
// Name             :   Shrwan Kumar
// Date             :   10/November/2007
// Purpose          :   Basic Database operation for charting

// 10/November/2007   SK     C# version of component
//

//'**************************************************************************************

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ChartClass
/// </summary>
public class ChartClass
{
    public DataUtility dUT;
    public int intChartRange=1;
	
    public ChartClass()
    {
        // TODO: Add constructor logic here
        dUT = new DataUtility();
        dUT.ConnectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
	}
    public ChartClass(string conString)
    {
        dUT = new DataUtility();
        dUT.ConnectionString = conString;
    }
    public DataTable GetSubrub()
    {
        return dUT.GetDataTable("spChartSubrubSelect");
    }
    public DataTable GetChartingData(int SuburbId)
    {
        SqlParameter[] myParam = { new SqlParameter("@SuburbId", SuburbId), new SqlParameter("@IntChartRange", intChartRange) };
        return dUT.GetDataTable("spGetGraphEntry", myParam);

    }
    public DataTable GetSubrub(string strSuburbId, string strSuburbName,string strpostcode)
    {
        SqlParameter[] myParam = { new SqlParameter("@SuburbId", strSuburbId), new SqlParameter("@SuburbName", strSuburbName), new SqlParameter("@postcode", strpostcode) };
        return dUT.GetDataTable("spGetSuburbChart", myParam);

    }
    public DataTable GetAllSubrubWithdesc(string top)
    {
        SqlParameter[] myParam = { new SqlParameter("@top", top) };
        return dUT.GetDataTable("spGetSuburbwithdesc", myParam);

    }
    
    public DataTable GetSubrubSale()
    {
        return dUT.GetDataTable("spGetSuburbSale");
    }
    public DataTable GetSubrubSale(string strSuburbId, string strSuburbName)
    {
        SqlParameter[] myParam = { new SqlParameter("@SuburbSaleID", strSuburbId), new SqlParameter("@SuburbName", strSuburbName) };
        return dUT.GetDataTable("spGetSuburbSale", myParam);
    }
    public DataTable GetChartingSaleData(string suburbList)
    {
        SqlParameter[] myParam = { new SqlParameter("@SuburbList", suburbList), new SqlParameter("@SaleChart", intChartRange) };
        return dUT.GetDataTable("spGetGraphEntrySale", myParam);
    }
	public DataTable GetChartingData(int SuburbId, int chartType)
    {
        SqlParameter[] myParam = { new SqlParameter("@SuburbId", SuburbId), new SqlParameter("@IntChartRange", intChartRange), new SqlParameter("@type", chartType) };
        return dUT.GetDataTable("spGetGraphEntry", myParam);
    }
}
