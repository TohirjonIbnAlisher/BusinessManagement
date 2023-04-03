using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects.Employee;

public record ModifyEmployeeDTO(
    Guid id,
    string? firstName,
    string? lastName,
    string? email,
    Roles? role,
    string? jobPosition,
    EmploymentType? employmentType,
    decimal? salary,
    string? tellNumber,
    Guid? legalPersonId,
    ModifyAddressDTO? addressDTO);
