using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

//Do not modify.
//Code generated using custom ORM Mapper on 1/5/2024 12:45:07 AM
namespace myapp.orm
{
    public static partial class Procedures
    {
        //public static partial class Procedures
        //{
        public static T GetAuthUserByEmail<T>(string email)
        {
            object rv = null;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            CoreUtils.IDatabase db = DataAccess.DB;
            parameters.Add(db.GetParameter("@email", email));

            if (typeof(T) == typeof(DataTable))
            {
                rv = db.GetDataTable("GetAuthUserByEmail", parameters, CommandType.StoredProcedure);
            }
            else if (typeof(T) == typeof(SqlDataReader))
            {
                rv = db.GetDataReader("GetAuthUserByEmail", parameters, CommandType.StoredProcedure);
            }
            else
            {
                Type type = typeof(T);
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                {
                    throw new Exception("Generic list is not support. Get SQLDataReader and convert to list.");
                }
                rv = db.Query<T>("GetAuthUserByEmail", parameters, CommandType.StoredProcedure).FirstOrDefault();

            }
            return (T)rv;
        }
        public static T GetAuthUserByUserName<T>(string username)
        {
            object rv = null;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            CoreUtils.IDatabase db = DataAccess.DB;
            parameters.Add(db.GetParameter("@username", username));

            if (typeof(T) == typeof(DataTable))
            {
                rv = db.GetDataTable("GetAuthUserByUserName", parameters, CommandType.StoredProcedure);
            }
            else if (typeof(T) == typeof(SqlDataReader))
            {
                rv = db.GetDataReader("GetAuthUserByUserName", parameters, CommandType.StoredProcedure);
            }
            else
            {
                Type type = typeof(T);
                if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type))
                {
                    throw new Exception("Generic list is not support. Get SQLDataReader and convert to list.");
                }
                var data = db.Query<T>("GetAuthUserByUserName", parameters, CommandType.StoredProcedure);
                rv = data.FirstOrDefault();

            }
            return (T)rv;
        }
        //}// end Procedures
    }//end Procedures
}//end namespace

