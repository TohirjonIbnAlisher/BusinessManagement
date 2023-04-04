using System.ComponentModel.DataAnnotations;

namespace BusinessManagement.Application.EntitiesDto.AuthenticationDtos;

public record LoginDto(
    [Required(ErrorMessage =$"{ nameof(LoginDto.email)}  berilishi majburiy")]
    string email,

    [Required(ErrorMessage =$"{ nameof(LoginDto.password)}  berilishi majburiy")]
    string password);
