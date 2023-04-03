using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infastructure.Repository;

namespace BusinessManagement.Application.Services;

public class LegalPersonService : ILegalPersonService
{
    private readonly ILegalPersonRepository _legalPersonRepository;

    public LegalPersonService(ILegalPersonRepository legalPersonRepository)
    {
        _legalPersonRepository = legalPersonRepository;
    }

    public async ValueTask<LegalPersonDTO> CreateLegalPersonAsync(LegalPersonCreationDTO legalPersonCreationDTO)
    {
        var newLegalPerson = LegalPersonFactory.MapToLegalPerson(legalPersonCreationDTO);

        var addedLegalPerson = await this._legalPersonRepository
            .InsertAsync(newLegalPerson);

        return LegalPersonFactory.MapToLegalPersonDTO(addedLegalPerson);
    }

    public async ValueTask<LegalPersonDTO> ModifyLegalPersonAsync(ModifyLegalPersonDTO modifyLegalPersonDTO)
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
            .SelectByIdAsync(Id);

        return LegalPersonFactory.MapToLegalPersonDTO(storageLegalPerson);
    }

    public IQueryable<LegalPersonDTO> RetrieveLegalPersons()
    {
        var storageLegalPersons = this._legalPersonRepository
           .SelectAll();

        return storageLegalPersons.Select(storageLegalPerson => LegalPersonFactory
            .MapToLegalPersonDTO(storageLegalPerson));
    }
}
