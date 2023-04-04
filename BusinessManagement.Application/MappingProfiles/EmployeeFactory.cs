using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class EmployeeFactory
{
   internal static Employees MapToEmployee(
       CreationEmployeeDTO creationEmployeeDTO)
    {
        var address = AddressFactory.MapToAddress(
                creationEmployeeDTO.CreationAddressDTO);

        var randomSalt = Guid.NewGuid().ToString();

        return new Employees()
        {
            Id = Guid.NewGuid(),
            FirstName = creationEmployeeDTO.firstName,
            LastName = creationEmployeeDTO.lastName,
            Salary = creationEmployeeDTO.salary,
            JobPosition = creationEmployeeDTO.jobPosition,
            EmploymentType = creationEmployeeDTO.employmentType,
            TellNumber = creationEmployeeDTO.tellNumber,
            LegalPersonId = creationEmployeeDTO.legalPersonId,
            Address = address,
            AddressId = address.Id,

        };
    }

    internal static void MapToEmployee(
        Employees employee,
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        employee.FirstName = modifyEmployeeDTO.firstName ?? employee.FirstName;
        employee.LastName = modifyEmployeeDTO.lastName ?? employee.LastName;
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
            jobPosition: employee.JobPosition,
            employmentType: employee.EmploymentType,
            salary: employee.Salary,
            tellNumber: employee.TellNumber,
            legalPersonDTO: LegalPersonFactory.MapToLegalPersonDTO(employee.LegalPerson)?? null,
            addressDTO: AddressFactory.MapToAddressDto(employee.Address) ?? null,
            userDTO : UserFactory.MapToUserDto(employee.User));
    }
}
