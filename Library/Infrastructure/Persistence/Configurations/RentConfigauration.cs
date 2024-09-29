using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLibrary.Library.Infrastructure.Persistence.Configurations
{
    public class RentConfigauration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents","eLibrary");
            builder.HasKey(r=>r.Id);
            builder.Property(r=>r.Id).ValueGeneratedNever();
            builder.Property(r=>r.MemberNationalCode).IsRequired().HasMaxLength(10);
            builder.Property(r=>r.BookIsbn).IsRequired().HasMaxLength(10);
            builder.Property(r=>r.RentDate).IsRequired();
            builder.Property(r=>r.ReturnDate).ValueGeneratedNever();
            builder.Property(r=>r.IsReturned).HasDefaultValue(false);
        }
    }
}