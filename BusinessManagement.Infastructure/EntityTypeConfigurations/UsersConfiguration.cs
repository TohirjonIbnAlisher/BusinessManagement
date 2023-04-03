using BusinessManagement.Domain.Entities;
using BusinessManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infastructure.EntityTypeConfigurations;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.ToTable(nameof(Users));

        builder.HasKey(user => user.Id);

        builder
            .HasIndex(user => user.Email)
            .IsUnique();

        builder
            .Property(user => user.PasswordHash)
            .IsRequired();

        builder
            .Property(user => user.Roles)
            .IsRequired();

        builder.HasData(new Users()
        {
            Id = Guid.NewGuid(),
            Email = "tohirjon@gmail.com",
            Salt = "a9feaa2d-8692-4d2e-bf64-3d8200ad8c8b",
            Roles = Roles.SystemManager,
            PasswordHash = ""

        });
    }
}
