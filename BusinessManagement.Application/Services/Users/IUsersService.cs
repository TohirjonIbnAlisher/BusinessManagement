using BusinessManagement.Application.DataTransferObjects;

namespace BusinessManagement.Application.Services;

public interface IUsersService
{
    ValueTask<UserDTO> CreateUserAsync(UserCreationDTO userCreationDTO);
    IQueryable<UserDTO> RetrieveUsers();
    ValueTask<UserDTO> RetrieveUserByIdAsync(Guid userId);
    ValueTask<UserDTO> ModifyUserAsync(ModifyUserDTO modifyUserDTO);
    ValueTask<UserDTO> RemoveUserAsync(Guid userId);
}
