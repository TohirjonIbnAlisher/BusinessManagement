using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Domain.Entities;

public class Users
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? ExpiredRefreshToken { get; set; }
    public Roles Roles { get; set; }
}
