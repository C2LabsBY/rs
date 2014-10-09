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

/// <summary>
/// This class will have all the database functions for the REIQ website
/// </summary>

namespace old
{
    public class REIQ
    {
        /// <summary>
        /// Connetion vars will be defined in the construtor
        /// </summary>
        public SqlConnection connection;
        public string connectionString;
        public int subID;
        public string strACID;
        public string strFirstName;
        public string strSurname;
        public string strname;
        public string strEmail;
        public string strState;
        public string strStatus;
        public string strType;
        public string strRegion;
        public string strSuburbs;
        public string strNumBedLow;
        public string strNumBedHigh;
        public string strNumBathLow;
        public string strNumBathHigh;
        public string strPriceLow;
        public string strPriceHigh;
        public string strNumGarage;
        public DateTime strStartDate;
        public string strSubscriptionPeriod;
        public string featurepid1;
        public string featurepid2;
        public string featurepid3;


        public REIQ()
        {
            connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// This funtion is used to get the current feature properties from the database 
        /// </summary>
        /// <returns>
        /// A max of 3 properties from the database selected from the admin zone
        /// </returns>
        /// 
        public SqlDataReader getCMSItemsNormal(string acID, string pagename, string webdisplay)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetCMNews", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@acID", acID));
            command.Parameters.Add(new SqlParameter("@pageURL", pagename));
            command.Parameters.Add(new SqlParameter("@isWebDisplay", webdisplay));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader getCMSItems(string acID, string pagename, string webdisplay)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetCMNews_orderbyheading", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@acID", acID));
            command.Parameters.Add(new SqlParameter("@pageURL", pagename));
            command.Parameters.Add(new SqlParameter("@isWebDisplay", webdisplay));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader getCMSItemsByID(string acID, string webdisplay, string ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetCMNews_orderbyheading", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ID", ID));
            command.Parameters.Add(new SqlParameter("@acID", acID));
            command.Parameters.Add(new SqlParameter("@isWebDisplay", webdisplay));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        public DataTable getFeatureProperties()
        {
            SqlCommand command = new SqlCommand("FeaturePropertyAHC", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter objAdapter = new SqlDataAdapter();
            objAdapter.SelectCommand = command;
            DataSet objDS = new DataSet();
            DataTable objDT = new DataTable();
            objAdapter.Fill(objDS, "Searchsave");
            objDT = objDS.Tables["Searchsave"];
            return objDT;
        }
        /// <summary>
        /// This funtion will return the suburb used in the search
        /// </summary>
        /// <param name="region">to get the region specfic suburbs</param>
        /// <param name="state">to get state specfic suburbs</param>
        /// <param name="country">to get country specfic suburbs</param>
        /// <returns>a recodset of all suburbs matching the search certia</returns>
        public SqlDataReader getSuburbs(string region, string state, string country)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetConstSuburb", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@region", region));
            command.Parameters.Add(new SqlParameter("@state", state));
            command.Parameters.Add(new SqlParameter("@country", country));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// <summary>
        /// This will return the property types
        /// </summary>
        /// <returns></returns>
        public SqlDataReader getPropertyTypes()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetConstPropertyTypeNew", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// melbourne random properties
        /// 

        public string convertListToSQL(string listtocon)
        {
            if (!String.IsNullOrEmpty(listtocon))
            {
                listtocon = listtocon.Replace("'", "''");
                if (!listtocon.Equals("Any"))
                {
                    listtocon = listtocon.Replace(",", "','");
                    listtocon = listtocon + "')";
                    listtocon = "('" + listtocon;
                }
            }
            else
            {
                listtocon = "Any";
            }
            return listtocon;
        }

        /// This will return the lifestyles
        public SqlDataReader getLifestyles()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetConstLifestyle", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
        /// This will return agencies per state
        public SqlDataReader getAgenciesPerState(string state)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetAgencies", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@state", state));
            //command.Parameters.Add(new SqlParameter("@country", "AU"));
            command.Parameters.Add(new SqlParameter("@isWebDisplay", "1"));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader getAgencyList(string name, string suburb, string postcode, string state, string orderby)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetAgencyList", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@name", name));
            command.Parameters.Add(new SqlParameter("@suburb", suburb));
            command.Parameters.Add(new SqlParameter("@postcode", postcode));
            command.Parameters.Add(new SqlParameter("@orderBy", orderby));
            command.Parameters.Add(new SqlParameter("@state", state));
            command.Parameters.Add(new SqlParameter("@country", "AU"));
            command.Parameters.Add(new SqlParameter("@isWebDisplay", "1"));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        /// This will insert subscription
        public void insertSubscription(string strACID, string strFirstname, string strSurname, string strEmail, string strPhone, string strStatus, string strType, string strPriceLow, string strPriceHigh, string strNumBedLow, string strNumBedHigh, string strNumBathLow, string strNumBathHigh, string strNumGarage, string strSuburbs, string strRegion, string strState, string strNewsletter, string strSubscriptionPeriod, string strComments)
        {
            connection.Open();
            SqlParameter paramReturnValue = new SqlParameter();
            paramReturnValue.ParameterName = "@subID";
            paramReturnValue.SqlDbType = SqlDbType.Int;
            paramReturnValue.Direction = ParameterDirection.Output;

            using (SqlCommand command = new SqlCommand("spInsertSubscription", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@acID", strACID));
                command.Parameters.Add(new SqlParameter("@firstname", strFirstname));
                command.Parameters.Add(new SqlParameter("@surname", strSurname));
                command.Parameters.Add(new SqlParameter("@email", strEmail));
                command.Parameters.Add(new SqlParameter("@phone", strPhone));
                command.Parameters.Add(new SqlParameter("@status", strStatus));
                command.Parameters.Add(new SqlParameter("@type", strType));
                command.Parameters.Add(new SqlParameter("@priceLow", strPriceLow));
                command.Parameters.Add(new SqlParameter("@priceHigh", strPriceHigh));
                command.Parameters.Add(new SqlParameter("@numBedLow", strNumBedLow));
                command.Parameters.Add(new SqlParameter("@numBedHigh", strNumBedHigh));
                command.Parameters.Add(new SqlParameter("@numBathLow", strNumBathLow));
                command.Parameters.Add(new SqlParameter("@numBathHigh", strNumBathHigh));
                command.Parameters.Add(new SqlParameter("@numGarage", strNumGarage));
                if (strSuburbs.Equals("Any"))
                {
                    command.Parameters.Add(new SqlParameter("@suburbs", DBNull.Value));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@suburbs", convertListToSQL(strSuburbs)));
                }

                command.Parameters.Add(new SqlParameter("@region", strRegion));
                command.Parameters.Add(new SqlParameter("@state", strState));
                command.Parameters.Add(new SqlParameter("@newsletter", strNewsletter));
                command.Parameters.Add(new SqlParameter("@subscriptionPeriod", strSubscriptionPeriod));
                command.Parameters.Add(new SqlParameter("@comments", strComments));
                command.Parameters.Add(paramReturnValue);
                command.ExecuteNonQuery();
                subID = (int)command.Parameters["@subID"].Value;
            }

            connection.Close();

        }
        /// This will update subscription
        public void updateSubscription(string subID, string strACID, string strStatus, string strType, string strPriceLow, string strPriceHigh, string strNumBedLow, string strNumBedHigh, string strNumBathLow, string strNumBathHigh, string strNumGarage, string strSuburbs, string strRegion, string strState, string strNewsletter, string strSubscriptionPeriod, string strComments)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("spUpdateSubscription", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@subID", subID));
                command.Parameters.Add(new SqlParameter("@acid", strACID));
                command.Parameters.Add(new SqlParameter("@status", strStatus));
                command.Parameters.Add(new SqlParameter("@type", strType));
                command.Parameters.Add(new SqlParameter("@priceLow", strPriceLow));
                command.Parameters.Add(new SqlParameter("@priceHigh", strPriceHigh));
                command.Parameters.Add(new SqlParameter("@numBedLow", strNumBedLow));
                command.Parameters.Add(new SqlParameter("@numBedHigh", strNumBedHigh));
                command.Parameters.Add(new SqlParameter("@numBathLow", strNumBathLow));
                command.Parameters.Add(new SqlParameter("@numBathHigh", strNumBathHigh));
                command.Parameters.Add(new SqlParameter("@numGarage", strNumGarage));
                command.Parameters.Add(new SqlParameter("@suburbs", strSuburbs));
                command.Parameters.Add(new SqlParameter("@region", strRegion));
                command.Parameters.Add(new SqlParameter("@state", strState));
                command.Parameters.Add(new SqlParameter("@newsletter", strNewsletter));
                command.Parameters.Add(new SqlParameter("@subscriptionPeriod", strSubscriptionPeriod));
                command.Parameters.Add(new SqlParameter("@comments", strComments));
                command.ExecuteNonQuery();
            }

            connection.Close();

        }
        /// This will update subscription with date
        public void updateSubscription(string subID, string strACID, string strStatus, string strType, string strPriceLow, string strPriceHigh, string strNumBedLow, string strNumBedHigh, string strNumBathLow, string strNumBathHigh, string strNumGarage, string strSuburbs, string strRegion, string strState, string strNewsletter, string strSubscriptionPeriod, string strSubscriptionDate, string strComments)
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("spUpdateSubscriptionDate", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@subID", subID));
                command.Parameters.Add(new SqlParameter("@acid", strACID));
                command.Parameters.Add(new SqlParameter("@status", strStatus));
                command.Parameters.Add(new SqlParameter("@type", strType));
                command.Parameters.Add(new SqlParameter("@priceLow", strPriceLow));
                command.Parameters.Add(new SqlParameter("@priceHigh", strPriceHigh));
                command.Parameters.Add(new SqlParameter("@numBedLow", strNumBedLow));
                command.Parameters.Add(new SqlParameter("@numBedHigh", strNumBedHigh));
                command.Parameters.Add(new SqlParameter("@numBathLow", strNumBathLow));
                command.Parameters.Add(new SqlParameter("@numBathHigh", strNumBathHigh));
                command.Parameters.Add(new SqlParameter("@numGarage", strNumGarage));

                if (strSuburbs.Equals("Any") || strSuburbs.Equals(""))
                    command.Parameters.Add(new SqlParameter("@suburbs", DBNull.Value));
                else
                    command.Parameters.Add(new SqlParameter("@suburbs", strSuburbs));

                command.Parameters.Add(new SqlParameter("@region", strRegion));
                command.Parameters.Add(new SqlParameter("@state", strState));
                command.Parameters.Add(new SqlParameter("@newsletter", strNewsletter));
                command.Parameters.Add(new SqlParameter("@subscriptionPeriod", strSubscriptionPeriod));
                command.Parameters.Add(new SqlParameter("@subscriptionDate", strSubscriptionDate));
                command.Parameters.Add(new SqlParameter("@comments", strComments));
                command.ExecuteNonQuery();
            }

            connection.Close();

        }


        public void getSubscriptions(string subID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("spGetSubscriptions", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@subID", subID));
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                if (!reader.IsDBNull(reader.GetOrdinal("firstname")))
                {
                    strFirstName = reader.GetString(reader.GetOrdinal("firstname"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("surname")))
                {
                    strSurname = reader.GetString(reader.GetOrdinal("surname"));
                }
                strname = strFirstName + "  " + strSurname;

                if (!reader.IsDBNull(reader.GetOrdinal("acid")))
                {
                    strACID = reader.GetString(reader.GetOrdinal("acid"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("email")))
                {
                    strEmail = reader.GetString(reader.GetOrdinal("email"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("state")))
                {
                    strState = reader.GetString(reader.GetOrdinal("state"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("status")))
                {
                    strStatus = reader.GetString(reader.GetOrdinal("status"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("type")))
                {
                    strType = reader.GetString(reader.GetOrdinal("type"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("region")))
                {
                    strRegion = reader.GetString(reader.GetOrdinal("region"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("suburbs")))
                {
                    strSuburbs = reader.GetString(reader.GetOrdinal("suburbs"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("numBedLow")))
                {
                    strNumBedLow = reader.GetString(reader.GetOrdinal("numBedLow"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("numBedHigh")))
                {
                    strNumBedHigh = reader.GetString(reader.GetOrdinal("numBedHigh"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("numBathLow")))
                {
                    strNumBathLow = reader.GetString(reader.GetOrdinal("numBathLow"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("numBathHigh")))
                {
                    strNumBathHigh = reader.GetString(reader.GetOrdinal("numBathHigh"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("priceLow")))
                {
                    strPriceLow = reader.GetString(reader.GetOrdinal("priceLow"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("priceHigh")))
                {
                    strPriceHigh = reader.GetString(reader.GetOrdinal("priceHigh"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("numGarage")))
                {
                    strNumGarage = reader.GetString(reader.GetOrdinal("numGarage"));
                }

                if (!reader.IsDBNull(reader.GetOrdinal("subscriptionDate")))
                {
                    strStartDate = reader.GetDateTime(reader.GetOrdinal("subscriptionDate"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("subscriptionPeriod")))
                {
                    byte Period = reader.GetByte(reader.GetOrdinal("subscriptionPeriod"));
                    strSubscriptionPeriod = Period.ToString();
                }

            }
        }

        public SqlDataReader getPropertiesHunt(string acID, string type, string suburb, string state, string status, string priceLow, string priceHigh, string bedLow, string bedHigh, string bathLow, string bathHigh, string garage, string days, string orderby)
        {
            connection.Close();
            connection.Open();
            SqlCommand command = new SqlCommand("spGetPropertiesHomeHunt", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@acID", acID));
            command.Parameters.Add(new SqlParameter("@type", type));
            command.Parameters.Add(new SqlParameter("@suburb", suburb));
            command.Parameters.Add(new SqlParameter("@state", state));
            command.Parameters.Add(new SqlParameter("@status", status));
            command.Parameters.Add(new SqlParameter("@priceLow", priceLow));
            command.Parameters.Add(new SqlParameter("@priceHigh", priceHigh));
            command.Parameters.Add(new SqlParameter("@numBedLow", bedLow));
            command.Parameters.Add(new SqlParameter("@numBedHigh", bedHigh));
            command.Parameters.Add(new SqlParameter("@numBathLow", bathLow));
            command.Parameters.Add(new SqlParameter("@numBathHigh", bathHigh));
            command.Parameters.Add(new SqlParameter("@numGarage", garage));
            command.Parameters.Add(new SqlParameter("@dateUpdated", days));
            command.Parameters.Add(new SqlParameter("@orderBy", orderby));
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static DataSet convertDataReaderToDataSet(SqlDataReader reader)
        {
            DataSet dataSet = new DataSet();
            do
            {
                // Create new data table

                DataTable schemaTable = reader.GetSchemaTable();
                DataTable dataTable = new DataTable();

                if (schemaTable != null)
                {
                    // A query returning records was executed

                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        DataRow dataRow = schemaTable.Rows[i];
                        // Create a column name that is unique in the data table
                        string columnName = (string)dataRow["ColumnName"]; //+ "<C" + i + "/>";
                        // Add the column definition to the data table
                        DataColumn column = new DataColumn(columnName, (Type)dataRow["DataType"]);
                        dataTable.Columns.Add(column);
                    }

                    dataSet.Tables.Add(dataTable);

                    // Fill the data table we just created

                    while (reader.Read())
                    {
                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                            dataRow[i] = reader.GetValue(i);

                        dataTable.Rows.Add(dataRow);
                    }
                }
                else
                {
                    // No records were returned

                    DataColumn column = new DataColumn("RowsAffected");
                    dataTable.Columns.Add(column);
                    dataSet.Tables.Add(dataTable);
                    DataRow dataRow = dataTable.NewRow();
                    dataRow[0] = reader.RecordsAffected;
                    dataTable.Rows.Add(dataRow);
                }
            }
            while (reader.NextResult());
            return dataSet;
        }
        public string getClientLink(string picture, string heading, string text)
        {

            string txtClientLink = "";
            text = text.Replace("<p>", "");
            text = text.Replace("</p>", "");
            txtClientLink = "<a href='http://" + text + "' target='_blank' class='thumbnail'><img src='" + picture + "' width='60' hspace='2' ><span><img src='" + picture + "' /><br />" + heading + "<br/>" + text + "</span></a>";
            return txtClientLink;
        }
        public DataTable GetRegions(string state)
        {
            SqlCommand command = new SqlCommand("spGetRegions", connection);
            command.Parameters.Add(new SqlParameter("@state", state));
            command.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter objAdapter = new SqlDataAdapter();
            objAdapter.SelectCommand = command;
            DataSet objDS = new DataSet();
            DataTable objDT = new DataTable();
            objAdapter.Fill(objDS, "Items");
            objDT = objDS.Tables["Items"];

            connection.Close();
            objAdapter.Dispose();
            return objDT;
        }
    }
}