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


    public LegalPersonService(ILegalPersonRepository legalPersonRepository,
        IHttpContextAccessor httpContextAccesssor)
    {
        _legalPersonRepository = legalPersonRepository;
        this.httpContextAccesssor = httpContextAccesssor;
    }

    public async ValueTask<LegalPersonDTO> CreateLegalPersonAsync(
        LegalPersonCreationDTO legalPersonCreationDTO)
    {
        var newLegalPerson = LegalPersonFactory.MapToLegalPerson(legalPersonCreationDTO);

        var addedLegalPerson = await this._legalPersonRepository
            .InsertAsync(newLegalPerson);

        return LegalPersonFactory.MapToLegalPersonDTO(addedLegalPerson);
    }

    public async ValueTask<LegalPersonDTO> ModifyLegalPersonAsync(
        ModifyLegalPersonDTO modifyLegalPersonDTO)
    {
        var storageLegalPerson = await this._legalPersonRepository
            .SelectByIdAsync(modifyLegalPersonDTO.id);

        LegalPersonFactory.MapToLegalPerson(storageLegalPerson, modifyLegalPersonDTO);

        var modifiedLegalPerson = await this._legalPersonRepository
            .UpdateAsync(storageLegalPerson);

        return LegalPersonFactory.MapToLegalPersonDTO(modifiedLegalPerson);
    }

    public async ValueTask<LegalPersonDTO> RemoveLegalPersonAsync(Guid Id)
    {
        var storageLegalPerson = await this._legalPersonRepository
           .SelectByIdAsync(Id);

        var removedLegalPerson = await this._legalPersonRepository
            .DeleteAsync(storageLegalPerson);

        return LegalPersonFactory.MapToLegalPersonDTO(removedLegalPerson);
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
}
