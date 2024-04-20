using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternova.Blog.Util.Attributes
{
    public class CultureRequest : Attribute
    {
        private readonly string scheme;

        public CultureRequest(string scheme)
        {
            this.scheme = scheme;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;
            if (headers.ContainsKey(scheme))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(headers["x-culture"]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(headers["x-culture"]);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");
            }
            return true;
        }
    }
}
