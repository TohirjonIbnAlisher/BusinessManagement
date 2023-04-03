using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class LegalPersonFactory
{
    internal static LegalPersons MapToLegalPerson(
       LegalPersonCreationDTO LegalPersonCreationDTO)
    {
        return new LegalPersons();
    }
    public static void MapToLegalPerson(
        LegalPersons storageLegalPersonDTO,
        ModifyLegalPersonDTO modifyLegalPersonDTO)
    {

    }

    internal static LegalPersonDTO MapToLegalPersonDTO(LegalPersons legalPerson)
    {
        return new LegalPersonDTO();
    }
}
