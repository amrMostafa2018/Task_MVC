namespace Task.Application.Common.Interfaces
{
    public interface ICVDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
