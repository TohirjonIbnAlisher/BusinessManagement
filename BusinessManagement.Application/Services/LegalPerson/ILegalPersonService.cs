using BusinessManagement.Application.DataTransferObjects;

namespace BusinessManagement.Application.Services;

public interface ILegalPersonService
{
    ValueTask<LegalPersonDTO> CreateLegalPersonAsync(LegalPersonCreationDTO legalPersonCreationDTO);
    IQueryable<LegalPersonDTO> RetrieveLegalPersons();
    ValueTask<LegalPersonDTO> RetrieveLegalPersonByIdAsync(Guid Id);
    ValueTask<LegalPersonDTO> ModifyLegalPersonAsync(ModifyLegalPersonDTO modifyLegalPersonDTO);
    ValueTask<LegalPersonDTO> RemoveLegalPersonAsync(Guid Id);
}
