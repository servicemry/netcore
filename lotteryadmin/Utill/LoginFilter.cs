using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace lotteryadmin.Utill
{
    public class LoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            base.OnActionExecuting(filtercontext);
        }
    }
}
