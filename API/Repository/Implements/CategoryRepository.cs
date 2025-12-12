using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;

namespace ELearningPlatform.API.Repository.Implements
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ELearningContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(ELearningContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
    }
}
