using AutoMapper_Sample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Context.EntityConfig
{
    public class ColorConfiguration : EntityTypeConfiguration<Color>
    {
        public ColorConfiguration()
        {
            ToTable("Colors");

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}