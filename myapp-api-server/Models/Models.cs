namespace myapp_api_server.Models
{
    public class LoginPost
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class LoginResult
    {
        public string AuthToken { get; set; }
        public DateTimeOffset DateExpires { get; set; }
    }

    public class GenericResult
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }

    public class UserRegistrationResult
    {
        public bool Registered { get; set; } = false;
    }

    public class AuthUserModel
    {
        public string UserName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string AuthRoles { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? DateModified { get; set; } = DateTimeOffset.Now;
        public bool IsActive { get; set; } = true;
    }

    public class AuthUserSearchPost
    {
        public string Query { get; set; } }
    }

