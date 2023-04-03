using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class AddressFactory
{
    internal static Addresses MapToAddress(
        CreationAddressDTO creationAddressDTO)
    {
        return new Addresses(
            );
    }

    internal static void MapToModifyAddressDto(
        ModifyAddressDTO modifyAddressDTO,
        Addresses addresses)
    {

    }

    internal static AddressDTO MapToAddressDto(
        Addresses address)
    {
        return new AddressDTO();
    }
}
