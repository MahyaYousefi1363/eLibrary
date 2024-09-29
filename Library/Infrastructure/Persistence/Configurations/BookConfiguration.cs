using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLibrary.Library.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration: IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder){
            builder.ToTable("Books","eLibrary");
            builder.HasKey(b=>b.Id);
            builder.Property(b=>b.Id).ValueGeneratedNever();
            builder.Property(b=>b.Isbn).IsRequired().HasMaxLength(10);
            builder.Property(b=>b.Name).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(b=>b.Author).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(b=>b.Place).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(b=>b.Count).IsRequired().HasPrecision(8,0);
        }
    }
}