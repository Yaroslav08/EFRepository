using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Interfaces
{
    public interface ICRUDRepository<TEntity, TypeId> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task CreateRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(List<TEntity> entities);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
        Task<TEntity> GetByIdAsTrackingAysnc(TypeId Id);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FirstAsync();
        Task<TEntity> LastAsync();
        Task<int> CountAsync();
        Task<long> CountLongAsync();
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> FindAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> FindListAsTrackingAsync(Expression<Func<TEntity, bool>> match);
    }
}
