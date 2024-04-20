using AutoMapper;
using Enternova.Blog.Data.Repositories.Interfaces;
using Enternova.Blog.Domain.Services.Interfaces;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Lang.Services;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;
using Microsoft.Extensions.Localization;

namespace Enternova.Blog.Domain.Services.Implementations
{
    public class Service<InDto, OutDto, Entity, QueryParam, IdType> : IService<InDto, OutDto, Entity, QueryParam, IdType>
        where QueryParam : QueryParams<Entity>
        where Entity : BaseModel<IdType>
    {
        protected readonly IRepository<Entity, IdType> _repository;
        protected readonly IMapper _mapper;
        protected readonly IStringLocalizer<BaseService> _stringLocalizer;

        public Service(IRepository<Entity, IdType> repository, IMapper mapper, IStringLocalizer<BaseService> stringLocalizer)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }
        public virtual async Task<StatusData<IEnumerable<OutDto>>> GetAsync(QueryParam FilterParams = default)
        {
            var data = await _repository.GetAsync(FilterParams);
            return new StatusData<IEnumerable<OutDto>>() { IsComplete = true, Data = _mapper.Map<List<OutDto>>(data.Data), Message = _stringLocalizer["success_get"], NumberOfPages = data.NumberOfPages };
        }

        public virtual async Task<StatusData<OutDto>> GetFirstAsync(IdType Id)
        {
            var data = await _repository.GetFirstAsync(Id);
            return new StatusData<OutDto>() { IsComplete = true, Data = _mapper.Map<OutDto>(data.Data), Message = _stringLocalizer["success_get"] };
        }

        public virtual async Task<StatusData<OutDto>> CreateAsync(InDto InEntity)
        {
            Entity entity = _mapper.Map<Entity>(InEntity);

            var validate = await ValidateToCreate(entity);
            if (!validate.IsComplete)
                return validate;


            var status = await _repository.CreateAsync(entity);
            await _repository.SaveChangesAsync();

            return new StatusData<OutDto> { IsComplete = true, Data = _mapper.Map<OutDto>(status.Data), Message = _stringLocalizer["success_create"] };
        }

        public virtual async Task<Status> DeleteAsync(IdType Id)
        {
            var validate = await ValidateToDelete(Id);
            if (!validate.IsComplete)
                return validate;

            var status = await _repository.DeleteAsync(Id);
            await _repository.SaveChangesAsync();
            status.Message = _stringLocalizer["success_delete"];
            return status;
        }



        public virtual async Task<Status> UpdateAsync(IdType Id, InDto InEntity)
        {
            var entity = _mapper.Map<Entity>(InEntity);
            var validate = await ValidateToUpdate(Id, entity);
            if (!validate.IsComplete)
                return validate;

            var status = await _repository.UpdateAsync(Id, entity);
            await _repository.SaveChangesAsync();
            status.Message = _stringLocalizer["success_update"];
            return status;
        }


        public virtual Task<StatusData<OutDto>> ValidateToCreate(Entity entity) => Task.FromResult(new StatusData<OutDto> { IsComplete = true});
        public virtual Task<Status> ValidateToUpdate(IdType Id, Entity entity) => Task.FromResult(new Status { IsComplete = true });
        public virtual Task<Status> ValidateToDelete(IdType Id) => Task.FromResult(new Status { IsComplete = true });
    }
}
