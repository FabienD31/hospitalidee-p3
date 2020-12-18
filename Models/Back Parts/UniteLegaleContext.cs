using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Models
{
    public class UniteLegaleContext : DbContext
    {
        public virtual DbSet<Etablissement> etablissements { get; set; }
        public virtual DbSet<UniteLegale> uniteLegale { get; set; }
        public UniteLegaleContext(DbContextOptions<UniteLegaleContext> options)
        : base(options)
        {
        }
    }
}
