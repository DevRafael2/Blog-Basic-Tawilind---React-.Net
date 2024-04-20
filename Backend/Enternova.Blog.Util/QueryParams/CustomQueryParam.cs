using Enternova.Blog.Util.QueryParams.Base;
using System.Linq.Expressions;

namespace Enternova.Blog.Util.QueryParams
{
    public class CustomQueryParam<Entity> : QueryParams<Entity>
    {
        public CustomQueryParam(int ActualPage, int ElementsPerPage)
        {
            this.ActualPage = ActualPage;
            this.ElementsPerPage = ElementsPerPage;
        }
        public Expression<Func<Entity, Entity>> Select { get; set; }
        public Expression<Func<Entity, bool>> Where { get; set; }


        public override Expression<Func<Entity, Entity>> GetSelectExpression() => Select;
        public override Expression<Func<Entity, bool>> GetWhereExpression() => Where;
    }
}

