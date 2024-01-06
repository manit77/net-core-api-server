using System;
using System.Collections.Generic;
using System.Text;

//Do not modify. v1.0
//Code generated using custom ORM Mapper on 1/6/2024 12:23:27 AM
namespace myapp.orm
{
    public class ErrorList : List<string>
    {
        public override string ToString()
        {
            return string.Join(".", this.ToArray());
        }
        public string ToString(string seperator)
        {
            return string.Join(seperator, this.ToArray());
        }
    }

    public interface IModel
    {
        (bool, ErrorList) Validate();
        bool Save(int savedByUserid = 0);
    }
    public class AuthUsersBase : AuthUsersModel, IModel
    {
        public void Set(object model)
        {
            CoreUtils.Data.CopyProperties(model, this);
        }

        public virtual (bool, ErrorList) Validate()
        {
            return (true, new ErrorList());
        }

        public virtual bool Save(int savedByUserid = 0)
        {
            if (this.Id == 0)
            {
                this.DateCreated = DateTimeOffset.UtcNow;
                this.UserIdCreated = savedByUserid;
            }
            else
            {
                this.DateModified = DateTimeOffset.UtcNow;
                this.UserIdModified = savedByUserid;
            }
            int rowsaff = DataAccess.AuthUsers_Save(this);
            if (rowsaff > 0)
            {
                return true;
            }
            return false;
        }
    }

    public interface IAuthUsers
    {
        public Int32 Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string AuthRoles { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public Int32 UserIdCreated { get; set; }
        public Int32? UserIdModified { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public partial class AuthUsersModel : IAuthUsers
    {

        public Int32 Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string AuthRoles { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateModified { get; set; }
        public Int32 UserIdCreated { get; set; }
        public Int32? UserIdModified { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class EnumsListBase : EnumsListModel, IModel
    {
        public void Set(object model)
        {
            CoreUtils.Data.CopyProperties(model, this);
        }

        public virtual (bool, ErrorList) Validate()
        {
            return (true, new ErrorList());
        }

        public virtual bool Save(int savedByUserid = 0)
        {
            if (this.Id == 0)
            {
            }
            else
            {
            }
            int rowsaff = DataAccess.EnumsList_Save(this);
            if (rowsaff > 0)
            {
                return true;
            }
            return false;
        }
    }

    public interface IEnumsList
    {
        public Int32 Id { get; set; }
        public string DataGroup { get; set; }
        public string DataText { get; set; }
        public string DisplayText { get; set; }
    }

    public partial class EnumsListModel : IEnumsList
    {

        public Int32 Id { get; set; }
        public string DataGroup { get; set; }
        public string DataText { get; set; }
        public string DisplayText { get; set; }
    }


    public static class SQLStrings
    {
        public const string AuthUsers_Insert = " insert into AuthUsers (UserName,PasswordHash,PasswordSalt,Email,AuthRoles,DateCreated,DateModified,UserIdCreated,UserIdModified,IsActive,FirstName,LastName)VALUES(@UserName,@PasswordHash,@PasswordSalt,@Email,@AuthRoles,@DateCreated,@DateModified,@UserIdCreated,@UserIdModified,@IsActive,@FirstName,@LastName)  select @Id=SCOPE_IDENTITY();";
        public const string AuthUsers_Select = " select [Id],[UserName],[PasswordHash],[PasswordSalt],[Email],[AuthRoles],[DateCreated],[DateModified],[UserIdCreated],[UserIdModified],[IsActive],[FirstName],[LastName] from AuthUsers where Id=@Id";
        public const string AuthUsers_Update = " update AuthUsers set UserName=@UserName,PasswordHash=@PasswordHash,PasswordSalt=@PasswordSalt,Email=@Email,AuthRoles=@AuthRoles,DateCreated=@DateCreated,DateModified=@DateModified,UserIdCreated=@UserIdCreated,UserIdModified=@UserIdModified,IsActive=@IsActive,FirstName=@FirstName,LastName=@LastName where Id=@Id";
        public const string AuthUsers_Delete = " delete from AuthUsers where Id=@Id";

        public const string EnumsList_Insert = " insert into EnumsList (DataGroup,DataText,DisplayText)VALUES(@DataGroup,@DataText,@DisplayText)  select @Id=SCOPE_IDENTITY();";
        public const string EnumsList_Select = " select [Id],[DataGroup],[DataText],[DisplayText] from EnumsList where Id=@Id";
        public const string EnumsList_Update = " update EnumsList set DataGroup=@DataGroup,DataText=@DataText,DisplayText=@DisplayText where Id=@Id";
        public const string EnumsList_Delete = " delete from EnumsList where Id=@Id";
    }
}
