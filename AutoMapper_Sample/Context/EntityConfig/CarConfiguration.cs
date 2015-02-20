using AutoMapper_Sample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Context.EntityConfig
{
    public class CarConfiguration : EntityTypeConfiguration<Car>
    {
        public CarConfiguration()
        {
            ToTable("Cars");

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            HasMany(p => p.Colors)
                .WithMany(x => x.Cars)
                .Map(mc =>
                {
                    mc.ToTable("CarsColors");
                    mc.MapLeftKey("CarId");
                    mc.MapRightKey("ColorId");
                });
        }
    }
}