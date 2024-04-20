using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;
using System;

namespace Enternova.Blog.Domain.Services.Interfaces
{
    public interface IService<InDto, OutDto, Entity, QueryParams, IdType> : 
        IGetService<OutDto, Entity, QueryParams, IdType>,
        ISendService<InDto, OutDto, IdType> 
        where QueryParams : QueryParams<Entity>
        where Entity : BaseModel<IdType>
    {

    }
}
