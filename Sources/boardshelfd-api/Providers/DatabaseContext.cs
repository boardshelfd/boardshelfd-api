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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Database=ex_01_01_ConnectionStrings.DATABASE.mdf");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeUser(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void InitializeUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("USER");
            modelBuilder.Entity<User>().HasKey(u => new { u.Id });
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("USR_NAME").HasColumnType("varchar(64)");
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("USR_PWD").HasColumnType("varchar(128)");
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("USR_EMAIL").HasColumnType("varchar(max)");
        }
    }
}
