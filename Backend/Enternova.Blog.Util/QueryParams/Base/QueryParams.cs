using System.Linq.Expressions;

namespace Enternova.Blog.Util.QueryParams.Base
{
    public abstract class QueryParams<Entity> : BasicQueryParams
    {
        /// <summary>
        /// Expresion usada por entity framework para filtrar
        /// </summary>
        public abstract Expression<Func<Entity, bool>> GetWhereExpression();
        /// <summary>
        /// Expresion usada por entity framework para obtener ciertos datos especificos
        /// </summary>
        public abstract Expression<Func<Entity, Entity>> GetSelectExpression();
    }
}
