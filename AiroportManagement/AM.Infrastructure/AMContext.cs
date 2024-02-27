using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext:DbContext
    {//DBSETs
        public DbSet<Flight> FLights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Traveller> Traverllers { get; set; }

        public DbSet<Staff> Staffs { get; set; }



        //Configurations de la connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ahmedDB;Integrated Security=true;
                                         MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        //Regle de Mapping Fluent API
        //Conventions relatives a tout le modele 

    }
}
