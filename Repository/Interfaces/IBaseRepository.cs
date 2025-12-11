using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ELearningPlatform.Repository.Interfaces
{
    /// <summary>
    /// Interface repository base
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IBaseRepository<T>
    {
        #region async
        Task<List<T>> GetAllAsync(bool trackChanges = false);
        Task<List<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> AnyByConditionAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false);
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        Task<int> CountByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties);
        Task<int> CreateAsync(T entity);
        Task<IList<int>> CreateListAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateListAsync(IEnumerable<T> entities);
        Task<bool> SoftDeleteAsync(int id);
        Task HardDeleteAsync(int id);
        Task<bool> SoftDeleteListAsync(IEnumerable<int> ids);
        Task HardDeleteListAsync(IEnumerable<int> ids);
        Task<int> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task EndTransactionAsync();
        Task RollbackTransactionAsync();
        #endregion

        #region synchornus
        IQueryable<T> GetAll(bool trackChanges = false);
        IQueryable<T> GetAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        bool AnyByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
        IDbContextTransaction BeginTransaction();
        void EndTransaction();
        void RollbackTransaction();
        int Create(T entity);
        IList<int> CreateList(IEnumerable<T> entities);
        T? GetById(int id, bool trackChanges = true);
        T? GetById(int id, params Expression<Func<T, object>>[] includeProperties);
        void HardDelete(int id);
        void HardDeleteList(IEnumerable<int> ids);
        int SaveChanges();
        bool SoftDelete(int id);
        bool SoftDeleteList(IEnumerable<int> ids);
        bool Update(T entity);
        bool UpdateList(IEnumerable<T> entities);
        #endregion
    }
}
