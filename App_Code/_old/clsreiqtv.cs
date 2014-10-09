using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for clsreiqtv
/// </summary>
public class clsreiqtv
{

    //This is for :-REIQ TV
    public string strvideoid;
    public string strBroadCastingDate;
    public string strheading;
    public string strdesciption;
    public string strtimeinsecs;
    public string strthumb;
    public string strurl;
    public string striswebdisplay;
    public string stryear;
    public string strflaglastvideo;
    public string strexcludeid;
    public string strflaglive;


    public string connectionString;
    public SqlConnection connection;
    SqlCommand command;
    SqlDataAdapter objAdapter;
    DataSet objDS;
    DataTable objDT;
    private int intRecords;

    public clsreiqtv()
    {
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }

   

    public DataTable SelectREIQTV()
    {
        command = new SqlCommand("spSelectReiqtv", connection);
        command.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(strvideoid))
            command.Parameters.Add(new SqlParameter("@videoid", strvideoid));
        if (!string.IsNullOrEmpty(striswebdisplay))
            command.Parameters.Add(new SqlParameter("@iswebdisplay", striswebdisplay));
        if (!string.IsNullOrEmpty(stryear))
            command.Parameters.Add(new SqlParameter("@year", stryear));
        if (!string.IsNullOrEmpty(strflaglastvideo))
            command.Parameters.Add(new SqlParameter("@flaglastvideo", strflaglastvideo));
        if (!string.IsNullOrEmpty(strexcludeid))
            command.Parameters.Add(new SqlParameter("@excludeid", strexcludeid));
        if (!string.IsNullOrEmpty(strflaglive))
            command.Parameters.Add(new SqlParameter("@flaglive", strflaglive));
        
        

        objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objDS = new DataSet();
        objDT = new DataTable();
        objAdapter.Fill(objDS, "reiqtv");
        objDT = objDS.Tables["reiqtv"];
        return objDT;
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