using Microsoft.EntityFrameworkCore;
using Books.Models;
namespace Books.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext (DbContextOptions<BookDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin"},
                new Role { RoleId = 2, RoleName = "User" });
        }

    }
}
