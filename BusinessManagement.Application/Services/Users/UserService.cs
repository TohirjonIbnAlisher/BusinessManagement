using BusinessManagement.Application.DataTransferObjects;

namespace BusinessManagement.Application.Services;

public class UserService : IUsersService
{
    public ValueTask<UserDTO> CreateUserAsync(UserCreationDTO userCreationDTO)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDTO> ModifyUserAsync(ModifyUserDTO modifyUserDTO)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDTO> RemoveUserAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public ValueTask<UserDTO> RetrieveUserByIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserDTO> RetrieveUsers()
    {
        throw new NotImplementedException();
    }
}
