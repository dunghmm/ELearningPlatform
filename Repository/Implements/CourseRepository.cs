using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Interfaces;
using static ELearningPlatform.Repository.Implements.CourseRepository;

namespace ELearningPlatform.Repository.Implements
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
