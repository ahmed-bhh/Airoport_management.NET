using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
//using AM.Infrastructure.Migrations;
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
        public DbSet<Ticket> Tickets { get; set; }



        //Configurations de la connexion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=ahmedDB;Integrated Security=true;
                                         MultipleActiveResultSets=true");
          //  optionsBuilder.UseLa; ma habech yahbet proxies
            base.OnConfiguring(optionsBuilder);
        }
        //fluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //   modelBuilder.ApplyConfiguration(new PlaneConfiguration()); methode 1 par classe de configuration

            //methode 2 sans classe
            modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            modelBuilder.Entity<Plane>().ToTable("MyPlanes");
            modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");


           // modelBuilder.ApplyConfiguration(new FlightConfiguration());

            //configuration le type  detenu (firstname + lastname= (Fullname))
            modelBuilder.Entity<Passenger>().OwnsOne(p => p.FullName);


            //configurer heritage tabel per hierarchy
            /* 
              modelBuilder.Entity<Passenger>().HasDiscriminator<int>("IsTraveller")
                                             .HasValue<Passenger>(0)
                                             .HasValue<Staff>(2)
                                             .HasValue<Traveller>(1);
            */

            //configurer l heritage table per type
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");


            //configurer la cle primaire de Ticket

            modelBuilder.Entity<Ticket>().HasKey(t =>new {t.FlightFK,t.PassengerFK});

            base.OnModelCreating(modelBuilder);
        }

        //convention
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            base.ConfigureConventions(configurationBuilder);
        }



        //Regle de Mapping Fluent API
        //Conventions relatives a tout le modele 

    }
}
