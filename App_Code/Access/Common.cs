using System;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace REIQ.Access
{
	/// <summary>
	/// Exposes common data access methos methods 
	/// </summary>
    public class Common
	{
		/// <summary>
		/// Return an entity by its ID
		/// </summary>
		/// <typeparam name="T">The type of the entity</typeparam>
		/// <typeparam name="S">The type of the identity column</typeparam>
		/// <param name="id">The id value</param>
		/// <returns>The found object, null if not found</returns>
		public static T Get<T, S>(S id)
		{
            var entityAttribute = (REIQ.Entities.InfoAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(REIQ.Entities.InfoAttribute));
			if (entityAttribute == null || String.IsNullOrEmpty(entityAttribute.TableName) || String.IsNullOrEmpty(entityAttribute.IdentityColumnName))
			{
				throw new ArgumentException(String.Format("Missing attributes for Type {0}", typeof(T).ToString()));
			}
			using (var conn = Data.CreateConnection())
			{
                return conn.Query<T>(String.Format("SELECT * FROM {0} WHERE `{1}` = @Id",
                        entityAttribute.TableName,
                        entityAttribute.IdentityColumnName), new { Id = id }).FirstOrDefault();
			}
		}

        /// <summary>
        /// Lists all entities.  Use sparingly, as some tables contain MANY items
        /// </summary>
		public static IEnumerable<T> List<T>()
		{
            var entityAttribute = (REIQ.Entities.InfoAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(REIQ.Entities.InfoAttribute));
			if (entityAttribute == null || String.IsNullOrEmpty(entityAttribute.TableName))
			{
				throw new ArgumentException(String.Format("Missing attributes for Type {0}", typeof(T).ToString()));
			}

			using (var conn = Data.CreateConnection())
			{
                return conn.Query<T>(String.Format("SELECT * FROM {0}", entityAttribute.TableName), null);
			}
		}

        /// <summary>
        /// Delete an entity
        /// </summary>
		public static void Delete<T, U>(U id)
		{
            var entityAttribute = (REIQ.Entities.InfoAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(REIQ.Entities.InfoAttribute));
			if (entityAttribute == null || String.IsNullOrEmpty(entityAttribute.TableName) || String.IsNullOrEmpty(entityAttribute.IdentityColumnName))
			{
				throw new ArgumentException(String.Format("Missing attributes for Type {0}", typeof(T).ToString()));
			}
			using (var conn = Data.CreateConnection())
			{
                conn.Execute(String.Format("DELETE FROM {0} WHERE {1} = @Id",
                        entityAttribute.TableName,
                        entityAttribute.IdentityColumnName), new { Id = id });
			}
		}

		/// <summary>
        /// Execute an arbitrary command.... use at own risk!
        /// </summary>
        internal static void Execute(string qry, object parameters)
        {
            using (var conn = Data.CreateConnection())
            {
                conn.Execute(qry, parameters);
            }
        }

        /// <summary>
        /// In case we feel lazy... this sure comes in handy
        /// </summary>
        public static IEnumerable<T> QuickQuery<T>(string sql, object sqlParams = null)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query<T>(sql, sqlParams);
            }
        }

        /// <summary>
        /// Dynamic query - returns an ExpandoObject (dynamic) object
        /// </summary>
        public static dynamic QuickQuery(string sql, object sqlParams)
        {
            using (var conn = Data.CreateConnection())
            {
                return conn.Query(sql, sqlParams);
            }
        }
		
	}
}