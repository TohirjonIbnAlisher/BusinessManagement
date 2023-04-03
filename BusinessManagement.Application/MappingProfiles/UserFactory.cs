using BusinessManagement.Application.DataTransferObjects.Address;
using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Domain.Entities;

namespace BusinessManagement.Application.MappingProfiles;

internal static class UserFactory
{
    internal static Users MapToUser(
        UserCreationDTO userCreationDTO)
    {
        return new Users();
    }
    public static void MapToUser(
        Users storageUser,
        ModifyUserDTO modifyUserDTO)
    {
        
    }

    internal static UserDTO MapToUserDto(Users user)
    {
        return new UserDTO();
    }
}
