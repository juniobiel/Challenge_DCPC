using DCPC.Challenge.Escola.Api.Models;
using System.Linq.Expressions;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id, CancellationToken ct);
        Task<List<T>> ListAsync(CancellationToken ct);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
        Task AddAsync(T entity, CancellationToken ct);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> ExistsAsync(Guid id, CancellationToken ct);

        IQueryable<T> Query();
    }
}