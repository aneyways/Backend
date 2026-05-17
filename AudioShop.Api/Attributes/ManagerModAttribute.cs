using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using AudioShop.DataAccess.Migrations;

namespace AudioShop.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class ManagerModAttribute : ActionFilterAttribute
    {
        public ManagerModAttribute()
        {
            Order = 2; // после AdminMod
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = context.HttpContext.User;

            if (user?.Identity == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedObjectResult("Требуется авторизация.");
                return;
            }

            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            if (role != "Manager" && role != "Admin")
            {
                context.Result = new ObjectResult("Доступ только для менеджеров и администраторов.")
                {
                    StatusCode = 403
                };
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}