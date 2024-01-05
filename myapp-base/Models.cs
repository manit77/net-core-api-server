using myapp.orm;
using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myapp
{
    public class AuthUsers : myapp.orm.AuthUsers
    {
        public AuthUsers() { }

        public override (bool, ErrorList) Validate()
        {
            var errors = new ErrorList();
            if (string.IsNullOrEmpty(this.UserName) || this.UserName.Length == 0)
            {
                errors.Add("User name is required.");
            }

            if (string.IsNullOrEmpty(this.Email) || this.Email.Length == 0)
            {
                errors.Add("User name is required.");
            }

            if (string.IsNullOrEmpty(this.PasswordHash) || this.PasswordHash.Length == 0)
            {
                errors.Add("Password is required.");
            }

            if (errors.Count == 0)
            {
                var dt = Procedures.GetAuthUserByUserName<System.Data.DataTable>(this.Email);
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
                var dt = Procedures.GetAuthUserByUserName<System.Data.DataTable>(this.UserName);
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

            return (false, errors);
        }

        public (bool, ErrorList) GetByUserName(string username)
        {
            var errors = new ErrorList();
            var model = Procedures.GetAuthUserByUserName<AuthUsersModel>(username);
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
            var model = Procedures.GetAuthUserByEmail<AuthUsersModel>(email);
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

        public bool ValidatePassword(string password)
        {
            return CoreUtils.Cryptography.BCryptVerif(password, this.PasswordHash);
        }
    }
}
