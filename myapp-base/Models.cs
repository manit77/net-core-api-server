using Microsoft.Extensions.Configuration;
using myapp.orm;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp
{
    public class AuthUsers : myapp.orm.AuthUsersBase
    {
        public AuthUsers() { }

        public override (bool, ErrorList) Validate()
        {
            var errors = new ErrorList();
            if (string.IsNullOrEmpty(this.UserName) || this.UserName.Length == 0)
            {
                errors.Add("Username is required.");
            }

            if (string.IsNullOrEmpty(this.Email) || this.Email.Length == 0)
            {
                errors.Add("Email is required.");
            }

            if (errors.Count == 0)
            {
                var dt = Procedures.GetAuthUserByUserName_DT(this.Email);
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow r in dt.Rows)
                    {
                        if ((int)r["Id"] != Id)
                        {
                            errors.Add("Email already exists.");
                        }
                    }
                }
            }

            if (errors.Count == 0)
            {
                var dt = Procedures.GetAuthUserByUserName_DT(this.UserName);
                if (dt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow r in dt.Rows)
                    {
                        if ((int)r["Id"] != Id)
                        {
                            errors.Add("User name already exists.");
                        }
                    }
                }
            }

            if (errors.Count == 0)
            {
                return (true, errors);
            }

            return (false, errors);
        }

        public (bool, ErrorList) GetByUserName(string username)
        {
            var errors = new ErrorList();
            var model = Procedures.GetAuthUserByUserName<AuthUsersModel>(username).FirstOrDefault();
            if (model != null)
            {
                base.Set(model);
                return (true, errors);

            }

            return (false, errors);
        }

        public (bool, ErrorList) GetByUserEmail(string email)
        {
            var errors = new ErrorList();
            var model = Procedures.GetAuthUserByEmail<AuthUsersModel>(email).FirstOrDefault();
            if (model != null)
            {
                base.Set(model);
                return (true, errors);

            }

            return (false, errors);
        }

        public override bool Save(int savedByUserid = 0)
        {
            var errors = new ErrorList();

            return base.Save(savedByUserid);
        }

        public void UpdatePassword(string password)
        {
            this.PasswordHash = CoreUtils.Cryptography.BCryptHashPassword(password);
        }

        public bool ValidatePasswordHash(string password)
        {
            return CoreUtils.Cryptography.BCryptVerif(password, this.PasswordHash);
        }

        public (bool, ErrorList) ValidatePassword(string password)
        {
            var errors = new ErrorList();
            if (CoreUtils.Data.IsStringNullEmptySpaces(password))
            {
                errors.Add("password is empty");
                return (false, errors);
            }

            if (password.Length < 6)
            {
                errors.Add("password must be at least 6 characters");
                return (false, errors);
            }

            return (true, errors);
        }
    }

    public class EnumsList : myapp.orm.EnumsListBase
    {

    }

    public class AppConfigs
    {
        private readonly IConfiguration configsection;
        private string connectionString;
        private string jWTSecret;

        public AppConfigs(Microsoft.Extensions.Configuration.IConfiguration configsection)
        {
            this.configsection = configsection;
        }
        public string ConnectionString { get => this.configsection["connectionstring"]; set => connectionString = value; }
        public string JWTSecret { get => this.configsection["jwtsecret"]; set => jWTSecret = value; }
    }
}
