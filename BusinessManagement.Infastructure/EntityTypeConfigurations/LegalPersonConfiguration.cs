using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace BusinessManagement.Infastructure.EntityTypeConfigurations;

public class LegalPersonConfiguration : IEntityTypeConfiguration<LegalPersons>
{
    public void Configure(EntityTypeBuilder<LegalPersons> builder)
    {
        builder.ToTable(nameof(LegalPersons));

        builder.HasKey(legPer => legPer.Id);

        builder
            .Property(legPer => legPer.Name)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(legPer => legPer.RegistrationDate)
            .IsRequired(true);

        builder
            .HasIndex(legPer => legPer.INN)
            .IsUnique(true);

        builder
            .Property(legPer => legPer.IndustryType)
            .HasMaxLength(100)
            .IsRequired(true);

        builder
            .Property(legPer => legPer.LegalEntityType)
            .IsRequired(true);

        builder.HasOne(legPer => legPer.Address)
            .WithOne()
            .HasForeignKey<LegalPersons>(legPer => legPer.AddressId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
