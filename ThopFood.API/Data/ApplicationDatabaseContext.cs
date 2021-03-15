using Microsoft.EntityFrameworkCore;
using ThopFood.API.Data.Entities;

namespace ThopFood.API.Data
{
    public class ApplicationDatabaseContext : DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
