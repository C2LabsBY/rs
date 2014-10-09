using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for clsTopSpot
/// </summary>
public class clsTopSpot
{
    //This is for :-tbltopspot
    public string strTopspotid;
    public string strOrderid;
    public string strAcid;
    public string strSuburbid;

    public string strSuburb;
    public string strpostcode;

    public string strOptions;
    public string strOptionsaid;
    public string strOptionspid;
    public string strStartdate;
    public string strExpdate;

    public string strEnddate;
    public string strCategory;


    public string connectionString;
    public SqlConnection connection;
    SqlCommand command;
    SqlDataAdapter objAdapter;
    DataSet objDS;
    DataTable objDT;
    private int intRecords;

    public clsTopSpot()
    {
        //Note:-This will add in class constructor:
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }

    public DataTable SelectTopspot()
    {
        command = new SqlCommand("tbltopspot_Select", connection);
        command.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(strTopspotid))
            command.Parameters.Add(new SqlParameter("@Topspotid", strTopspotid));

        if (!string.IsNullOrEmpty(strCategory))
            command.Parameters.Add(new SqlParameter("@Category", strCategory));

        if (!string.IsNullOrEmpty(strOrderid))
            command.Parameters.Add(new SqlParameter("@Orderid", strOrderid));
        if (!string.IsNullOrEmpty(strAcid))
            command.Parameters.Add(new SqlParameter("@Acid", strAcid));
        if (!string.IsNullOrEmpty(strSuburbid))
            command.Parameters.Add(new SqlParameter("@Suburbid", strSuburbid));
        if (!string.IsNullOrEmpty(strSuburb))
            command.Parameters.Add(new SqlParameter("@Suburb", strSuburb));
        if (!string.IsNullOrEmpty(strpostcode))
            command.Parameters.Add(new SqlParameter("@postcode", strpostcode));
        if (!string.IsNullOrEmpty(strOptions))
            command.Parameters.Add(new SqlParameter("@Options", strOptions));
        if (!string.IsNullOrEmpty(strOptionsaid))
            command.Parameters.Add(new SqlParameter("@Optionsaid", strOptionsaid));
        if (!string.IsNullOrEmpty(strOptionspid))
            command.Parameters.Add(new SqlParameter("@Optionspid", strOptionspid));
        if (!string.IsNullOrEmpty(strStartdate))
            command.Parameters.Add(new SqlParameter("@Startdate", GetStandardDateForSelect(strStartdate)));
        if (!string.IsNullOrEmpty(strEnddate))
            command.Parameters.Add(new SqlParameter("@Enddate", GetStandardDateForSelect(strEnddate)));
        objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objDS = new DataSet();
        objDT = new DataTable();
        objAdapter.Fill(objDS, "Topspot");
        objDT = objDS.Tables["Topspot"];
        return objDT;
    }

    public int UpdateTopSpothit(string topspotid)
    {
        command = new SqlCommand("spInsertHitTopSpot", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@topspotid", topspotid)); 

        OpenConnection();
    
        intRecords = command.ExecuteNonQuery();
       
        command.Dispose();
        CloseConnection();
        return intRecords;
    }

    private void OpenConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }
    }
    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }
    public string GetStandardDate(string strDate)
    {
        string[] str = strDate.Split(' ');
        if (str.Length > 2)
        {
            string[] str1 = str[0].Split('/');
            string[] str2 = str[1].Split(':');

            return str1[2] + "/" + str1[1] + "/" + str1[0] + " " + str2[0] + ":" + str2[1] + ":" + str2[2] + " " + str[2];
        }
        else if (str.Length > 1)
        {
            string[] str1 = str[0].Split('/');
            string[] str2 = str[1].Split(':');

            return str1[2] + "/" + str1[1] + "/" + str1[0] + " " + str2[0] + ":" + str2[1] + ":" + str2[2];
        }
        else
        {
            string[] str1 = str[0].Split('/');

            return str1[2] + "/" + str1[1] + "/" + str1[0] + " 00:00:00";
        }
    }

    public string GetStandardDateForSelect(string strDate)
    {
        return strDate;
    }
}