using Enternova.Blog.Data.Context;
using Enternova.Blog.Data.Repositories.Interfaces.Security;
using Enternova.Blog.Dtos.Base;
using Enternova.Blog.Models.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Enternova.Blog.Data.Repositories.Implementations.Security
{
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        public UserRepository(EnternovaBlogContext context) : base(context)
        {
        }

        public override async Task<Status> UpdateAsync(long Id, User InEntity)
        {
            InEntity.Id = Id;
            _dbSet = _context.Set<User>();
            _dbSet.AsNoTracking();
            var existingEntity = _dbSet.Local.FirstOrDefault(e => e.Id == InEntity.Id);
            if (existingEntity is not null)
                _context.Entry(existingEntity).State = EntityState.Detached;

            var updateEntity = await Task.Run(() => _dbSet.Update(InEntity));
            updateEntity.Property(x => x.Password).IsModified = false;
            updateEntity.Property(x => x.CreatedAt).IsModified = false;


            return new Status() { IsComplete = true };
        }
    }
}
