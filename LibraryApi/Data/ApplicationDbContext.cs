using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Library> Libraries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBook> StudentBooks { get; set; }
    }
}
