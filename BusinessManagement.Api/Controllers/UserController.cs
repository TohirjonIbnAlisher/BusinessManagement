using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUsersService usersService;

    public UserController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [Authorize(Roles = "SystemManager")]
    [HttpPost]
    public async ValueTask<ActionResult<UserDTO>> CreateUserAsync(
        UserCreationDTO userCreationDTO)
    {
        var createdUser = await this.usersService.CreateUserAsync(userCreationDTO);

        return Created("", createdUser);
    }

    [Authorize(Roles = "SystemManager")]
    [HttpPut]
    public async ValueTask<ActionResult<UserDTO>> ModifyUserAsync(
        ModifyUserDTO modifyUserDTO)
    {
        var modifiedUser = await this.usersService.ModifyUserAsync(modifyUserDTO);

        return Ok(modifiedUser);
    }

    [Authorize(Roles = "SystemManager")]
    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<UserDTO>> RetrieveUserAsync(Guid id)
    {
        var selectedById = await this.usersService.RetrieveUserByIdAsync(id);

        return Ok(selectedById);
    }

    [Authorize(Roles = "SystemManager")]
    [HttpGet]
    public IActionResult RetrieveAllUsers(
        [FromQuery] QueryParameter queryParameter)
    {
        var allUsers = this.usersService
            .RetrieveUsers(queryParameter);

        return Ok(allUsers);
    }

    [Authorize(Roles = "SystemManager")]
    [HttpDelete]
    public async ValueTask<ActionResult<UserDTO>> DeleteUserByIdAsync(Guid id)
    {
        var deletedUser = await this.usersService.RemoveUserAsync(id);

        return Ok(deletedUser);
    }

}
