﻿using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //configuration de la relation ManyToMany *--*
            builder.HasMany(f => f.Passengers).WithMany(p => p.Flights).UsingEntity(t => t.ToTable("Reservations"));
            
            builder.HasOne(f => f.Plane)
           .WithMany(p => p.Flights)
           .HasForeignKey(f => f.PlaneFK)
           .OnDelete(DeleteBehavior.Cascade)
           .IsRequired();


        }
    }
}
