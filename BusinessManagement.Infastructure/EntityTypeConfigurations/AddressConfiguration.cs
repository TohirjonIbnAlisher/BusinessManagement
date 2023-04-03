using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace BusinessManagement.Infastructure.EntityTypeConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Addresses>
{
    public void Configure(EntityTypeBuilder<Addresses> builder)
    {
        builder.ToTable(nameof(Addresses));

        builder.HasKey(add => add.Id);

        builder
            .Property(add => add.Country)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(add => add.Region)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(add => add.District)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(add => add.Street)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(add => add.PostalCode)
            .IsRequired(true);

    }
}
