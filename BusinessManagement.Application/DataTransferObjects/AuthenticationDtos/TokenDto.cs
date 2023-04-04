namespace BusinessManagement.Application.EntitiesDto.AuthenticationDtos;

public record TokenDto(
    string accessToken,
    string? refreshToken,
    DateTime expireDate);
