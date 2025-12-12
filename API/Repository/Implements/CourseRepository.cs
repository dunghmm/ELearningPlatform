using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Interfaces;
using static ELearningPlatform.API.Repository.Implements.CourseRepository;

namespace ELearningPlatform.API.Repository.Implements
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly ELearningContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;

        public CourseRepository(ELearningContext dbContext, IUnitOfWork unitOfWork) : base(dbContext, unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }
    }
  
}
