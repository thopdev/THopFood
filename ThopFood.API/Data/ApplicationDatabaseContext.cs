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
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Utensil> Utensils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<RecipeRating>().HasKey(rr => new {rr.RecipeId, rr.UserId});

            modelBuilder.Entity<Recipe>().HasOne(x => x.Owner).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}