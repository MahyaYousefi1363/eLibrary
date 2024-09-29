using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eLibrary.Library.Infrastructure.Persistence.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Members","eLibrary");
            builder.HasKey(m=>m.Id);
            builder.Property(m=>m.Id).ValueGeneratedNever();
            builder.Property(m=>m.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(m=>m.FullName).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(m=>m.MobileNumber).IsRequired().HasMaxLength(11);
            builder.Property(m=>m.Address).IsRequired().IsUnicode().HasMaxLength(200);

        }
    }
}