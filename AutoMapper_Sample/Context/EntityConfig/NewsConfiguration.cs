using AutoMapper_Sample.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Context.EntityConfig
{
    public class NewsConfiguration : EntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        {
            ToTable("News");

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(120);

            Property(x => x.Body)
                .IsRequired()
                .HasMaxLength(null);
        }
    }
}