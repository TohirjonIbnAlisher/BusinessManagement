using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;

public record LegalPersonDTO(
    Guid id,
    DateTime RegistrationDate,
    string name,
    long INN,
    string industryType,
    LegalEntityType legalEntityType,
    AddressDTO addressDTO, 
    ICollection<EmployeeDTO> employees);
