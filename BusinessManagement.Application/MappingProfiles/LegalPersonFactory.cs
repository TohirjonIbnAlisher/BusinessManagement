using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.DataTransferObjects.Address;
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
        return new LegalPersonDTO()
        {
            Id = legalPerson.Id,
            name = legalPerson.Name,
            INN = legalPerson.INN,
            industryType = legalPerson.IndustryType,
            legalEntityType = legalPerson.LegalEntityType,
            RegistrationDate = legalPerson.RegistrationDate,
            addressDTO = AddressFactory.MapToAddressDto(legalPerson.Address),
            employees = legalPerson.Employees.Select(emp => Employye emp)
        };
    }
}
