namespace BusinessManagement.Application.DataTransferObjects.Address;

public record CreationAddressDTO(
    string country,
    string region,
    string district,
    string street,
    int postalCode);
