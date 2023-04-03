using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;
public record LegalPersonCreationDTO(
    string name,
    long INN,
    string industryType,
    LegalEntityType legalEntityType,
    CreationAddressDTO addressDTO
    );
