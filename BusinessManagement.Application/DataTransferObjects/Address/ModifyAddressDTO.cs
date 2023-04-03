namespace BusinessManagement.Application.DataTransferObjects.Address;

public record ModifyAddressDTO(
    Guid id,
    string? country,
    string? region,
    string? district,
    string? street,
    int? postalCode);
