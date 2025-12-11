using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace ELearningPlatform.Repository.Implements
{
    /// <summary>
    /// Class repository base
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBaseModel
    {
        private readonly ELearningContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public BaseRepository(ELearningContext dbContext, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        #region async
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task<int> CreateAsync(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.DeleteFlag = false;

            await _dbContext.Set<T>().AddAsync(entity);
            return entity.Id;
        }

        public async Task<IList<int>> CreateListAsync(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedAt = DateTime.Now;
                item.UpdatedAt = DateTime.Now;
                item.DeleteFlag = false;
            }
            await _dbContext.Set<T>().AddRangeAsync(entities);
            return entities.Select(x => x.Id).ToList();
        }

        public async Task EndTransactionAsync()
        {
            await SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task<bool> AnyByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>().AsNoTracking().AnyAsync(expression);
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return trackChanges ? await _dbContext.Set<T>().Where(expression).ToListAsync()
                : await _dbContext.Set<T>().AsNoTracking().Where(expression).ToListAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = FindByCondition(expression, trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return await items.ToListAsync();
        }

        public async Task<int> CountByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = FindByCondition(expression, trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return await items.CountAsync();
        }

        public async Task<List<T>> GetAllAsync(bool trackChanges = false)
        {
            return trackChanges ? await _dbContext.Set<T>().ToListAsync()
                : await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = GetAll(trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return await items.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id) && !x.DeleteFlag)
                .FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return await FindByCondition(x => x.Id.Equals(id) && !x.DeleteFlag, false, includeProperties)
                .FirstOrDefaultAsync();
        }

        public Task HardDeleteAsync(int id)
        {
            var obj = FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
            return Task.CompletedTask;
        }

        public Task HardDeleteListAsync(IEnumerable<int> ids)
        {
            var objs = FindByCondition(x => ids.Contains(x.Id));
            if (objs != null && objs.Count() > 0)
            {
                _dbContext.Set<T>().RemoveRange(objs);
            }
            return Task.CompletedTask;
        }

        public async Task RollbackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.CommitAsync();
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var obj = await GetByIdAsync(id);
            if (obj != null)
            {
                obj.UpdatedAt = DateTime.Now;
                obj.DeleteFlag = true;

                _dbContext.Attach(obj);
                _dbContext.Entry(obj).Property(x => x.UpdatedAt).IsModified = true;
                _dbContext.Entry(obj).Property(x => x.DeleteFlag).IsModified = true;
                return true;
            }
            return false;
        }

        public async Task<bool> SoftDeleteListAsync(IEnumerable<int> ids)
        {
            var objs = await FindByConditionAsync(x => ids.Contains(x.Id) && !x.DeleteFlag);
            if (objs != null && objs.Count > 0)
            {
                foreach (var obj in objs)
                {
                    obj.UpdatedAt = DateTime.Now;
                    obj.DeleteFlag = true;

                    _dbContext.Attach(obj);
                    _dbContext.Entry(obj).Property(x => x.UpdatedAt).IsModified = true;
                    _dbContext.Entry(obj).Property(x => x.DeleteFlag).IsModified = true;
                }
                return true;
            }
            return false;
        }

        public Task UpdateAsync(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return Task.CompletedTask;
            entity.UpdatedAt = DateTime.Now;
            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return Task.CompletedTask;
        }

        public Task UpdateListAsync(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedAt = DateTime.Now;
            }
            _dbContext.Set<T>().UpdateRange(entities);
            return Task.CompletedTask;
        }
        #endregion

        #region synchornus
        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public int Create(T entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            entity.DeleteFlag = false;

            _dbContext.Set<T>().Add(entity);

            return entity.Id;
        }

        public IList<int> CreateList(IEnumerable<T> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedAt = DateTime.Now;
                item.UpdatedAt = DateTime.Now;
                item.DeleteFlag = false;
            }
            _dbContext.Set<T>().AddRange(entities);
            return entities.Select(x => x.Id).ToList();
        }

        public void EndTransaction()
        {
            SaveChanges();
            _dbContext.Database.CommitTransaction();
        }

        public bool AnyByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().AsNoTracking().Any(expression);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false)
        {
            return trackChanges ? _dbContext.Set<T>().Where(expression)
                : _dbContext.Set<T>().AsNoTracking().Where(expression);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = FindByCondition(expression, trackChanges);
            items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
            return items;
        }

        public IQueryable<T> GetAll(bool trackChanges = false)
        {
            return trackChanges ? _dbContext.Set<T>()
                : _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties)
        {
            var items = GetAll(trackChanges);
            return items = includeProperties.Aggregate(items, (current, includeProperty) => current.Include(includeProperty));
        }

        public T? GetById(int id, bool trackChanges = true)
        {
            return trackChanges ? _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault()
                : _dbContext.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            //return FindByCondition(x => x.Id.Equals(id) && !x.DeleteFlag, trackChanges).FirstOrDefault();
        }

        public T? GetById(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindByCondition(x => x.Id.Equals(id) && !x.DeleteFlag, false, includeProperties).FirstOrDefault();
        }

        public void HardDelete(int id)
        {
            var obj = FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
            if (obj != null)
            {
                _dbContext.Set<T>().Remove(obj);
            }
        }

        public void HardDeleteList(IEnumerable<int> ids)
        {
            var objs = FindByCondition(x => ids.Contains(x.Id));
            if (objs != null && objs.Count() > 0)
            {
                _dbContext.Set<T>().RemoveRange(objs);
            }
        }

        public void RollbackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public int SaveChanges()
        {
            return _unitOfWork.Commit();
        }

        public bool SoftDelete(int id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                obj.UpdatedAt = DateTime.Now;
                obj.DeleteFlag = true;

                _dbContext.Attach(obj);
                _dbContext.Entry(obj).Property(x => x.UpdatedAt).IsModified = true;
                _dbContext.Entry(obj).Property(x => x.DeleteFlag).IsModified = true;
                return true;
            }
            return false;
        }

        public bool SoftDeleteList(IEnumerable<int> ids)
        {
            var objs = FindByCondition(x => ids.Contains(x.Id) && !x.DeleteFlag, true);
            if (objs != null && objs.Count() > 0)
            {
                foreach (var obj in objs)
                {
                    obj.UpdatedAt = DateTime.Now;
                    obj.DeleteFlag = true;

                    _dbContext.Attach(obj);
                    _dbContext.Entry(obj).Property(x => x.UpdatedAt).IsModified = true;
                    _dbContext.Entry(obj).Property(x => x.DeleteFlag).IsModified = true;
                }
                return true;
            }
            return false;
        }

        public bool Update(T entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Unchanged) return true;
            entity.UpdatedAt = DateTime.Now;
            T exist = _dbContext.Set<T>().Find(entity.Id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return true;
        }

        public bool UpdateList(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                entity.UpdatedAt = DateTime.Now;
            }
            _dbContext.Set<T>().UpdateRange(entities);
            return true;
        }
        #endregion
    }
}
