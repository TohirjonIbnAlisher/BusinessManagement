using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;

public record UserCreationDTO(
    string email,
    string password);
