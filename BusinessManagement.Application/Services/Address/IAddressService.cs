using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.ServiceModel;
using Microsoft.AspNetCore.Http;

namespace BusinessManagement.Application.Services.Address;

public interface IAddressService
{
    ValueTask<AddressDTO> CreateAddressAsync(CreationAddressDTO creationAddressDTO);
    ValueTask<AddressDTO> UpdateAddressAsync(ModifyAddressDTO modifyAddressDTO);
    IQueryable<AddressDTO> RetrieveAllAddresses(QueryParameter queryParameter);
    ValueTask<AddressDTO> RetrieveAdressByIdAsync(Guid id);
    ValueTask<AddressDTO> DeleteAddressAsync(Guid id);

}
