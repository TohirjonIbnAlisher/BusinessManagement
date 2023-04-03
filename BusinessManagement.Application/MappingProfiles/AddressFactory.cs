using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class AddressFactory
{
    internal static Addresses MapToAddress(
        CreationAddressDTO creationAddressDTO)
    {
        return new Addresses()  
        {
            Id = Guid.NewGuid(),
            Country = creationAddressDTO.country,
            Region = creationAddressDTO.region,
            District = creationAddressDTO.district,
            Street = creationAddressDTO.street,
            PostalCode = creationAddressDTO.postalCode
        };
    }

    internal static void MapToAddress(
        ModifyAddressDTO modifyAddressDTO,
        Addresses address)
    {
        address.Country = modifyAddressDTO.country ?? address.Country;
        address.Region = modifyAddressDTO.region ?? address.Region;
        address.District = modifyAddressDTO.district ?? address.District;
        address.Street = modifyAddressDTO.street ?? address.Street;
        address.PostalCode = modifyAddressDTO.postalCode ?? address.PostalCode;
    }

    internal static AddressDTO MapToAddressDto(
        Addresses address)
    {
        return new AddressDTO(
            id: address.Id,
            country: address.Country,
            region: address.Region,
            district: address.District,
            street: address.Street,
            postalCode: address.PostalCode);
    }
}
