using ViceriWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ViceriWebApi.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
