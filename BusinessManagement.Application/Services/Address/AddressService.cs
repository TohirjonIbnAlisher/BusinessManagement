using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.Repository;
using Microsoft.AspNetCore.Http;

namespace BusinessManagement.Application.Services.Address;

public class AddressService : IAddressService
{
    private readonly IAddressRepository addressRepository;
    private readonly IHttpContextAccessor httpContextAccesssor;

    public AddressService(IAddressRepository addressRepository,
        IHttpContextAccessor httpContextAccesssor = null)
    {
        this.addressRepository = addressRepository;
        this.httpContextAccesssor = httpContextAccesssor;
    }

    public async ValueTask<AddressDTO> CreateAddressAsync(
        CreationAddressDTO creationAddressDTO)
    {
        var mappedAddress = AddressFactory.MapToAddress(creationAddressDTO);

        var createdAddress = await this.addressRepository
            .InsertAsync(mappedAddress);

        await this.addressRepository.SaveChangesAsync();

        return AddressFactory.MapToAddressDto(createdAddress);
    }

    public async ValueTask<AddressDTO> UpdateAddressAsync(
        ModifyAddressDTO modifyAddressDTO)
    {
        var selectedByIdAddress = await this.GetAddressByIdAsync(modifyAddressDTO.id);

        AddressFactory.MapToAddress(
            modifyAddressDTO: modifyAddressDTO,
            address : selectedByIdAddress);

        var updatedAddress = await this.addressRepository
            .UpdateAsync(selectedByIdAddress);

        await this.addressRepository.SaveChangesAsync();

        return AddressFactory.MapToAddressDto(updatedAddress);

    }
    public async ValueTask<AddressDTO> DeleteAddressAsync(Guid id)
    {
        var selectedByIdAddress = await this.GetAddressByIdAsync(id);

        var deletedAddress = await this.addressRepository.DeleteAsync(selectedByIdAddress);

        await this.addressRepository.SaveChangesAsync();

        return AddressFactory.MapToAddressDto(deletedAddress);

    }

    public async ValueTask<AddressDTO> RetrieveAdressByIdAsync(Guid id)
    {
        var selectedByIdAddress = await this.GetAddressByIdAsync(id);

        return AddressFactory.MapToAddressDto(selectedByIdAddress);
    }

    public IQueryable<AddressDTO> RetrieveAllAddresses(
        QueryParameter queryParameter)
    {
        var addresses = this.addressRepository.SelectAll();

        var paginatedAddresses = addresses.PagedList(
            httpContext: httpContextAccesssor.HttpContext,
            queryParameter: queryParameter);

        return paginatedAddresses.Select(address => 
            AddressFactory.MapToAddressDto(address));
    }


    private async ValueTask<Addresses> GetAddressByIdAsync(Guid id)
    {
        var selectedAddress = await this.addressRepository.SelectByIdAsync(id);

        return selectedAddress;
    }
}
