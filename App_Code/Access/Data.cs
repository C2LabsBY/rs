using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REIQ.Access
{
	/// <summary>
	/// Base class for providing a access to the database layer.
	/// </summary>
	public class Data
	{

		private static System.Data.Common.DbProviderFactory _DbProviderFactory = null;
		private static System.Data.Common.DbProviderFactory DbProviderFactory
		{
			get
			{
				if (_DbProviderFactory == null)
					_DbProviderFactory = System.Data.Common.DbProviderFactories.GetFactory(DbProviderName);
				return _DbProviderFactory;
			}
		}

        /// <summary>
        /// database connection string
        /// </summary>
        private static string ConnString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["propertiesdb"].ConnectionString;
            }
        }


        /// <summary>
        /// database connection string
        /// </summary>
        private static string DbProviderName
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["propertiesdb"].ProviderName;
            }
        }

        public static System.Data.Common.DbConnection CreateConnection()
        {
            var conn = DbProviderFactory.CreateConnection();
            conn.ConnectionString = ConnString;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Write a query to the Trace to assist with debugging if needed.
        /// </summary>
        public static void TraceWrite(string category, string message)
        {
            if (HttpContext.Current != null && HttpContext.Current.Trace.IsEnabled)
            {
                HttpContext.Current.Trace.Write(category, message);
            }
        }
    }
}