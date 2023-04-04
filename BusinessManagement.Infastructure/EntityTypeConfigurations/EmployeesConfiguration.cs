using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infastructure.EntityTypeConfigurations;

public class EmployeesConfiguration : IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.ToTable(nameof(Employees));

        builder.HasKey(employee => employee.Id);

        builder
            .Property(employee => employee.FirstName)
            .HasMaxLength(50)
            .IsRequired(true);

        builder
            .Property(employee => employee.LastName)
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(employee => employee.Salary)
            .IsRequired(true);

        builder.Property (employee => employee.JobPosition)
            .HasMaxLength(50)
            .IsRequired(true);

        builder.Property(employee => employee.EmploymentType)
            .IsRequired(true);

        builder.Property(employee => employee.TellNumber)
            .HasMaxLength(20)
            .IsRequired(true);

        builder.HasOne(employee => employee.LegalPerson)
            .WithMany(legalPerson => legalPerson.Employees)
            .HasForeignKey(employee => employee.LegalPersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(employee => employee.Address)
            .WithOne()
            .HasForeignKey<Employees>(employee => employee.AddressId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(employee => employee.User)
            .WithOne()
            .HasForeignKey<Employees>(employee => employee.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
