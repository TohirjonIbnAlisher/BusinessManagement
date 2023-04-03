using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;

public record ModifyLegalPersonDTO(
    Guid id,
    string? name,
    long? INN,
    string? industryType,
    LegalEntityType? legalEntityType,
    ModifyAddressDTO? modifyAddressDTO
    );
