using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using AudioShop.DataAccess.Migrations;
using System;

namespace AudioShop.API.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class AdminModAttribute : ActionFilterAttribute
    {
        public AdminModAttribute()
        {
            Order = 1; // выполняется первым, как требует задание
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
            if (roleClaim != "Admin")
            {
                context.Result = new ObjectResult("Доступ только для администраторов.")
                {
                    StatusCode = 403
                };
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}