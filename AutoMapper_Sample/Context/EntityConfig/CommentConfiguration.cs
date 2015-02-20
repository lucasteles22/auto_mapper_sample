using AutoMapper_Sample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AutoMapper_Sample.Context.EntityConfig
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            ToTable("Comments");

            Property(x => x.Body)
                .IsRequired()
                .IsMaxLength();

            HasRequired(p => p.News)
                .WithMany(c => c.Comments)
                .HasForeignKey(p => p.NewsId)
                .WillCascadeOnDelete(true);
        }
    }
}