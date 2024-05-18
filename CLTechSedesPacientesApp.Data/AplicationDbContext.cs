using CLTechSedesPacientesApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace CLTechSedesPacientesApp.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Lab61Sedes> Lab61Sedes { get; set; }
    }
}
