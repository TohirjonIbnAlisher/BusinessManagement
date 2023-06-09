﻿using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class LegalPersonFactory
{
    internal static LegalPersons MapToLegalPerson(
       LegalPersonCreationDTO legalPersonCreationDTO)
    {
        var address = AddressFactory.MapToAddress(legalPersonCreationDTO.addressDTO);

        return new LegalPersons()
        {
            Id = Guid.NewGuid(),
            Name = legalPersonCreationDTO.name,
            INN = legalPersonCreationDTO.INN,
            IndustryType = legalPersonCreationDTO.industryType,
            Address = address,
            LegalEntityType= legalPersonCreationDTO.legalEntityType,
            RegistrationDate = DateTime.UtcNow,
            AddressId = address.Id
        };
    }
    public static void MapToLegalPerson(
        LegalPersons storageLegalPerson,
        ModifyLegalPersonDTO modifyLegalPersonDTO)
    {
        storageLegalPerson.Name = modifyLegalPersonDTO.name ?? storageLegalPerson.Name;
        storageLegalPerson.INN = modifyLegalPersonDTO.INN ?? storageLegalPerson.INN;
        storageLegalPerson.IndustryType = modifyLegalPersonDTO.industryType ?? storageLegalPerson.IndustryType;
        storageLegalPerson.LegalEntityType = modifyLegalPersonDTO.legalEntityType ?? storageLegalPerson.LegalEntityType;   
    }

    internal static LegalPersonDTO MapToLegalPersonDTO(LegalPersons legalPerson)
    {
        var empl = legalPerson.Employees != null ? legalPerson.Employees.Select(emp =>
                EmployeeFactory.MapToEmployeeDto(emp)).ToList() : null;
        var addres = legalPerson.Address != null ? AddressFactory.MapToAddressDto(legalPerson.Address) : null;

        return new LegalPersonDTO(
            id: legalPerson.Id,
            name: legalPerson.Name,
            INN: legalPerson.INN,
            industryType: legalPerson.IndustryType,
            legalEntityType: legalPerson.LegalEntityType,
            RegistrationDate: legalPerson.RegistrationDate,
            addressDTO: addres,
            employees:  empl
        ) ;
    }
}
