namespace ELearningPlatform.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        int Commit();
    }
}
