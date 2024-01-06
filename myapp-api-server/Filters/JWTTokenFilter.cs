using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace myapp_api_server.Filters
{
    public class JWTTokenFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
           var tokenManager = context.HttpContext.RequestServices.GetService<CoreUtils.IJWTTokenManager>();

            var validated = true;
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                validated = false;
            }

            string token = string.Empty;
            
            if (validated)
            {
                token = context.HttpContext.Request.Headers.First(i => i.Key == "Authorization").Value;
                token = token.Replace("Bearer", "").Trim();

                var claims = tokenManager.GetClaims(token);
                if (claims == null)
                {
                    validated = false;
                } else
                {
                    var task = context.HttpContext.SignInAsync(claims);
                    if (!task.Wait(5000))
                    {
                        throw new Exception("unable to sign in");
                    }
                }
            }

            //verify token
            if (!validated)
            {
                context.ModelState.AddModelError("Unauthorized", "Not Authorized");
                context.Result = new UnauthorizedObjectResult(context.ModelState);
            } 
            
        }
    }
}
