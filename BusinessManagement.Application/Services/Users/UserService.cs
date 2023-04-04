using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.MappingProfiles;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Infastructure.Repository;
using BusinessManagement.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;

namespace BusinessManagement.Application.Services;

public class UserService : IUsersService
{
    private readonly IUserRepository userRepository;
    private readonly IHttpContextAccessor httpContextAccesssor;
    private readonly IPasswordHasher passwordHasher;

    public UserService(IUserRepository userRepository,
        IHttpContextAccessor httpContextAccesssor,
        IPasswordHasher passwordHasher)
    {
        this.userRepository = userRepository;
        this.httpContextAccesssor = httpContextAccesssor;
        this.passwordHasher = passwordHasher;
    }

    public async ValueTask<UserDTO> CreateUserAsync(UserCreationDTO userCreationDTO)
    {
        var newUser = UserFactory.MapToUser(userCreationDTO,
            passwordHasher);

        var addedUser = await this.userRepository
            .InsertAsync(newUser);

        return UserFactory.MapToUserDto(addedUser);
    }

    public async ValueTask<UserDTO> ModifyUserAsync(ModifyUserDTO modifyUserDTO)
    {
        var storageUser = await this.userRepository
            .SelectByIdAsync(modifyUserDTO.id);

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

    public IQueryable<UserDTO> RetrieveUsers(
        QueryParameter queryParameter)
    {
        var users = this.userRepository
        .SelectAll();

        var paginatedUsers = users.PagedList(
            httpContext: httpContextAccesssor.HttpContext,
            queryParameter: queryParameter);

        return paginatedUsers.Select(user => UserFactory.MapToUserDto(user));
    }
}
