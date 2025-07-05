using Microsoft.EntityFrameworkCore;
using Providers.Entities;

namespace Providers
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Gets or sets the data set of user.
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the data set of user game collection.
        /// </summary>
        public DbSet<UserGameCollection> UserGameCollection { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }

        public DatabaseContext() : base()
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeUser(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void InitializeUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.GameCollection)
                                       .WithOne(c => c.User)
                                       .HasForeignKey(c => c.UserId);
        }
    }
}
