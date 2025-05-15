namespace Task.Application.Common.Interfaces
{
    public interface ITaskDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
