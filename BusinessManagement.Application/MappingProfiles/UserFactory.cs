using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Domain.Entities;
using BusinessManagement.Infrastructure.Authentication;

namespace BusinessManagement.Application.MappingProfiles;

internal static class UserFactory
{
    internal static Users MapToUser(
        UserCreationDTO userCreationDTO,
        IPasswordHasher passwordHasher)
    {
        string randomsalt = Guid.NewGuid().ToString();
        return new Users()
        {
            Id = Guid.NewGuid(),
            Email = userCreationDTO.email,
            Salt = randomsalt,
            Roles = userCreationDTO.role,
            PasswordHash = passwordHasher.GeneratePassword(
                userCreationDTO.password,
                randomsalt)
        };
    }
    public static void MapToUser(
        Users storageUser,
        ModifyUserDTO modifyUserDTO)
    {
        storageUser.Email = modifyUserDTO.email ?? storageUser.Email;
        storageUser.Roles = modifyUserDTO.role ?? storageUser.Roles;
    }

    internal static UserDTO MapToUserDto(Users user)
    {
        return new UserDTO(
            id : user.Id,
            email : user.Email,
            role : user.Roles);
    }
}
