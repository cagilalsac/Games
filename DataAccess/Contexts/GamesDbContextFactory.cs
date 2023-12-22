using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataAccess.Contexts
{
    public class GamesDbContextFactory : IDesignTimeDbContextFactory<GamesDbContext>
    {
        public GamesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GamesDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GamesDB;trusted_connection=true;trustservercertificate=true;");
            return new GamesDbContext(optionsBuilder.Options); 
        }
    }
}
