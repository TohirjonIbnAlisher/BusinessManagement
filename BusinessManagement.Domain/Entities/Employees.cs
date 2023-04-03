﻿using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Domain.Entities;

public class Employees : Users
{
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string JobPosition { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public decimal Salary { get; set; }
    public string TellNumber { get; set; }
    public Guid LegalPersonId { get; set; }
    public LegalPersons LegalPerson { get; set; }
    public Guid AddressId { get; set; }
    public Addresses Address { get; set; }
}
