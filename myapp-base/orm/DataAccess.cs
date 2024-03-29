using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using CoreUtils;

//Do not modify.
//Code generated using custom ORM Mapper on 1/7/2024 11:30:32 PM
namespace myapp.orm
{
    public static partial class DataAccess
    {
        public static IDatabase DB { get; set; }
        #region execute code
        /*
        */
        #endregion
        #region AuthUsers
        public static AuthUsersBase AuthUsers_Get(Int32 Id)
        {
            AuthUsersBase model = null;
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(db.GetParameter("@Id", Id));
            IDataReader r = null;
            try
            {
                r = db.GetDataReader(SQLStrings.AuthUsers_Select, parameters, CommandType.Text);
                if (r.Read())
                {
                    int posId = r.GetOrdinal("Id");
                    int posUserName = r.GetOrdinal("UserName");
                    int posPasswordHash = r.GetOrdinal("PasswordHash");
                    int posPasswordSalt = r.GetOrdinal("PasswordSalt");
                    int posEmail = r.GetOrdinal("Email");
                    int posAuthRoles = r.GetOrdinal("AuthRoles");
                    int posDateCreated = r.GetOrdinal("DateCreated");
                    int posDateModified = r.GetOrdinal("DateModified");
                    int posUserIdCreated = r.GetOrdinal("UserIdCreated");
                    int posUserIdModified = r.GetOrdinal("UserIdModified");
                    int posIsActive = r.GetOrdinal("IsActive");
                    int posFirstName = r.GetOrdinal("FirstName");
                    int posLastName = r.GetOrdinal("LastName");
                    model = new AuthUsersBase
                    {
                        Id = (Int32)(r[posId]),
                        UserName = (string)(r[posUserName]),
                        PasswordHash = (string)(r[posPasswordHash]),
                        PasswordSalt = (string)(r[posPasswordSalt]),
                        Email = (string)(r[posEmail]),
                        AuthRoles = (string)(r[posAuthRoles]),
                        DateCreated = (DateTimeOffset)(r[posDateCreated]),
                        DateModified = Data.CastIt<DateTimeOffset>(r[posDateModified]),
                        UserIdCreated = (Int32)(r[posUserIdCreated]),
                        UserIdModified = Data.CastIt<Int32>(r[posUserIdModified]),
                        IsActive = (bool)(r[posIsActive]),
                        FirstName = (string)(r[posFirstName]),
                        LastName = (string)(r[posLastName]),
                    };
                }
                r.Close();
            }
            catch
            {
                try
                {
                    if (r != null)
                    {
                        // don't do this in finally clause or reader will not close
                        r.Close();
                        r.Dispose();
                    }
                }
                catch { }
                throw;
            }
            return model;
        }
        public static AuthUsersBase AuthUsers_Get(DataRow r)
        {
            AuthUsersBase model = new AuthUsersBase()
            {
                Id = (Int32)(r["Id"]),
                UserName = (string)(r["UserName"]),
                PasswordHash = (string)(r["PasswordHash"]),
                PasswordSalt = (string)(r["PasswordSalt"]),
                Email = (string)(r["Email"]),
                AuthRoles = (string)(r["AuthRoles"]),
                DateCreated = (DateTimeOffset)(r["DateCreated"]),
                DateModified = Data.CastIt<DateTimeOffset>(r["DateModified"]),
                UserIdCreated = (Int32)(r["UserIdCreated"]),
                UserIdModified = Data.CastIt<Int32>(r["UserIdModified"]),
                IsActive = (bool)(r["IsActive"]),
                FirstName = (string)(r["FirstName"]),
                LastName = (string)(r["LastName"]),
            };
            return model;
        }
        public static int AuthUsers_Save(IAuthUsers _AuthUsers)
        {
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter paramId = db.GetParameterOut("@Id", _AuthUsers.Id, System.Data.DbType.Int32);
            parameters.Add(paramId);
            parameters.Add(db.GetParameter("@UserName", _AuthUsers.UserName ?? ""));
            parameters.Add(db.GetParameter("@PasswordHash", _AuthUsers.PasswordHash ?? ""));
            parameters.Add(db.GetParameter("@PasswordSalt", _AuthUsers.PasswordSalt ?? ""));
            parameters.Add(db.GetParameter("@Email", _AuthUsers.Email ?? ""));
            parameters.Add(db.GetParameter("@AuthRoles", _AuthUsers.AuthRoles ?? ""));
            parameters.Add(db.GetParameter("@DateCreated", _AuthUsers.DateCreated));
            parameters.Add(db.GetParameter("@DateModified", _AuthUsers.DateModified));
            parameters.Add(db.GetParameter("@UserIdCreated", _AuthUsers.UserIdCreated));
            parameters.Add(db.GetParameter("@UserIdModified", _AuthUsers.UserIdModified));
            parameters.Add(db.GetParameter("@IsActive", _AuthUsers.IsActive));
            parameters.Add(db.GetParameter("@FirstName", _AuthUsers.FirstName ?? ""));
            parameters.Add(db.GetParameter("@LastName", _AuthUsers.LastName ?? ""));
            if (_AuthUsers.Id == 0)
            {
                int rowsaff = db.ExecuteNonQuery(SQLStrings.AuthUsers_Insert, parameters, CommandType.Text);
                _AuthUsers.Id = (Int32)paramId.Value;
                return rowsaff;
            }
            else
            {
                return db.ExecuteNonQuery(SQLStrings.AuthUsers_Update, parameters, CommandType.Text);
            }
        }
        public static int AuthUsers_Delete(int Id)
        {
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter paramId = new SqlParameter();
            paramId.ParameterName = "@Id";
            paramId.Value = Id;
            parameters.Add(paramId);
            return db.ExecuteNonQuery(SQLStrings.AuthUsers_Delete, parameters, CommandType.Text);
        }
        #endregion
        #region EnumsList
        public static EnumsListBase EnumsList_Get(Int32 Id)
        {
            EnumsListBase model = null;
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            parameters.Add(db.GetParameter("@Id", Id));
            IDataReader r = null;
            try
            {
                r = db.GetDataReader(SQLStrings.EnumsList_Select, parameters, CommandType.Text);
                if (r.Read())
                {
                    int posId = r.GetOrdinal("Id");
                    int posDataGroup = r.GetOrdinal("DataGroup");
                    int posDataText = r.GetOrdinal("DataText");
                    int posDisplayText = r.GetOrdinal("DisplayText");
                    model = new EnumsListBase
                    {
                        Id = (Int32)(r[posId]),
                        DataGroup = (string)(r[posDataGroup]),
                        DataText = (string)(r[posDataText]),
                        DisplayText = (string)(r[posDisplayText]),
                    };
                }
                r.Close();
            }
            catch
            {
                try
                {
                    if (r != null)
                    {
                        // don't do this in finally clause or reader will not close
                        r.Close();
                        r.Dispose();
                    }
                }
                catch { }
                throw;
            }
            return model;
        }
        public static EnumsListBase EnumsList_Get(DataRow r)
        {
            EnumsListBase model = new EnumsListBase()
            {
                Id = (Int32)(r["Id"]),
                DataGroup = (string)(r["DataGroup"]),
                DataText = (string)(r["DataText"]),
                DisplayText = (string)(r["DisplayText"]),
            };
            return model;
        }
        public static int EnumsList_Save(IEnumsList _EnumsList)
        {
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter paramId = db.GetParameterOut("@Id", _EnumsList.Id, System.Data.DbType.Int32);
            parameters.Add(paramId);
            parameters.Add(db.GetParameter("@DataGroup", _EnumsList.DataGroup ?? ""));
            parameters.Add(db.GetParameter("@DataText", _EnumsList.DataText ?? ""));
            parameters.Add(db.GetParameter("@DisplayText", _EnumsList.DisplayText ?? ""));
            if (_EnumsList.Id == 0)
            {
                int rowsaff = db.ExecuteNonQuery(SQLStrings.EnumsList_Insert, parameters, CommandType.Text);
                _EnumsList.Id = (Int32)paramId.Value;
                return rowsaff;
            }
            else
            {
                return db.ExecuteNonQuery(SQLStrings.EnumsList_Update, parameters, CommandType.Text);
            }
        }
        public static int EnumsList_Delete(int Id)
        {
            IDatabase db = DataAccess.DB;
            List<IDbDataParameter> parameters = new List<IDbDataParameter>();
            IDbDataParameter paramId = new SqlParameter();
            paramId.ParameterName = "@Id";
            paramId.Value = Id;
            parameters.Add(paramId);
            return db.ExecuteNonQuery(SQLStrings.EnumsList_Delete, parameters, CommandType.Text);
        }
        #endregion
    }//end DataAccess
}//end namespace

