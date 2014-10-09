using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Sql;
/// <summary>
/// Summary description for WebUser
/// </summary>
public class WebUser
{
    public SqlConnection connection;
    public string connectionString;
    public string firstname;
    public string lastname;
    public string password;
    public string email;
    public string screenname;
    public string phone;
    //my favourites
    public string comments;
    public string fname;
    public string favPID;

    //REIQhunt
    public string huntname;
    public string status;
    public string type;
    public string bedLow;
    public string bedHigh;
    public string bathLow;
    public string bathHigh;
    public string cars;
    public string pricelow;
    public string pricehigh;
    public string region;
    public string suburbs;
    public DateTime SubscriptionDate;
    public string SubscriptionPeriod;
    public string firstName;
    public string lastName;
    public string subscriberEmail;
    public string subscriberPhone;
	 public string commpid="";
    public Boolean blnewsletter;

    public Int32 userID;
	public WebUser()
	{
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);
	}
    public void getUser(int userID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserGet", connection);
        command.Parameters.Add(new SqlParameter("@userID", userID));
        command.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
            {
                firstname = reader.GetString(reader.GetOrdinal("firstname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("lastname")))
            {
                lastname = reader.GetString(reader.GetOrdinal("lastname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                email = reader.GetString(reader.GetOrdinal("email"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                phone = reader.GetString(reader.GetOrdinal("phone"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("screenname")))
            {
                screenname = reader.GetString(reader.GetOrdinal("screenname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("password")))
            {
                password = reader.GetString(reader.GetOrdinal("password"));
            }
			if (!reader.IsDBNull(reader.GetOrdinal("pid")))
            {
                commpid = reader.GetValue(reader.GetOrdinal("pid")).ToString();
            }
			
			 if (!reader.IsDBNull(reader.GetOrdinal("newletter")))
            {
                blnewsletter = reader.GetBoolean(reader.GetOrdinal("newletter"));
            }
        }
        connection.Close();
    }

    
    public void addwebuser(string email, string phone, string firstname, string lastname, string password, string screenname,string pid,bool newsletter)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserInsert", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@email", email));
        command.Parameters.Add(new SqlParameter("@phone", phone));
        command.Parameters.Add(new SqlParameter("@firstname", firstname));
        command.Parameters.Add(new SqlParameter("@lastname", lastname));
        command.Parameters.Add(new SqlParameter("@password", password));
        command.Parameters.Add(new SqlParameter("@screenname", screenname));
		command.Parameters.Add(new SqlParameter("@newsletter", newsletter));
		if(!string.IsNullOrEmpty(pid))
			command.Parameters.Add(new SqlParameter("@pid", pid));
			else
			command.Parameters.Add(new SqlParameter("@pid", DBNull.Value));
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void updatewebuser(int userid,string email, string phone, string firstname, string lastname, string password, string screenname,string pid,bool newsletter)
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand("spWebUserUpdate", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userid", userid));
            command.Parameters.Add(new SqlParameter("@email", email));
            command.Parameters.Add(new SqlParameter("@phone", phone));
            command.Parameters.Add(new SqlParameter("@firstname", firstname));
            command.Parameters.Add(new SqlParameter("@lastname", lastname));
            command.Parameters.Add(new SqlParameter("@password", password));
			command.Parameters.Add(new SqlParameter("@newsletter", newsletter));
            command.Parameters.Add(new SqlParameter("@screenname", screenname));
			if(!string.IsNullOrEmpty(pid))
			command.Parameters.Add(new SqlParameter("@pid", pid));
			else
			command.Parameters.Add(new SqlParameter("@pid", DBNull.Value));
			
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
    public Boolean checklogin(string email, string password)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserCheck", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@email", email));
        command.Parameters.Add(new SqlParameter("@password", password));
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("userID")))
            {
                userID = reader.GetInt32(reader.GetOrdinal("userID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("screenname")))
            {
                screenname = reader.GetString(reader.GetOrdinal("screenname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                email = reader.GetString(reader.GetOrdinal("email"));
            }
            connection.Close();

            
            return true;
        }
        else
        {
            connection.Close();
            return false;
        }
        
    }
    public void getPswdByEmail(string email)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserGetByEmail", connection);
        command.Parameters.Add(new SqlParameter("@email", email));
        command.CommandType = CommandType.StoredProcedure;
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("userID")))
            {
                userID = reader.GetInt32(reader.GetOrdinal("userID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
            {
                firstname = reader.GetString(reader.GetOrdinal("firstname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("password")))
            {
                password = reader.GetString(reader.GetOrdinal("password"));
            }
        }
        connection.Close();
    }
    public Boolean checkemail(string email)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserGetByEmail", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@email", email));
        SqlDataReader reader = command.ExecuteReader();
        if (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("userID")))
            {
                userID = reader.GetInt32(reader.GetOrdinal("userID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("password")))
            {
                password = reader.GetString(reader.GetOrdinal("password"));
            }
            connection.Close();


            return true;
        }
        else
        {
            connection.Close();
            return false;
        }

    }
    public void updateWebUserHunt(int userid, int huntid, string huntname)
    {

        connection.Open();
        using (SqlCommand command = new SqlCommand("spWebUserHuntUpdate", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userid", userid));
            command.Parameters.Add(new SqlParameter("@huntid", huntid));
            command.Parameters.Add(new SqlParameter("@huntname", huntname));
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
    public void insertWebUserHunt(int userid, int huntid, string huntname)
    {

        connection.Open();
        using (SqlCommand command = new SqlCommand("spWebUserAddHunt", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@userid", userid));
            command.Parameters.Add(new SqlParameter("@huntid", huntid));
            command.Parameters.Add(new SqlParameter("@huntname", huntname));
            command.ExecuteNonQuery();
        }
        connection.Close();
    }

    
    
    public SqlDataReader getMyHunts(int userID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserHuntGet", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@userID", userID));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void getMyHuntsBySubID(int subID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserHuntGetBySubID", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@subID", subID));
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("huntname")))
            {
                huntname = reader.GetString(reader.GetOrdinal("huntname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("status")))
            {
                status = reader.GetString(reader.GetOrdinal("status"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("type")))
            {
                type = reader.GetString(reader.GetOrdinal("type"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBedLow")))
            {
                bedLow = reader.GetString(reader.GetOrdinal("numBedLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBedHigh")))
            {
                bedHigh = reader.GetString(reader.GetOrdinal("numBedHigh"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBathLow")))
            {
                bathLow = reader.GetString(reader.GetOrdinal("numBathLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numBathHigh")))
            {
                bathHigh = reader.GetString(reader.GetOrdinal("numBathHigh"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
            {
                cars = reader.GetString(reader.GetOrdinal("numGarage"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceLow")))
            {
                pricelow = reader.GetString(reader.GetOrdinal("priceLow"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("priceHigh")))
            {
                pricehigh = reader.GetString(reader.GetOrdinal("priceHigh"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("region")))
            {
                region = reader.GetString(reader.GetOrdinal("region"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("suburbs")))
            {
                suburbs = reader.GetString(reader.GetOrdinal("suburbs"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("subscriptionDate")))
            {
                SubscriptionDate = reader.GetDateTime(reader.GetOrdinal("subscriptionDate"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("subscriptionPeriod")))
            {
                byte Period = reader.GetByte(reader.GetOrdinal("subscriptionPeriod"));
               SubscriptionPeriod = Period.ToString();
            }
            if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
            {
                firstName = reader.GetString(reader.GetOrdinal("firstname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("surname")))
            {
                lastName = reader.GetString(reader.GetOrdinal("surname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("email")))
            {
                subscriberEmail = reader.GetString(reader.GetOrdinal("email"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("phone")))
            {
                subscriberPhone = reader.GetString(reader.GetOrdinal("phone"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("newsletter")))
            {
                blnewsletter = reader.GetBoolean(reader.GetOrdinal("newsletter"));
            }

        }

        connection.Close();
    }

    public void deleteWebUserHunt(int huntID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spWebUserHuntRemove", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@huntid", huntID));
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void deleteSubscriptionHunt(string subID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spSubscriptionHuntRemove", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@subID", subID));
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void deleteAllHunts(int userID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("[spWebUserHuntbyUserIDRemoveAll]", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@userID", userID));
        command.ExecuteNonQuery();
        connection.Close();
    }
    /**************************MY FAVOURITES************************************************/
    public void addFav(int userID, string pid, string comments, string fname)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spUserFavAdd", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@userID", userID));
        command.Parameters.Add(new SqlParameter("@pid", pid));
        command.Parameters.Add(new SqlParameter("@fname", fname));
        command.Parameters.Add(new SqlParameter("@comments", comments));
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void updateFav(int fpid, string pid, string comments,string fname)
    {

        connection.Open();
        using (SqlCommand command = new SqlCommand("spUserFavUpdate", connection))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@fpid", fpid));
            command.Parameters.Add(new SqlParameter("@pid", pid));
            command.Parameters.Add(new SqlParameter("@fname", fname));
            command.Parameters.Add(new SqlParameter("@comments", comments));
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
    public void deleteFavo(int fpid)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spUserFavRemove", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@fpid", fpid));
        command.ExecuteNonQuery();
        connection.Close();
    }
    public void deleteAllFavo(int userID)
    {
        connection.Open();
        SqlCommand command = new SqlCommand("spUserFavRemoveAll", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@userID", userID));
        command.ExecuteNonQuery();
        connection.Close();
    }

    public SqlDataReader getFavByUserID(int userID)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spUserFavGet", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@userID", userID));
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void getFavByFPID(int fpid)
    {

        connection.Open();
        SqlCommand command = new SqlCommand("spUserFavGetByFPID", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@fpid", fpid));
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            if (!reader.IsDBNull(reader.GetOrdinal("comments")))
            {
                comments = reader.GetString(reader.GetOrdinal("comments"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("fname")))
            {
                fname = reader.GetString(reader.GetOrdinal("fname"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("pid")))
            {
                favPID = reader.GetString(reader.GetOrdinal("pid"));
            }
        }
        connection.Close();
    }

    /**************************************************************************/
    
    public string getRegionOrSuburbs(string region, string suburb)
    {
        string strPrint = "";

        if (!String.IsNullOrEmpty(region))
        {
            switch (region)
            {
                case "cbd": strPrint = "Perth CBD";
                    break;
                case "coastal": strPrint = "Coastal Strip";
                    break;
                case "eastern": strPrint = "Eastern Suburb";
                    break;
                case "freo": strPrint = "Fremantle Area";
                    break;
                case "innerNorthern": strPrint = "Inner Northern Suburb";
                    break;
                case "innerSouthern": strPrint = "Inner Western Suburb";
                    break;
                case "innerWestern": strPrint = "Perth CBD";
                    break;
                case "northern": strPrint = "Northern Suburb";
                    break;
                case "outerWestern": strPrint = "Outer Western Suburb";
                    break;
                case "southern": strPrint = "Southern Suburb";
                    break;
                case "southPerth": strPrint = "South Perth Area";
                    break;
                case "esperance": strPrint = "Esperance Region";
                    break;
                case "goldfields": strPrint = "The Goldfields";
                    break;
                case "greatSouthern": strPrint = "Great Southern";
                    break;
                case "kimberley": strPrint = "Kimberley Region";
                    break;
                case "midWest": strPrint = "Mid West Region";
                    break;
                case "peel": strPrint = "The Peel";
                    break;
                case "southWest": strPrint = "South West Region";
                    break;

            }
        }
        if (!String.IsNullOrEmpty(suburb))
        {
            strPrint = suburb.Replace("'", "");
            strPrint = strPrint.Replace("(", "");
            strPrint = strPrint.Replace(")", "");
        }


        return strPrint;

    }


    public string getPeriod(string period)
    {
        string strPrint = "";

        if (!String.IsNullOrEmpty(period))
        {
            if (period == "0")
            {
                strPrint = "Indefinitely";
            }
            else
            {
                strPrint = period + " month(s)";
            }
        }


        return strPrint;

    }
}
