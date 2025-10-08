using DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces;
using DCPC.Challenge.Escola.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DCPC.Challenge.Escola.Api.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _db;
        protected readonly DbSet<T> _set;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _set = db.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
            => await _set.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);

        public virtual async Task<List<T>> ListAsync()
            => await _set.AsNoTracking().ToListAsync();

        public virtual async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
            => await _set.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task AddAsync(T entity)
            => await _set.AddAsync(entity);

        public virtual void Update(T entity)
            => _set.Update(entity);

        public virtual void Remove(T entity)
            => _set.Remove(entity);

        public virtual Task<bool> ExistsAsync(Guid id)
            => _set.AnyAsync(e => e.Id == id);

        public virtual IQueryable<T> Query()
            => _set.AsQueryable();
    }
}