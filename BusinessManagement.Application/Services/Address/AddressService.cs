using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Infastructure.Repository;

namespace BusinessManagement.Application.Services.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        this.addressRepository = addressRepository;
    }

    public async ValueTask<AddressDTO> CreateAddressAsync(
        CreationAddressDTO creationAddressDTO)
    {
        var mappedAddress = AddressFactory.MapToAddress(creationAddressDTO);

        var createdAddress = await this.addressRepository
            .InsertAsync(mappedAddress);

        return AddressFactory.MapToAddressDto(createdAddress);
    }

    public ValueTask<AddressDTO> DeleteAddressAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressDTO> RetrieveAdressByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<AddressDTO> RetrieveAllAddresses()
    {
        throw new NotImplementedException();
    }

    public ValueTask<AddressDTO> UpdateAddressAsync(ModifyAddressDTO modifyAddressDTO)
    {
        throw new NotImplementedException();
    }
}
