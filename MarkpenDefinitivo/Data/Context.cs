using Microsoft.EntityFrameworkCore;
using MarkpenDefinitivo.Model;

namespace MarkpenDefinitivo.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<MarkpenDefinitivo.Model.Lugar> Lugar { get; set; }
        public DbSet<MarkpenDefinitivo.Model.Publicacion> Publicacion { get; set; }
        public DbSet<MarkpenDefinitivo.Model.PublicacionLugares> PublicacionLugares { get; set; }
    }
}
