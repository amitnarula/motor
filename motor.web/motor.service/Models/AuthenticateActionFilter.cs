using motor.logic.model;
using motor.logic.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace motor.service.Models
{
    public class AuthenticateActionFilter : ActionFilterAttribute
    {
        
        UserService svc = new UserService();

        private bool IsAuthenticationTokenValid(AuthenticationToken tkn)
        {
            return tkn.Expires >= DateTime.UtcNow;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var authenticationToken = actionContext.Request.Headers.GetValues("authToken").SingleOrDefault();
            var httpStatusForbidden  = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            if (string.IsNullOrEmpty(authenticationToken))
            {
                actionContext.Response = httpStatusForbidden;
                return;
            }

            //validate authentication token
            var token = svc.GetAuthenticationToken(authenticationToken);
            if (token == null)
            {
                actionContext.Response = httpStatusForbidden;
                return;
            }

            if (!IsAuthenticationTokenValid(token))
            {
                actionContext.Response= httpStatusForbidden;
                return;
            }
            
            base.OnActionExecuting(actionContext);
            
        }
    }
}