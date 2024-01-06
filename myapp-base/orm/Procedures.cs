using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

//Do not modify.
//Code generated using custom ORM Mapper on 1/6/2024 12:23:27 AM
namespace myapp.orm
{
    public static partial class Procedures
    {
        public static DataTable GetAuthUserByEmail_DT(string email)
        {
            string sql = "GetAuthUserByEmail";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DataAccess.DB.GetParameter("@email", email));
            return DataAccess.DB.GetDataTable(sql, parameters, CommandType.StoredProcedure);
        }
        public static IEnumerable<T> GetAuthUserByEmail<T>(string email)
        {
            string sql = "GetAuthUserByEmail";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DataAccess.DB.GetParameter("@email", email));
            return DataAccess.DB.Query<T>(sql, parameters, CommandType.StoredProcedure);
        }
        public static DataTable GetAuthUserByUserName_DT(string username)
        {
            string sql = "GetAuthUserByUserName";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DataAccess.DB.GetParameter("@username", username));
            return DataAccess.DB.GetDataTable(sql, parameters, CommandType.StoredProcedure);
        }
        public static IEnumerable<T> GetAuthUserByUserName<T>(string username)
        {
            string sql = "GetAuthUserByUserName";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DataAccess.DB.GetParameter("@username", username));
            return DataAccess.DB.Query<T>(sql, parameters, CommandType.StoredProcedure);
        }
        public static IEnumerable<T> SearchAuthUsers<T>(string query)
        {
            string sql = "SearchAuthUsers";
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(DataAccess.DB.GetParameter("@query", query));
            return DataAccess.DB.Query<T>(sql, parameters, CommandType.StoredProcedure);
        }
    }
}

