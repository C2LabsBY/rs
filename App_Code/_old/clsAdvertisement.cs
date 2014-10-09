using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


/// <summary>
/// Summary description for clsAdvertisement
/// </summary>
public class clsAdvertisement
{
    //This is for :-tblAdvertiesment
    public string strAdid;
    public string strAdtype;
    public string strOrderid;
    public string strSuburbid;
    public string strImgurl;
    public string strAlttext;
    public string strLink;
    public string strStartdate;
    public string strExpdate;

    public string strRegion;
    public string strCategory;

    public string strsuburbforregion;
    public string strpostcodeforregion;

    public string strEnddate;
    public string strflagvalid;

    public string strSuburb;
    public string strpostcode;

    public string connectionString;
    public SqlConnection connection;
    SqlCommand command;
    SqlDataAdapter objAdapter;
    DataSet objDS;
    DataTable objDT;
    private int intRecords;

    public clsAdvertisement()
    {
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }


    public DataTable SelectAdvertiesment()
    {
        command = new SqlCommand("tblAdvertiesment_Select", connection);
        command.CommandType = CommandType.StoredProcedure;
        if (!string.IsNullOrEmpty(strAdid))
            command.Parameters.Add(new SqlParameter("@Adid", strAdid));
        if (!string.IsNullOrEmpty(strAdtype))
            command.Parameters.Add(new SqlParameter("@Adtype", strAdtype));
        if (!string.IsNullOrEmpty(strOrderid))
            command.Parameters.Add(new SqlParameter("@Orderid", strOrderid));
        if (!string.IsNullOrEmpty(strSuburbid))
            command.Parameters.Add(new SqlParameter("@Suburbid", strSuburbid));

        if (!string.IsNullOrEmpty(strSuburb))
            command.Parameters.Add(new SqlParameter("@Suburb", strSuburb));

        if (!string.IsNullOrEmpty(strpostcode))
            command.Parameters.Add(new SqlParameter("@postcode", strpostcode));

        if (!string.IsNullOrEmpty(strImgurl))
            command.Parameters.Add(new SqlParameter("@Imgurl", strImgurl));
        if (!string.IsNullOrEmpty(strAlttext))
            command.Parameters.Add(new SqlParameter("@Alttext", strAlttext));
        if (!string.IsNullOrEmpty(strLink))
            command.Parameters.Add(new SqlParameter("@Link", strLink));
        if (!string.IsNullOrEmpty(strStartdate))
            command.Parameters.Add(new SqlParameter("@Startdate", strStartdate));
        if (!string.IsNullOrEmpty(strEnddate))
            command.Parameters.Add(new SqlParameter("@Enddate", strEnddate));

        if (!string.IsNullOrEmpty(strflagvalid))
            command.Parameters.Add(new SqlParameter("@flagvalid", strflagvalid));


        if (!string.IsNullOrEmpty(strRegion))
            command.Parameters.Add(new SqlParameter("@Region", strRegion));

        if (!string.IsNullOrEmpty(strCategory))
            command.Parameters.Add(new SqlParameter("@Category", strCategory));        

        if (!string.IsNullOrEmpty(strsuburbforregion))
            command.Parameters.Add(new SqlParameter("@suburbforregion", strsuburbforregion));

        if (!string.IsNullOrEmpty(strpostcodeforregion))
            command.Parameters.Add(new SqlParameter("@postcodeforregion", strpostcodeforregion));


        objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objDS = new DataSet();
        objDT = new DataTable();
        objAdapter.Fill(objDS, "Advertiesment");
        objDT = objDS.Tables["Advertiesment"];
        return objDT;
    }

    public int UpdateAdverthit(string adid)
    {
        command = new SqlCommand("spInsertHitAdvert", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add(new SqlParameter("@adid", adid));

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

    public string getnamefromtype(string type)
    {
        if (type.ToLower() == "toweradhome")
        {
            return "Tower ad on homepage";
        }
        else if (type.ToLower() == "toweradlist")
        {
            return "Tower ads on listings results page";
        }
        else if (type.ToLower() == "banneradgap")
        {
            return "Banner ads within search results";
        }

        return "";

    }
}