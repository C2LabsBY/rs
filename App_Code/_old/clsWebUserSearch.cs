using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;

/// <summary>
/// Summary description for clsWebUserSearch
/// </summary>
public class clsWebUserSearch
{
    //This is for :-tblSearchSave
    public string strSearchid;
    public string strUserid;
    public string strSearchdate;
    public string strSearchurl;
    public string strSearchname;
    

    public string connectionString;
    public SqlConnection connection;
    SqlCommand command;
    SqlDataAdapter objAdapter;
    DataSet objDS;
    DataTable objDT;
    private int intRecords;

    private void OpenConnection()
    {
        if (connection.State == ConnectionState.Closed)
        {
            connection.Open();
        }//Created By Shrwan
    }
    public void CloseConnection()
    {
        if (connection.State == ConnectionState.Open)
        {
            connection.Close();
        }
    }//Created By Shrwan

    public clsWebUserSearch()
    {
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }
    public int InsertSearchsave()
    {
        command = new SqlCommand("spSearchSaveInsert", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Searchid", SqlDbType.Int));
        command.Parameters["@Searchid"].Direction = ParameterDirection.Output;
        if (strUserid != "")
            command.Parameters.Add(new SqlParameter("@Userid", strUserid));
        else
            command.Parameters.Add(new SqlParameter("@Userid", DBNull.Value));
        if (strSearchdate != "")
            command.Parameters.Add(new SqlParameter("@Searchdate",strSearchdate));
        else
            command.Parameters.Add(new SqlParameter("@Searchdate", DBNull.Value));

        if (strSearchname != "")
            command.Parameters.Add(new SqlParameter("@searchname", strSearchname));
        else
            command.Parameters.Add(new SqlParameter("@searchname", DBNull.Value));

        
        if (strSearchurl != "")
            command.Parameters.Add(new SqlParameter("@Searchurl", strSearchurl));
        else
            command.Parameters.Add(new SqlParameter("@Searchurl", DBNull.Value));
        OpenConnection();
        intRecords = command.ExecuteNonQuery();
        intRecords = Convert.ToInt32(command.Parameters["@Searchid"].Value);
        command.Dispose();
        CloseConnection();
        return intRecords;
    }

    public int UpdateSearchsave()
    {
        command = new SqlCommand("tblSearchSave_Update", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Searchid", strSearchid));
        if (strUserid != "")
            command.Parameters.Add(new SqlParameter("@Userid", strUserid));
        else
            command.Parameters.Add(new SqlParameter("@Userid", DBNull.Value));
        if (strSearchdate != "")
            command.Parameters.Add(new SqlParameter("@Searchdate", strSearchdate));
        else
            command.Parameters.Add(new SqlParameter("@Searchdate", DBNull.Value));

        if (strSearchname != "")
            command.Parameters.Add(new SqlParameter("@searchname", strSearchname));
        else
            command.Parameters.Add(new SqlParameter("@searchname", DBNull.Value));

        if (strSearchurl != "")
            command.Parameters.Add(new SqlParameter("@Searchurl", strSearchurl));
        else
            command.Parameters.Add(new SqlParameter("@Searchurl", DBNull.Value));
        OpenConnection();
        intRecords = command.ExecuteNonQuery();
        command.Dispose();
        CloseConnection();
        return intRecords;
    }

    public DataTable SelectSearchsave()
    {
        command = new SqlCommand("spSearchSaveSelect", connection);
        command.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(strSearchid))
            command.Parameters.Add(new SqlParameter("@Searchid", strSearchid));
        if (!string.IsNullOrEmpty(strUserid))
            command.Parameters.Add(new SqlParameter("@Userid", strUserid));
        if (!string.IsNullOrEmpty(strSearchdate))
            command.Parameters.Add(new SqlParameter("@Searchdate", strSearchdate));
        if (!string.IsNullOrEmpty(strSearchurl))
            command.Parameters.Add(new SqlParameter("@Searchurl", strSearchurl));
        objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objDS = new DataSet();
        objDT = new DataTable();
        objAdapter.Fill(objDS, "Searchsave");
        objDT = objDS.Tables["Searchsave"];
        return objDT;
    }

    public int DeleteSearchsave()
    {
        command = new SqlCommand("spSearchSaveDelete", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@Searchid", strSearchid));
        OpenConnection();
        intRecords = command.ExecuteNonQuery();
        command.Dispose();
        CloseConnection();
        return intRecords;
    }

    public string GetStandardDate(string strDate)
    {
        DateTime dt = Convert.ToDateTime(strDate);
        return dt.Year.ToString() + "/" + dt.Month.ToString("#00") + "/" + dt.Day.ToString("#00");
    }
    public string GetStandardDateForSelect(string strDate)
    {
        DateTime dt = Convert.ToDateTime(strDate);
        return dt.Day.ToString("#00") + "/" + dt.Month.ToString("#00") + "/" + dt.Year.ToString();
    }



}
