using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI.HtmlControls;

using System.Collections;

[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]


public class AutoComplete : WebService
{
    //connection strings
    public SqlConnection connection;
    public string connectionString;

    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        connectionString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
        connection = new SqlConnection(connectionString);

        connection.Open();
        SqlCommand command = new SqlCommand("spGetSuburb_Top10", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@top", count));
        command.Parameters.Add(new SqlParameter("@country", "AU"));
        command.Parameters.Add(new SqlParameter("@state", "QLD"));
        command.Parameters.Add(new SqlParameter("@name", prefixText + "%"));
        SqlDataReader reader = command.ExecuteReader();

        DataSet Items = new DataSet();
        Items = convertDataReaderToDataSet(reader);
        int NoOfProp = Items.Tables[0].Rows.Count;

        string[] suburbname = new string[NoOfProp];
        for (int i = 0; i < NoOfProp; i++)
        {
            string str = "";
            str = Items.Tables[0].Rows[i]["name"].ToString();
            if (Items.Tables[0].Rows[i]["postcode"].ToString() != "")
            {
                str += ", " + Items.Tables[0].Rows[i]["postcode"].ToString();
            }

            suburbname.SetValue(str, i);
        }
        return suburbname;
    }
    [WebMethod]
    public string[] getAutocomplete(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        showproperty prop = new showproperty();

        prefixText = prefixText.Replace("'", "`"); // all suburbs in the database have back-ticks instead of apostrophes

        ds = prop.getAutocomplete(contextKey, "Any", prefixText);

        int ct1 = ds.Tables[0].Rows.Count;                                          // these are suburbs
        int ct2 = ds.Tables[1].Rows.Count > 5 ? 5 : ds.Tables[1].Rows.Count;        // these are regions
        int ct3 = ds.Tables[2].Rows.Count > 5 ? 5 : ds.Tables[2].Rows.Count;        // these are properties
        //int ct4 = ds.Tables[3].Rows.Count > 5 ? 5 : ds.Tables[3].Rows.Count;      // these are also properties....

        ArrayList arr = new ArrayList();

        if (ct1 > 0)
            arr.Add("Select Suburb" + "##suburb");
        for (int i = 0; i < ct1; i++)
        {
            arr.Add(ds.Tables[0].Rows[i]["nameandpostcode"].ToString().Replace(";", "-") + "##suburb");
        }

        if (ct2 > 0)
            arr.Add("Select Region" + "##region");
        for (int i = 0; i < ct2; i++)
        {
            arr.Add(ds.Tables[1].Rows[i]["region"].ToString().Replace(";", "-") + "##region");
        }

        if (ct3 > 0)
            arr.Add("Select ID" + "##pid");
        for (int i = 0; i < ct3; i++)
        {
            arr.Add(ds.Tables[2].Rows[i]["pid"].ToString().Replace(";", "-") + "##pid");
        }

        //if (ct4 > 0)
        //    arr.Add("Select Address" + "##address");
        //for (int i = 0; i < ct4; i++)
        //{
        //    arr.Add(ds.Tables[3].Rows[i]["address"].ToString().Replace(";", "-") + "##address");
        //}

        string[] suburb = new string[arr.Count];

        for (int i = 0; i < arr.Count; i++)
        {
            suburb[i] = arr[i].ToString();
        }

        return suburb;

    }

    [WebMethod]
    public string getAutocompletejson(string prefixText, int count, string contextKey)
    {
        DataSet ds = new DataSet();
        showproperty prop = new showproperty();

        ds = prop.getAutocomplete(contextKey, "Any", prefixText);

        int ct1 = ds.Tables[0].Rows.Count > 5 ? 5 : ds.Tables[0].Rows.Count;
        int ct2 = ds.Tables[1].Rows.Count > 5 ? 5 : ds.Tables[1].Rows.Count;
        int ct3 = ds.Tables[2].Rows.Count > 5 ? 5 : ds.Tables[2].Rows.Count;
        int ct4 = ds.Tables[3].Rows.Count > 5 ? 5 : ds.Tables[3].Rows.Count;

        ArrayList arr = new ArrayList();

        if (ct1 > 0)
            arr.Add("Select Suburb");
        for (int i = 0; i < ct1; i++)
        {
            arr.Add(ds.Tables[0].Rows[i]["nameandpostcode"].ToString().Replace(", ", " - "));
        }

        if (ct2 > 0)
            arr.Add("Select Region");
        for (int i = 0; i < ct2; i++)
        {
            arr.Add(ds.Tables[1].Rows[i]["region"].ToString().Replace(", ", " - "));
        }

        if (ct3 > 0)
            arr.Add("Select ID");
        for (int i = 0; i < ct3; i++)
        {
            arr.Add(ds.Tables[2].Rows[i]["pid"].ToString().Replace(", ", " - "));
        }

        if (ct4 > 0)
            arr.Add("Select Address");
        for (int i = 0; i < ct4; i++)
        {
            arr.Add(ds.Tables[3].Rows[i]["address"].ToString().Replace(", ", " - "));
        }

        string strresult = "{\"data\": [";

        for (int i = 0; i < arr.Count; i++)
        {
            strresult += "{ \"suburb\":\"" + arr[i].ToString() + "\"}";
            if (i < arr.Count - 1)
                strresult += ", ";
        }
        strresult += "]}";

        return strresult;

    }

    [WebMethod]
    public string[] getsuburbsearch(string prefixText, int count, string contextKey)
    {
        DataTable dtsuburb = new DataTable();
        showproperty prop = new showproperty();

        string[] filter = contextKey.Split('@');

        string tempstatus = filter[0];
        string re = filter[1];
        string map = filter[2];



        if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["re"]))
        {
            dtsuburb = prop.GetSuburbsByStatusAndregion(tempstatus, "Any", "qld", prop.convertListToSQL(re), prefixText);
        }
        else if (HttpContext.Current.Request.QueryString["map"] != null)
        {
            dtsuburb = prop.GetSuburbsByStatusAndMaparea(tempstatus, "Any", "qld", prop.convertListToSQL(map), prefixText);
        }
        else
        {
            dtsuburb = prop.GetSuburbsByStatusAndMaparea(tempstatus, "Any", "qld", "Any", prefixText);
        }

        int count1 = dtsuburb.Rows.Count;
        if (count1 > 5)
            count1 = 5;


        string[] suburb = new string[count1];

        for (int i = 0; i < count1; i++)
        {
            suburb[i] = dtsuburb.Rows[i]["nameandpostcode"].ToString().Replace(", ", " - ");
        }

        return suburb;

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
}

