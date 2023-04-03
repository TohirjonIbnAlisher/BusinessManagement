using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;

public record UserDTO(
    Guid id,
    string email,
    Roles role);
