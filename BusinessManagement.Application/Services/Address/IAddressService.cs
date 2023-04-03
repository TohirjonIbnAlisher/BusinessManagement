using BusinessManagement.Application.DataTransferObjects.Address;

namespace BusinessManagement.Application.Services.Address;

public interface IAddressService
{
    ValueTask<AddressDTO> CreateAddressAsync(CreationAddressDTO creationAddressDTO);
    ValueTask<AddressDTO> UpdateAddressAsync(ModifyAddressDTO modifyAddressDTO);
    IQueryable<AddressDTO> RetrieveAllAddresses();
    ValueTask<AddressDTO> RetrieveAdressByIdAsync(Guid id);
    ValueTask<AddressDTO> DeleteAddressAsync(Guid id);

}
