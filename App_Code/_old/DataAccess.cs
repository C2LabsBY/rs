using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dapper;

/// <summary>
/// Simple data access library using Dapper to get anything from the database.
/// </summary>
public class DataAccess
{
    private static string connString = ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;

    public static IEnumerable<T> DoQuery<T>(string qry, object paramaters)
    {
        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString))
        {
            try
            {
                conn.Open();
                return conn.Query<T>(qry, paramaters);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

        }
    }

    public static int DoExecute(string qry, object paramaters)
    {
        using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString))
        {
            try
            {
                conn.Open();
                return conn.Execute(qry, paramaters);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}