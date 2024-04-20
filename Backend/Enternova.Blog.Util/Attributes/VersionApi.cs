using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enternova.Blog.Util.Attributes
{
    public class VersionApi : Attribute, IActionConstraint
    {
        private readonly string scheme;
        private readonly string value;

        public VersionApi(string Scheme, string Value)
        {
            scheme = Scheme;
            value = Value;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;
            if (!headers.ContainsKey(scheme))
                return false;

            return string.Equals(headers[scheme], value, StringComparison.OrdinalIgnoreCase);
        }
    }
}
