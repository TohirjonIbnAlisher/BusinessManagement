using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.ServiceModel;

namespace BusinessManagement.Application.Services;

public interface IUsersService
{
    ValueTask<UserDTO> CreateUserAsync(UserCreationDTO userCreationDTO);
    IQueryable<UserDTO> RetrieveUsers(QueryParameter queryParameter);
    ValueTask<UserDTO> RetrieveUserByIdAsync(Guid userId);
    ValueTask<UserDTO> ModifyUserAsync(ModifyUserDTO modifyUserDTO);
    ValueTask<UserDTO> RemoveUserAsync(Guid userId);
}
