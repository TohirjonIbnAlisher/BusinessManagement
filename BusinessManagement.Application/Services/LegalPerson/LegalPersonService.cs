using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.Repository;
using Microsoft.AspNetCore.Http;

namespace BusinessManagement.Application.Services;

public class LegalPersonService : ILegalPersonService
{
    private readonly ILegalPersonRepository _legalPersonRepository;
    private readonly IHttpContextAccessor httpContextAccesssor;
    private readonly IAddressRepository addressRepository;


    public LegalPersonService(ILegalPersonRepository legalPersonRepository,
        IHttpContextAccessor httpContextAccesssor,
        IAddressRepository addressRepository)
    {
        _legalPersonRepository = legalPersonRepository;
        this.httpContextAccesssor = httpContextAccesssor;
        this.addressRepository = addressRepository;
    }

    public async ValueTask<LegalPersonDTO> CreateLegalPersonAsync(
        LegalPersonCreationDTO legalPersonCreationDTO)
    {
        var mappedAddress = AddressFactory.MapToAddress(legalPersonCreationDTO.addressDTO);

        var createdAddress = await this.addressRepository.InsertAsync(mappedAddress);

        var newLegalPerson = LegalPersonFactory.MapToLegalPerson(legalPersonCreationDTO);

        var addedLegalPerson = await this._legalPersonRepository
            .InsertAsync(newLegalPerson);

        await this._legalPersonRepository.SaveChangesAsync();

        return LegalPersonFactory.MapToLegalPersonDTO(addedLegalPerson);
    }

    public async ValueTask<LegalPersonDTO> ModifyLegalPersonAsync(
        ModifyLegalPersonDTO modifyLegalPersonDTO)
    {
        var selected = await this.addressRepository
            .SelectByIdAsync(modifyLegalPersonDTO.modifyAddressDTO.id);

        AddressFactory.MapToAddress(modifyLegalPersonDTO.modifyAddressDTO,
            selected);
        var updated = await this.addressRepository.UpdateAsync(selected);

        var storageLegalPerson = await this._legalPersonRepository
            .SelectByIdAsync(modifyLegalPersonDTO.id);

        LegalPersonFactory.MapToLegalPerson(storageLegalPerson, modifyLegalPersonDTO);

        var modifiedLegalPerson = await this._legalPersonRepository
            .UpdateAsync(storageLegalPerson);

        await this._legalPersonRepository.SaveChangesAsync();

        return LegalPersonFactory.MapToLegalPersonDTO(modifiedLegalPerson);
    }


    public async ValueTask<LegalPersonDTO> RetrieveLegalPersonByIdAsync(Guid Id)
    {
        var storageLegalPerson = await this._legalPersonRepository
            .SelectByIdWithDetailsAsync(
            legPer => legPer.Id == Id,
            new string[] {"Address", "Employees"});

        return LegalPersonFactory.MapToLegalPersonDTO(storageLegalPerson);
    }

    public IQueryable<LegalPersonDTO> RetrieveLegalPersons(
        QueryParameter queryParameter)
    {
        var storageLegalPersons = this._legalPersonRepository
           .SelectAll();

        var paginatedAPersons = storageLegalPersons.PagedList(
            httpContext: httpContextAccesssor.HttpContext,
            queryParameter: queryParameter);

        return paginatedAPersons.Select(storageLegalPerson => LegalPersonFactory
            .MapToLegalPersonDTO(storageLegalPerson));
    }
    public async ValueTask<LegalPersonDTO> RemoveLegalPersonAsync(Guid Id)
    {
        var storageLegalPerson = await this.GetLegalPersonByExpressionAsync(Id);

        var removedLegalPerson = await this._legalPersonRepository
            .DeleteAsync(storageLegalPerson);

        await this.addressRepository.DeleteAsync(storageLegalPerson.Address);

        await this._legalPersonRepository.SaveChangesAsync();

        return LegalPersonFactory.MapToLegalPersonDTO(removedLegalPerson);
    }
    private async ValueTask<LegalPersons> GetLegalPersonByExpressionAsync(Guid id)
    {
        var retrievedEmployee = await this._legalPersonRepository
            .SelectByIdWithDetailsAsync(legPer => legPer.Id == id,
            new string[] { "Address" });

        return retrievedEmployee;
    }
}
