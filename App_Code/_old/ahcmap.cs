using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using System.Xml;
using System.Net;

/// <summary>
/// Summary description for ahcmap
/// </summary>
public class ahcmap
{
    // address
    public string strName;
    public string strStatus;
    public string strUnitNum;
    public string strRoadNum;
    public string strRoadName;
    public string strRoadType;
    public string strState, strPostal, strCountry;
    public string strSuburb;
    public Boolean blHideRoadNum;
    public Boolean blHideRoadName;
    public string address = "";

    //homeopen    
    public string homeopen = "";
    public string stime = "";
    public string etime = "";
    public DateTime strHomeopen1From;
    public DateTime strHomeopen1To;
    public DateTime strHomeopen2From;
    public DateTime strHomeopen2To;


    //connection strings
    public SqlConnection connection;
    public string connectionString;
    public ahcmap()
    {
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
    }
    public void getProperty(string pID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spgetProperties", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@pid", pID));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("name")))
            {
                strName = reader.GetString(reader.GetOrdinal("name"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("unitNum")))
            {
                strUnitNum = reader.GetString(reader.GetOrdinal("unitNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdNum")))
            {
                strRoadNum = reader.GetString(reader.GetOrdinal("rdNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdName")))
            {
                strRoadName = reader.GetString(reader.GetOrdinal("rdName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("rdType")))
            {
                strRoadType = reader.GetString(reader.GetOrdinal("rdType"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                strStatus = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburb")))
            {
                strSuburb = reader.GetString(reader.GetOrdinal("suburb"));
            }

            if (!reader.IsDBNull(reader.GetOrdinal("state")))
            {
                strState = reader.GetString(reader.GetOrdinal("state"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("postcode")))
            {
                strPostal = reader.GetString(reader.GetOrdinal("postcode"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("country")))
            {
                strCountry = reader.GetString(reader.GetOrdinal("country"));
            }


            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadNum")))
            {
                blHideRoadNum = reader.GetBoolean(reader.GetOrdinal("hideRoadNum"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("hideRoadName")))
            {
                blHideRoadName = reader.GetBoolean(reader.GetOrdinal("hideRoadName"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2To")))
            {
                strHomeopen2To = reader.GetDateTime(reader.GetOrdinal("homeopen2To"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen2From")))
            {
                strHomeopen2From = reader.GetDateTime(reader.GetOrdinal("homeopen2From"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1To")))
            {
                strHomeopen1To = reader.GetDateTime(reader.GetOrdinal("homeopen1To"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("homeopen1From")))
            {
                strHomeopen1From = reader.GetDateTime(reader.GetOrdinal("homeopen1From"));
            }

        }
        connection.Close();
        address = getAddress(strName, "", strRoadNum, strRoadName, strRoadType, strSuburb, strState, strPostal, strCountry, blHideRoadName, blHideRoadNum);



    }
    public string getAddress(string strName, string strUnitNum, string strRoadNum, string strRoadName, string strRoadType, string strSuburb, string strState, string strPostal, string strCountry, Boolean blHideRoadName, Boolean blHideRoadNum)
    {
        string address = "";

        if (!(blHideRoadName))
        {
            if (!String.IsNullOrEmpty(strRoadNum))
            {
                address = address + strRoadNum + " ";
            }
            if (!String.IsNullOrEmpty(strRoadName))
            {
                address = address + strRoadName + " ";
            }
            if (!String.IsNullOrEmpty(strRoadType))
            {
                address = address + strRoadType + " ";
            }

            if (!String.IsNullOrEmpty(strSuburb))
            {
                if (!String.IsNullOrEmpty(address))
                {
                    address = address + ", " + strSuburb;
                }
                else
                {
                    address = strSuburb;
                }
                if (!String.IsNullOrEmpty(strState))
                {
                    address = address + " " + strState.Replace("2", "");
                }
                if (!String.IsNullOrEmpty(strPostal))
                {
                    address = address + " " + strPostal;
                }

            }
            if (!String.IsNullOrEmpty(strCountry))
            {
                address = address + ", " + strCountry;
            }
            else
            {
                address = address + ", Australia";
            }
            if (!String.IsNullOrEmpty(strUnitNum))
            {
                address = "unit " + strUnitNum + "/" + address;
            }
        }
        else
        {
            if (!String.IsNullOrEmpty(strSuburb))
            {
                address = strSuburb;

                if (!String.IsNullOrEmpty(strState))
                {
                    address = address + " " + strState.Replace("2", "");
                }
                if (!String.IsNullOrEmpty(strPostal))
                {
                    address = address + " " + strPostal;
                }

            }

            if (!String.IsNullOrEmpty(strCountry))
            {
                address = address + ", " + strCountry;
            }
            else
            {
                address = address + ", Australia";
            }
        }
        return address;
    }
    public string gettimeDistance(string source, string dest, string strTitle, string strTitleBycay)
    {


        string ValueFormFile = "";
        string strReturn = "";
        string strTimeDistance = "";
        string imgsrc = "";
        string imgsrcCar = "";
        string url = "http://maps.google.com/?";
        url += "saddr=" + source;
        url += "&daddr=" + dest;
        url += "&output=kml";

        XmlTextReader reader = new XmlTextReader(url);

        try
        {
            while (reader.Read())
            {
                if (reader.Name.ToLower() == "description")
                {
                    if (!reader.IsEmptyElement)
                    {
                        ValueFormFile = reader.ReadString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            reader.Close();
            return "";
        }

        //Distance: 855&#160;mi (about 13 hours 22 mins)<br/>Map data &#169;2009 Tele Atlas
        //Distance: 14.8&#160;km (about 20 mins)<br/>Map da
        

        string strDistanceMeasure = ValueFormFile;
        if (strDistanceMeasure.Contains("Distance"))
        {
            string[] strKm = strDistanceMeasure.Split('(');

            if (strKm[0].ToLower().Contains(";mi ") || strKm[0].ToLower().Contains(";m "))
                strDistanceMeasure = "meters";
            else
                strDistanceMeasure = "kms";
        }


        string strDistance = ValueFormFile;
        if (strDistance.Contains("Distance"))
        {
            string[] strKm = strDistance.Split('#');
            strDistance = strTitle + strKm[0].Replace("&", " " + strDistanceMeasure);
            strDistance = strDistance.Replace("Distance:", "");
        }


        if (ValueFormFile.Contains("(") && ValueFormFile.Contains(")"))
        {
            string[] str = ValueFormFile.Split('(');
            str = str[1].Split(')');
            ValueFormFile = str[0];
            if (ValueFormFile.Contains("about"))
            {
                str = ValueFormFile.Split(' ');

                string days = "0";
                string hour = "0";
                string min = "0";
                if ((ValueFormFile.Contains("days") || ValueFormFile.Contains("day")))
                {
                    //flagForInvalidassredd = 1;
                    //return "0";
                    if (str[1] == "1")
                    {
                        hour = str[1] + " day ";
                    }
                    else
                    {
                        hour = str[1] + " days ";
                    }

                    if (str[3] == "1")
                    {
                        min = str[3] + " hour ";
                    }
                    else
                    {
                        min = str[3] + " hours ";
                    }


                }
                else if ((ValueFormFile.Contains("days") || ValueFormFile.Contains("day")) && (ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")) && (ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                {
                    hour = str[1] + " hrs ";
                    min = str[3] + " minutes ";
                }
                else if ((ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")) && (ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                {
                    hour = str[1] + " hrs ";
                    min = str[3] + " mins ";
                }
                else if ((ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")))
                {
                    hour = str[1] + " hrs ";
                }
                else if ((ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                {
                    min = str[1] + " mins ";
                }

                if (hour != "" && hour != "0")
                {
                    strReturn = strReturn.Trim() + " " + hour;
                }
                if (min != "" && min != "0")
                {
                    strReturn = strReturn.Trim() + " " + min;
                }
                else if (min == "0")
                {
                    strReturn = strReturn.Trim() + " 0 min ";
                }

                //if (strTitle.Trim() == "Dist. to airport:")
                //{
                //    imgsrc = "/images/ahc/web/i_airport.jpg";
                //}
                //else if (strTitle.Trim() == "Dist. to city:")
                //{
                //    imgsrc = "/images/ahc/web/i_city.jpg";
                //}
                //else
                //{
                //    imgsrc = "/images/point.jpg";
                //}


                //if (strTitleBycay.Trim() == "Car time to airport:")
                //{
                //    imgsrcCar = "/images/ahc/web/i_airport_car.jpg";
                //}
                //else if (strTitleBycay.Trim() == "Car time to city:")
                //{
                //    imgsrcCar = "/images/ahc/web/i_city_car.jpg";
                //}
                //else
                //{
                //    imgsrcCar = "/images/point.jpg";
                //}
                //strTimeDistance = strTimeDistance + "<table cellpadding=0 cellspacing=0>";
                //strTimeDistance = strTimeDistance + "<tr><td valign='top' style='font-size:11px'><img src='" + imgsrc + "' align='absmiddle' /></td><td valign='top' style='font-size:11px'>" + strDistance + "</td></tr>";
                //strTimeDistance = strTimeDistance + "<tr><td valign='top' style='font-size:11px'><img src='" + imgsrcCar + "' align='absmiddle' /></td><td valign='top' style='font-size:11px'>" + strTitleBycay + strReturn.Trim() + "</td></tr>";
                //strTimeDistance = strTimeDistance + "</table>";

                strTimeDistance = strTimeDistance + "<table cellpadding=0 cellspacing=0>";
                strTimeDistance = strTimeDistance + "<tr><td valign='top' style='font-size:11px'></td><td valign='top' style='font-size:11px'>" + strDistance + "</td></tr>";
                strTimeDistance = strTimeDistance + "<tr><td valign='top' style='font-size:11px'></td><td valign='top' style='font-size:11px'>" + strTitleBycay + strReturn.Trim() + "</td></tr>";
                strTimeDistance = strTimeDistance + "</table>";
            }
        }

        return strTimeDistance;
    }








    public int flagForInvalidassredd = 0;
    public string gettime(string source, string dest, DataTable dt, string HomeAddress, DataTable dtMain, DataTable dtAll)
    {

        flagForInvalidassredd = 0;
        string saddr = "";
        string daddr = "";

        if (source == "home")
        {
            saddr = HomeAddress;
        }
        else
        {
            saddr = (dt.Select("pid='" + source + "'"))[0]["address"].ToString();
        }

        daddr = (dt.Select("pid='" + dest + "'"))[0]["address"].ToString();
        daddr = daddr.Replace("<br>", " ");
        daddr = daddr.Replace("<Br>", " ");
        daddr = daddr.Replace("<BR>", " ");



        DataRow[] drExist = dtMain.Select("(s='" + source + "' and d='" + dest + "')");

        if (drExist.Length == 0)
        {
            if (dtAll != null)
            {
                if (dtAll.Columns.Count > 0)
                {
                    drExist = dtAll.Select("(s='" + source + "' and d='" + dest + "')");
                }
            }
        }


        if (drExist.Length == 0)
        {
            string ValueFormFile = "";
            string url = "http://maps.google.com/?";
            url += "saddr=" + saddr;
            url += "&daddr=" + daddr;
            url += "&output=kml";

            XmlTextReader reader = new XmlTextReader(url);

            try
            {
                while (reader.Read())
                {
                    if (reader.Name.ToLower() == "description")
                    {
                        if (!reader.IsEmptyElement)
                        {
                            ValueFormFile = reader.ReadString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                reader.Close();
                flagForInvalidassredd = 1;
                return "0";
            }            

            //Distance: 855&#160;mi (about 13 hours 22 mins)<br/>Map data &#169;2009 Tele Atlas 

            if (ValueFormFile.Contains("(") && ValueFormFile.Contains(")"))
            {
                string[] str = ValueFormFile.Split('(');
                str = str[1].Split(')');
                ValueFormFile = str[0];
                if (ValueFormFile.Contains("about"))
                {
                    str = ValueFormFile.Split(' ');

                    string days = "0";
                    string hour = "0";
                    string min = "0";
                    if ((ValueFormFile.Contains("days") || ValueFormFile.Contains("day")))
                    {
                        flagForInvalidassredd = 1;
                        return "0";
                    }
                    else if ((ValueFormFile.Contains("days") || ValueFormFile.Contains("day")) && (ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")) && (ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                    {
                        hour = str[1];
                        min = str[3];
                    }
                    else if ((ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")) && (ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                    {
                        hour = str[1];
                        min = str[3];
                    }
                    else if ((ValueFormFile.Contains("hours") || ValueFormFile.Contains("hour")))
                    {
                        hour = str[1];
                    }
                    else if ((ValueFormFile.Contains("mins") || ValueFormFile.Contains("min")))
                    {
                        min = str[1];
                    }

                    if (hour != "" && min != "")
                    {
                        if (Convert.ToInt32(hour) > 15)
                        {
                            flagForInvalidassredd = 1;
                            return "0";
                        }
                        else
                        {
                            return Convert.ToString(Convert.ToInt32(hour) * 60 + Convert.ToInt32(min));
                        }
                    }

                }
            }
        }
        else
        {
            return drExist[0]["time"].ToString();
        }

        return "0";
    }




    public DataTable getAllroute(int noofprop, string pids)
    {
        DataTable dt = new DataTable();
        SqlCommand command = new SqlCommand("spgetRoots", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@noofprop", noofprop));
        command.Parameters.Add(new SqlParameter("@pids", pids));
        SqlDataAdapter objAdapter = new SqlDataAdapter();
        objAdapter.SelectCommand = command;
        objAdapter.Fill(dt);
        return dt;
    }



    public DataTable getProeprtyinfoFilter(string[] strpid, string date)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("pid");
        dt.Columns.Add("address");
        dt.Columns.Add("Homeopen1From");
        dt.Columns.Add("Homeopen1To");
        dt.Columns.Add("Homeopen2From");
        dt.Columns.Add("Homeopen2To");

        for (int i = 0; i < strpid.Length; i++)
        {
            getProperty(strpid[i]);
            DataRow dr = dt.NewRow();
            dr["pid"] = strpid[i];
            dr["address"] = address;

            if (strHomeopen1From.Day == Convert.ToDateTime(date).Day)
            {
                dr["Homeopen1From"] = strHomeopen1From;
                dr["Homeopen1To"] = strHomeopen1To;
            }
            else
            {
                dr["Homeopen1From"] = strHomeopen2From;
                dr["Homeopen1To"] = strHomeopen2To;
            }

            dr["Homeopen2From"] = DBNull.Value;
            dr["Homeopen2To"] = DBNull.Value;

            dt.Rows.Add(dr);
        }

        return dt;

    }
    //New code
    public int ChekNoOfEntery(DataTable dtTable, DateTime dtTime, string strColumName)
    {
        int flag = 0;
        for (int i = 0; i < dtTable.Rows.Count; i++)
        {
            if (String.Format("{0:dd-MM-yyyy}", Convert.ToDateTime(dtTable.Rows[i][strColumName])) == String.Format("{0:dd-MM-yyyy}", dtTime))
            {
                flag++;
            }
        }
        return flag;
    }
}
