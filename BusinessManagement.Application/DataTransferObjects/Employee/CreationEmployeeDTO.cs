using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects.Employee;

public record CreationEmployeeDTO(
    string firstName,
    string? lastName,
    string email,
    string password,
    Roles role,
    string jobPosition,
    EmploymentType employmentType,
    decimal salary,
    string tellNumber,
    Guid legalPersonId,
    CreationAddressDTO CreationAddressDTO);
