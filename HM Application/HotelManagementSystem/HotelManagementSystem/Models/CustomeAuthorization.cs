using System;
using System.Web;
using System.Web.Mvc;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
   
    private readonly string[] allowedroles;
    public CustomAuthorizeAttribute(params string[] roles)
    {
        this.allowedroles = roles;
    }
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        bool authorize = false;
        foreach (var role in allowedroles)
        {
            //var user =  context.AppUser.Where(m => m.UserID == GetUser.CurrentUser/* getting user form current context */ && m.Role == role &&
            //m.IsActive == true); // checking active users with allowed roles.  
         var user  =Convert.ToString(httpContext.Session["UserRole"]);
            if (!string.IsNullOrEmpty(user))
            {
                if (role == user)
                {
                    authorize = true; /* return true if Entity has current user(active) with specific role */
                }

            }
        }
        return authorize;
    }
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new HttpUnauthorizedResult();
    }
}