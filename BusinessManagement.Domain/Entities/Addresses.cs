namespace BusinessManagement.Domain.Entities;

public class Addresses
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string Region { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public int PostalCode { get; set; }
}
