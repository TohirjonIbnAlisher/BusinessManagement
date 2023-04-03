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
        employee.FirstName = modifyEmployeeDTO.firstName ?? employee.FirstName;
        employee.LastName = modifyEmployeeDTO.lastName ?? employee.LastName;
        employee.Email = modifyEmployeeDTO.email ?? employee.Email;
        employee.Roles = modifyEmployeeDTO.role?? employee.Roles;
        employee.TellNumber = modifyEmployeeDTO.tellNumber ?? employee.TellNumber;
        employee.Salary = modifyEmployeeDTO.salary ?? employee.Salary;
        employee.EmploymentType = modifyEmployeeDTO.employmentType ?? employee.EmploymentType;
        employee.JobPosition = modifyEmployeeDTO.jobPosition ?? employee.JobPosition;
        employee.LegalPersonId = modifyEmployeeDTO.legalPersonId ?? employee.LegalPersonId;
        AddressFactory.MapToAddress(modifyEmployeeDTO.addressDTO, employee.Address);
    }

    internal static EmployeeDTO MapToEmployeeDto(
        Employees employee)
    {
        return new EmployeeDTO(
            id: employee.Id,
            firstName: employee.FirstName,
            lastName: employee.LastName,
            email: employee.Email,
            role: employee.Roles,
            jobPosition: employee.JobPosition,
            employmentType: employee.EmploymentType,
            salary: employee.Salary,
            tellNumber: employee.TellNumber,
            legalPersonDTO: LegalPersonFactory.MapToLegalPersonDTO(employee.LegalPerson),
            addressDTO: AddressFactory.MapToAddressDto(employee.Address));
    }
}
