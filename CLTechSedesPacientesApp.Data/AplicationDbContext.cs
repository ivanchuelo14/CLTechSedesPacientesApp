using CLTechSedesPacientesApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLTechSedesPacientesApp.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lab63Sedes> Lab63Sedes { get; set; }

        public DbSet<SpLab63Model> SpLab63Model { get; set; }
    }
}
