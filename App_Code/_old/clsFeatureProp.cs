using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
/// <summary>
/// Summary description for clsFeatureProp
/// </summary>
public class clsFeatureProp
{
    //This is for :-tblfeatureprop
    public string strFid;
    public string strAcid;
    public string strPid1;
    public string strPid2;
    public string strStartdate;
    public string strExpdate;

    public string strEnddate;

    public string connectionString;
    public SqlConnection connection;
    SqlCommand command;
    SqlDataAdapter objAdapter;
    DataSet objDS;
    DataTable objDT;
    private int intRecords;


	public clsFeatureProp()
	{
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
	}

    
    public DataTable SelectFeatureprop()
    {
        command = new SqlCommand("tblfeatureprop_Select", connection);
        command.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(strFid))
            command.Parameters.Add(new SqlParameter("@Fid", strFid));
        if (!string.IsNullOrEmpty(strAcid))
            command.Parameters.Add(new SqlParameter("@Acid", strAcid));
        if (!string.IsNullOrEmpty(strPid1))
            command.Parameters.Add(new SqlParameter("@Pid1", strPid1));
        if (!string.IsNullOrEmpty(strPid2))
            command.Parameters.Add(new SqlParameter("@Pid2", strPid2));
        if (!string.IsNullOrEmpty(strStartdate))
            command.Parameters.Add(new SqlParameter("@Startdate", strStartdate));
        if (!string.IsNullOrEmpty(strEnddate))
            command.Parameters.Add(new SqlParameter("@Enddate", strEnddate));
        objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objDS = new DataSet();
        objDT = new DataTable();
        objAdapter.Fill(objDS, "Featureprop");
        objDT = objDS.Tables["Featureprop"];
        return objDT;
    }

    public int UpdateFeaturehit(string fid)
    {
        command = new SqlCommand("spInsertHitFeature", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@fid", fid));

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