using Microsoft.EntityFrameworkCore;
using ShalomLibrary.Models.Domain;

namespace ShalomLibrary.Data
{
    public class ShalomLibraryDbContext : DbContext
    {
        public ShalomLibraryDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Books> Books { get; set; }
    }
}
