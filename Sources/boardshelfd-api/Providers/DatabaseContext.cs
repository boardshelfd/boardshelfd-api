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

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DatabaseContext() : base()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeUser(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void InitializeUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("APP_USER");
            modelBuilder.Entity<User>().HasKey(u => new { u.Id });
            modelBuilder.Entity<User>().Property(u => u.Id).HasColumnName("USR_ID").HasColumnType("int");
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("USR_NAME").HasColumnType("varchar(64)");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("USR_PWD").HasColumnType("varchar(max)");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("USR_EMAIL").HasColumnType("varchar(max)");
        }
    }
}
