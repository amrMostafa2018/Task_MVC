﻿using Task.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task.Infrastructure.Data.Configurations
{
    public class PersonalInformationConfiguration : IEntityTypeConfiguration<PersonalInformation>
    {
        public void Configure(EntityTypeBuilder<PersonalInformation> builder)
        {
            builder.Property(t => t.FullName).IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.CityName)
                   .HasMaxLength(200);

            builder.Property(t => t.Email)
                   .HasMaxLength(200);

            builder.Property(t => t.MobileNumber).IsRequired()
                   .HasMaxLength(200);
        }
    }
}
