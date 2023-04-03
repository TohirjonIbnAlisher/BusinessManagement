using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.ServiceModel;

namespace BusinessManagement.Application.Services;

public interface ILegalPersonService
{
    ValueTask<LegalPersonDTO> CreateLegalPersonAsync(LegalPersonCreationDTO legalPersonCreationDTO);
    IQueryable<LegalPersonDTO> RetrieveLegalPersons(QueryParameter queryParameter);
    ValueTask<LegalPersonDTO> RetrieveLegalPersonByIdAsync(Guid Id);
    ValueTask<LegalPersonDTO> ModifyLegalPersonAsync(ModifyLegalPersonDTO modifyLegalPersonDTO);
    ValueTask<LegalPersonDTO> RemoveLegalPersonAsync(Guid Id);
}
