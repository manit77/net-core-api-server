using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapp;
using myapp_api_server.Models;

namespace myapp_api_server.Controllers
{
    [ApiController]
    //[JWTTokenFilter]
    [Authorize]
    public class AppUsers : ControllerBase
    {
        [HttpGet("~/profile")]
        public AuthUserModel GetProfile()
        {
            string username = HttpContext.User.Identity.Name;

            AuthUsers authUser = new AuthUsers();
            var (rv, errors) = authUser.GetByUserName(username);
            if (rv)
            {
                AuthUserModel model = new AuthUserModel();

                CoreUtils.Data.CopyProperties(authUser, model);

                return model;

            }
            else
            {
                throw new Exception(errors.ToString());
            }
        }

        [HttpPost("~/updateprofile")]
        public GenericResult UpdateProfile(AuthUserModel postData)
        {
            GenericResult result = new GenericResult();

            string username = HttpContext.User.Identity.Name;

            AuthUsers authUser = new AuthUsers();
            var (rv, errors) = authUser.GetByUserName(username);
            if (rv)
            {
                CoreUtils.Data.CopyProperties(postData, authUser);

                //check for password update
                if (CoreUtils.Data.IsStringNullEmptySpaces(postData.Password))
                {
                    (rv, errors) = authUser.ValidatePassword(postData.Password);
                    if (rv)
                    {
                        authUser.UpdatePassword(postData.Password);
                    }
                    else
                    {
                        throw new Exception(errors.ToString());
                    }
                }

                //validate and save
                (rv, errors) = authUser.Validate();
                if (rv)
                {
                    if (authUser.Save(authUser.Id))
                    {
                        result.Success = true;
                    }
                    else
                    {
                        throw new Exception("unable to save user profile");
                    }
                }
                else
                {
                    throw new Exception(errors.ToString());
                }
            }
            else
            {
                throw new Exception(errors.ToString());
            }

            return result;
        }

        [HttpPost("~/searchusers")]
        public List<AuthUserModel> SearchUsers(AuthUserSearchPost postData)
        {
            List<AuthUserModel> results = myapp.orm.Procedures.SearchAuthUsers<AuthUserModel>(postData.Query).ToList();
            return results;
        }

    }
}
