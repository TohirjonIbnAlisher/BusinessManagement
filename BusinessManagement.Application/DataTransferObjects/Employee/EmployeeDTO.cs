using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects.Employee;

public record EmployeeDTO(
    Guid id,
    string firstName,
    string? lastName,
    string jobPosition,
    EmploymentType employmentType,
    decimal salary,
    string tellNumber,
    LegalPersonDTO? legalPersonDTO,
    AddressDTO? addressDTO,
    UserDTO? userDTO);
