using DCPC.Challenge.Escola.Api.Models;
using System.Linq.Expressions;

namespace DCPC.Challenge.Escola.Api.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<bool> ExistsAsync(Guid id);

        IQueryable<T> Query();
    }
}