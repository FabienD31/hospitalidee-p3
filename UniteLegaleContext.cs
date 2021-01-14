using Hospitalidée_CRM_Back_End.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospitalidée_CRM_Back_End
{
    public class UniteLegaleContext : DbContext
    {
        public virtual DbSet<Etablissement> Etablissements { get; set; }

        public DbSet<UniteLegale> UniteLegale { get; set; }

        public UniteLegaleContext(DbContextOptions<UniteLegaleContext> options)
        : base(options)
        {
        }
    }
}
