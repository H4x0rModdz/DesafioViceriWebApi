using ViceriWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ViceriWebApi.Data
{
    public interface IAppDbContext
    {
            DbSet<Usuario> Usuarios { get; set; }
            int SaveChanges();
    }
}
