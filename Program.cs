using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hospitalidée_CRM_Back_End.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Hospitalidée_CRM_Back_End
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddDatabase();
            CreateHostBuilder(args).Build().Run();
        }
        private static void AddDatabase()
        {
            using (var context = new UniteLegaleContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                UniteLegale unite = new UniteLegale()
                {
                    nom = "test ",
                    prenom_usuel = "coucou",
                    etablissement = new List<Etablissement>()
                    {
                        new Etablissement {denomination_usuelle = "coucou"},
                        new Etablissement { denomination_usuelle = "coucou2"}
                        
                    }
                    
                };

                
               
                context.AddRange(unite);
                context.SaveChanges();


            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }


}
