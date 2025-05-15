using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;



namespace Task.Infrastructure.Data
{
    public static class InitialiserExtensions
    {
        public static async System.Threading.Tasks.Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<BasicDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }

    public class BasicDbContextInitialiser
    {
        private readonly ILogger<BasicDbContextInitialiser> _logger;
        private readonly CVDbContext _context;

        public BasicDbContextInitialiser(ILogger<BasicDbContextInitialiser> logger, CVDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async System.Threading.Tasks.Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async System.Threading.Tasks.Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async System.Threading.Tasks.Task TrySeedAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
