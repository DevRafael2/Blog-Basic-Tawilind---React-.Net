using Enternova.Blog.Data.Context;
using Enternova.Blog.Data.Repositories.Interfaces;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Base;
using Enternova.Blog.Util.QueryParams.Base;
using Microsoft.EntityFrameworkCore;

namespace Enternova.Blog.Data.Repositories.Implementations
{
    public class Repository<Entity, IdType> : IRepository<Entity, IdType>
        where Entity : BaseModel<IdType>, new()
    {
        protected readonly EnternovaBlogContext _context;
        protected DbSet<Entity> _dbSet { get; set; }

        public Repository(EnternovaBlogContext context)
        {
            this._context = context;
        }
        public virtual async Task<StatusData<Entity>> CreateAsync(Entity Entity)
        {
            _dbSet = _context.Set<Entity>();
            _dbSet.AsNoTracking();
            await _dbSet.AddAsync(Entity);

            return new StatusData<Entity>() { IsComplete = true, Data = Entity };
        }

        public virtual async Task<StatusData<IEnumerable<Entity>>> GetAsync(QueryParams<Entity> FilterParams = null)
        {
            IQueryable<Entity> dbSet = _context.Set<Entity>();
            dbSet.AsNoTracking();
            if (FilterParams.GetWhereExpression() is not null)
                dbSet = dbSet.Where(FilterParams.GetWhereExpression());
            if (FilterParams.GetSelectExpression() is not null)
                dbSet = dbSet.Select(FilterParams.GetSelectExpression());

            var countData = dbSet.Count();
            int totalPages = (int)Math.Ceiling((double)countData / FilterParams.ElementsPerPage);
            int Index = (FilterParams.ActualPage - 1) * FilterParams.ElementsPerPage;

            return new StatusData<IEnumerable<Entity>>() { IsComplete = true, Data = await dbSet.Skip(Index).Take(FilterParams.ElementsPerPage).ToListAsync(), NumberOfPages = totalPages };

        }

        public virtual async Task<StatusData<Entity>> GetFirstAsync(IdType Id)
        {
            return new StatusData<Entity> { IsComplete = true, Data = await _context.Set<Entity>().FirstOrDefaultAsync(x => x.Id.Equals(Id)) };
        }


        public virtual async Task<Status> UpdateAsync(IdType Id, Entity InEntity)
        {
            InEntity.Id = Id;
            _dbSet = _context.Set<Entity>();
            var existingEntity = _dbSet.Local.FirstOrDefault(e => e.Id.Equals(InEntity.Id));
            if (existingEntity is not null)
                _context.Entry(existingEntity).State = EntityState.Detached;

            var update = await Task.Run(() => _dbSet.Update(InEntity));
            update.Property(x => x.CreatedAt).IsModified = false;
            return new Status() { IsComplete = true };
        }


        public virtual async Task<bool> SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<Status> DeleteAsync(IdType Id)
        {
            await Task.Run(() => _context.Set<Entity>().Remove(new Entity { Id = Id }));
            return new Status() { IsComplete = true };
        }
    }
}
