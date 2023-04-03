using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Infastructure.Repository;

namespace BusinessManagement.Application.Services;

public class UserService : IUsersService
{
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async ValueTask<UserDTO> CreateUserAsync(UserCreationDTO userCreationDTO)
    {
        var newUser = UserFactory.MapToUser(userCreationDTO);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return UserFactory.MapToUserDto(addedUser);
    }

    public async ValueTask<UserDTO> ModifyUserAsync(ModifyUserDTO modifyUserDTO)
    {
        var storageUser = await this.userRepository
            .SelectByIdAsync(modifyUserDTO.userId);

        UserFactory.MapToUser(storageUser,modifyUserDTO);

        var modifiedUser = await this.userRepository
            .UpdateAsync(storageUser);

        return UserFactory.MapToUserDto(modifiedUser);
    }

    public async ValueTask<UserDTO> RemoveUserAsync(Guid userId)
    {
        var storageUser = await this.userRepository
           .SelectByIdAsync(userId);

        var removedUser = await this.userRepository
            .DeleteAsync(storageUser);

        return UserFactory.MapToUserDto(removedUser);
    }

    public async ValueTask<UserDTO> RetrieveUserByIdAsync(Guid userId)
    {
        var storageUser = await this.userRepository
            .SelectByIdAsync(userId);

        return UserFactory.MapToUserDto(storageUser);
    }

    public IQueryable<UserDTO> RetrieveUsers()
    {
        var users = this.userRepository
            .SelectAll();

        return users.Select(user => UserFactory.MapToUserDto(user));
    }
}
