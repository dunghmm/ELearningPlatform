using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;

namespace ELearningPlatform.API.Repository.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ELearningContext _dbContext;
        public UnitOfWork(ELearningContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CommitAsync() => await _dbContext.SaveChangesAsync();

        public int Commit() => _dbContext.SaveChanges();

        public void Dispose() { }
    }
}
