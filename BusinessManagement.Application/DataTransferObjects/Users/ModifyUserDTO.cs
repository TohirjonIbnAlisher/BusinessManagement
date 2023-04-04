using BusinessManagement.Domain.Enums;

namespace BusinessManagement.Application.DataTransferObjects;

public record ModifyUserDTO(
    Guid id,
    string? email);
