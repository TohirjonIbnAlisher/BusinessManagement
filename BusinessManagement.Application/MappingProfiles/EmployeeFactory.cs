using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class EmployeeFactory
{
   internal static Employees MapToEmployee(
       CreationEmployeeDTO creationEmployeeDTO)
    {
        var randomSalt = Guid.NewGuid().ToString();
        return new Employees()
        {
            Id = Guid.NewGuid(),
            FirstName = creationEmployeeDTO.firstName,
            LastName = creationEmployeeDTO.lastName,
            Email = creationEmployeeDTO.email,
            PasswordHash = creationEmployeeDTO.password,
            Roles = creationEmployeeDTO.role,
            Salt = randomSalt,
            Salary = creationEmployeeDTO.salary,
            JobPosition = creationEmployeeDTO.jobPosition,
            EmploymentType = creationEmployeeDTO.employmentType,
            TellNumber = creationEmployeeDTO.tellNumber,
            LegalPersonId = creationEmployeeDTO.legalPersonId,
            Address = AddressFactory.MapToAddress(
                creationEmployeeDTO.CreationAddressDTO)

        };
    }

    internal static void MapToEmployee(
        Employees employee,
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        employee.FirstName = 
    }

    internal static EmployeeDTO MapToEmployeeDto(
        Employees employee)
    {
        return new EmployeeDTO();
    }
}
