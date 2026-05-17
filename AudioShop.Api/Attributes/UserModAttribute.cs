using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using AudioShop.DataAccess.Migrations;

namespace AudioShop.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class UserModAttribute : ActionFilterAttribute
    {
        public UserModAttribute()
        {
            Order = 2; // выполняется после AdminMod
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult("Требуется авторизация (гость).");
                return;
            }

            var roleClaim = user.FindFirst(ClaimTypes.Role)?.Value;
            if (roleClaim != "User" && roleClaim != "Manager" && roleClaim != "Admin")
            {
                context.Result = new ObjectResult("Недостаточно прав.")
                {
                    StatusCode = 403
                };
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}