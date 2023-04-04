using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class EmployeeFactory
{
   internal static Employees MapToEmployee(
       CreationEmployeeDTO creationEmployeeDTO,
       Employees employee)
    {

        employee.Id = Guid.NewGuid();
        employee.FirstName = creationEmployeeDTO.firstName;
        employee.LastName = creationEmployeeDTO.lastName;
        employee.Salary = creationEmployeeDTO.salary;
        employee.JobPosition = creationEmployeeDTO.jobPosition;
        employee.EmploymentType = creationEmployeeDTO.employmentType;
        employee.TellNumber = creationEmployeeDTO.tellNumber;
        employee.LegalPersonId = creationEmployeeDTO.legalPersonId;
        
        return employee;
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
        employee.UserId = modifyEmployeeDTO.UserId?? employee.UserId;
    }

    internal static EmployeeDTO MapToEmployeeDto(
        Employees employee)
    {
        var user = employee.User != null ? UserFactory.MapToUserDto(employee.User) : null;
        var addres = employee.Address != null ? AddressFactory.MapToAddressDto(employee.Address) : null;
        return new EmployeeDTO(
            id: employee.Id,
            firstName: employee.FirstName,
            lastName: employee.LastName,
            jobPosition: employee.JobPosition,
            employmentType: employee.EmploymentType,
            salary: employee.Salary,
            tellNumber: employee.TellNumber,
            legalPersonId: employee.LegalPersonId,
            addressDTO: addres,
            userDTO : user);
    }
}
