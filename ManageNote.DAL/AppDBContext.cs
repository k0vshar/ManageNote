using ManageNote.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ManageNote.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Note> Notes { get; set; }
    }
}
