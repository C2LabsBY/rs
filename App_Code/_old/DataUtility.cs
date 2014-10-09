//**************************************************************************************
// Name             :   Shrwan Kumar
// Date             :   1/November/2007
// Purpose          :   All database activities are actual done here

// 1/November/2007   SK     C# version of component
//

//'**************************************************************************************
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A Data Tier Utility, Interacts with the Database.
/// Created By Mr. Shrwan Kumar
/// </summary>


public class DataUtility
{
    private SqlConnection mCon;
    private SqlCommand mDataCom;
    private SqlDataAdapter mDa;
    private string mConnectionString;

    private const string CRYPTO_KEY = "REIQ";
    private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 60 };

    /// <summary>
    /// Property for ConnectionString
    /// </summary>

    public string ConnectionString
    {
        set { mConnectionString = value; }
        get { return mConnectionString; }
    }



    public DataUtility()
    {
        mConnectionString = null;

    }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="ConnectionString"> string</param>
    public DataUtility(string connectionString)
    {
        mConnectionString = connectionString;
    }


    /// <summary>
    /// Opens the connection
    /// </summary>
    private void OpenConnection()
    {

        mCon = new SqlConnection(mConnectionString);

        mDataCom = new SqlCommand();

        if (mCon.State == ConnectionState.Closed)
        {
            mCon.Open();
            mDataCom.Connection = mCon;

        }


    }

    /// <summary>
    /// Closes the connection
    /// </summary>
    public void CloseConnection()
    {

        if (mCon.State == ConnectionState.Open)
        {
            mCon.Close();
        }
    }

    /// <summary>
    /// Tests whether a record exists or not
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public bool IsExists(string strSql)
    {

        int count = (int)GetScalarValue(strSql);
        if (count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Executes a query
    /// </summary>
    /// <param name="strSql">sql statement as string</param>
    /// <returns>DataReader</returns>

    public SqlDataReader GetDataReader(string procName)
    {
        OpenConnection();
        
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        SqlDataReader dr = mDataCom.ExecuteReader();
        
        return dr;
      
    }
    /// <summary>
    /// Executes a query
    /// </summary>
    /// <param name="strSql">sql statement as StoreProcedure</param>
    /// <returns>DataReader</returns>

    public SqlDataReader GetDataReader(string procName, SqlParameter[] parameterValues)
    {
        OpenConnection();
         mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        foreach (SqlParameter sp in parameterValues)
        {
            mDataCom.Parameters.Add(sp);
        }
        SqlDataReader dr = mDataCom.ExecuteReader();
        return dr;

    }
    /// <summary>
    /// Executes a query.
    /// </summary>
    /// <param name="strSql">sql statement as string</param>
    /// <returns>DataTable</returns>

    public DataTable GetDataTable(string procName)
    {
        OpenConnection();
        DataTable dt = new DataTable();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        mDa = new SqlDataAdapter();
        mDa.SelectCommand = mDataCom;
        mDa.Fill(dt);
        CloseConnection();
        return dt;
    }
    /// <summary>
    /// Executes a query.
    /// </summary>
    /// <param name="strSql">sql statement as StoreProcedure</param>
    /// <returns>DataTable</returns>

    public DataTable GetDataTable(string procName, SqlParameter[] parameterValues)
    {
        OpenConnection();
        DataTable dt = new DataTable();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        foreach (SqlParameter sp in parameterValues)
        {
            mDataCom.Parameters.Add(sp);
        }
        mDa = new SqlDataAdapter();
        mDa.SelectCommand = mDataCom;
        mDa.Fill(dt);
        CloseConnection();
        return dt;
    }
 
 

    /// <summary>
    /// Returns a scalar value
    /// </summary>
    /// <param name="strSql"> Sql Statement as string</param>
    /// <returns> Double </returns>

    public int GetScalarValue(string strSpSql)
    {
        OpenConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSpSql;
        int result = (int)mDataCom.ExecuteScalar();
        CloseConnection();
        if (result > 0)
            return result;
        else
            return 0;

    }
    /// <summary>
    /// Returns a scalar value
    /// </summary>
    /// <param name="strSql"> Sql Statement as StoreProcedure</param>
    /// <returns> Double </returns>

    public int GetScalarValue(string procName, SqlParameter[] parameterValues)
    {
        OpenConnection();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        foreach (SqlParameter sp in parameterValues)
        {
            mDataCom.Parameters.Add(sp);
        }
        int result = (int)mDataCom.ExecuteScalar();
        CloseConnection();
        if (result > 0)
            return result;
        else
            return 0;

    }

    /// <summary>
    /// Executes DML Statements
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>
    public int ExecuteDML(string strSpSql)
    {
        OpenConnection();
        mDataCom.CommandType = CommandType.Text;
        mDataCom.CommandText = strSpSql;
        int result = (int)mDataCom.ExecuteNonQuery();
        CloseConnection();
        return result;
    }
    /// <summary>
    /// Executes DML Statements as strore procedure
    /// </summary>
    /// <param name="strSql"></param>
    /// <returns></returns>

    public int ExecuteDML(string procName, SqlParameter[] parameterValues)
    {
        OpenConnection();
        mDataCom.CommandType = CommandType.StoredProcedure;
        mDataCom.CommandText = procName;
        foreach (SqlParameter sp in parameterValues)
        {
            mDataCom.Parameters.Add(sp);
        }
        int result = mDataCom.ExecuteNonQuery();
        CloseConnection();
        return result;
       
    }

    public static string Decrypt(string strSource)
    {
        // Declrate return variable
        string strTarget = string.Empty;

        strSource = strSource.Replace(" ", "+");
        // Decrypt the string using TripleDESCryptoServiceProvider
        byte[] buffer = Convert.FromBase64String(strSource);
        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(CRYPTO_KEY));
        des.IV = IV;

        strTarget = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));

        return strTarget;
    }
    public static string Encrypt(string strSource)
    {
        // Declrate return variable
        string strTarget = string.Empty;


        // Encrypt the string using TripleDESCryptoServiceProvider
        byte[] buffer = Encoding.ASCII.GetBytes(strSource);

        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

        des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(CRYPTO_KEY));
        des.IV = IV;

        strTarget = Convert.ToBase64String(
            des.CreateEncryptor().TransformFinalBlock(
            buffer,
            0,
            buffer.Length
            )
            );


        return strTarget;
    }

}
