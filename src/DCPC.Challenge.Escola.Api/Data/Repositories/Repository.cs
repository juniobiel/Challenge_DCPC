using DCPC.Challenge.Escola.Api.Data;
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

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken ct)
            => await _set.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id, ct);

        public virtual async Task<List<T>> ListAsync(CancellationToken ct)
            => await _set.AsNoTracking().ToListAsync(ct);

        public virtual async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct)
            => await _set.AsNoTracking().Where(predicate).ToListAsync(ct);

        public virtual async Task AddAsync(T entity, CancellationToken ct)
            => await _set.AddAsync(entity, ct);

        public virtual void Update(T entity)
            => _set.Update(entity);

        public virtual void Remove(T entity)
            => _set.Remove(entity);

        public virtual Task<bool> ExistsAsync(Guid id, CancellationToken ct)
            => _set.AnyAsync(e => e.Id == id, ct);

        public virtual IQueryable<T> Query()
            => _set.AsQueryable();
    }
}