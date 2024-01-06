using CoreUtils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myapp;
using myapp_api_server.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace myapp_api_server.Controllers
{    
    [ApiController]   
    public class LoginController : ControllerBase
    {
        IJWTTokenManager tokenManager { get; }

        public LoginController(CoreUtils.IJWTTokenManager tokenManager) {
            this.tokenManager = tokenManager;
        }       

        [HttpPost("~/login")]       
        public LoginResult Login([FromBody] LoginPost postData)
        {
            if (postData == null)
            {
                throw new ArgumentNullException($"not data posted");
            }

            if (string.IsNullOrEmpty(postData.UserName) || string.IsNullOrWhiteSpace(postData.UserName))
            {
                throw new ArgumentException($"UserName is required");
            }

            if (string.IsNullOrEmpty(postData.Password) || string.IsNullOrWhiteSpace(postData.Password))
            {
                throw new ArgumentException($"Password is required");
            }
            var result = new LoginResult();

            AuthUsers authUser = new AuthUsers();
            var (rv, errors) = authUser.GetByUserName(postData.UserName);
            if (rv)
            {
                Dictionary<string, string> claims = new Dictionary<string, string>();
                claims.Add(ClaimTypes.Name, authUser.UserName);
                claims.Add(ClaimTypes.Role, authUser.AuthRoles);

                result.AuthToken = this.tokenManager.GenerateToken(claims);
                result.DateExpires = DateTime.UtcNow.AddMinutes(60);

                return result;
            }
            else
            {
                errors.Add("user not found.");
                throw new Exception(errors.ToString());
            }
        }

        [HttpPost("~/register")]
        public UserRegistrationResult UserRegistration(AuthUserModel postData)
        {
            UserRegistrationResult result = new UserRegistrationResult();
            AuthUsers authUser = new AuthUsers();
            authUser.Set(postData);
            authUser.Id = 0;
            var (rv, errors) = authUser.Validate();
            if (rv)
            {
                if (!string.IsNullOrEmpty(postData.Password) && !string.IsNullOrWhiteSpace(postData.Password) && postData.Password.Length > 0 )
                {
                    authUser.UpdatePassword(postData.Password);
                }

                if (authUser.Save())
                {
                    result.Registered = true;
                } 
                else
                {
                    throw new Exception("unable to save your profile");
                }

            } else
            {
                throw new Exception(errors.ToString());
            }

            return result;
        }
    }
}
