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
            Salt = "e780c737-85b6-4345-9e72-1eb2c9833532",
            Roles = Roles.SystemManager,
            PasswordHash = "CpIfqxhj+TTpahN/mIXdhnuFqX+3Khkqhwv0K+TVdMo="
        });
    }
}
