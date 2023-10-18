using CharacterAPI.Data;
using DataSeeder.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataSeeder
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var dbConnectionString = "server=localhost\\sqlexpress;database=characterdb;trusted_connection=true;TrustServerCertificate=True";
            
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(dbConnectionString);
            });

            var dataContext = serviceCollection.BuildServiceProvider().GetService<DataContext>();
            await dataContext.Database.EnsureCreatedAsync();

            await CharacterSeeder.SeedPersons(dataContext).ConfigureAwait(false);

            await dataContext.DisposeAsync();
        }
    }
}
