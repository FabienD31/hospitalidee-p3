using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospitalidée_CRM_Back_End.Models
{
    public class UniteLegaleContext : DbContext
    {
        public virtual DbSet<Etablissement> Etablissement { get; set; }
        public virtual DbSet<UniteLegale> UniteLegale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LOCALHOST\SQLEXPRESS;Database=Hospitalidee-Backen;Integrated Security=True");
        }
    }
}
