using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemManagerController : ControllerBase
{
    private readonly IUsersService usersService;

    public SystemManagerController(IUsersService usersService)
    {
        this.usersService = usersService;
    }

    [HttpPost]
    public async ValueTask<ActionResult<UserDTO>> CreateSystemManagerAsync(
        UserCreationDTO userCreationDTO)
    {
        var createdUser = await this.usersService.CreateUserAsync(userCreationDTO);

        return Created("", createdUser);
    }

    [HttpPut]
    public async ValueTask<ActionResult<UserDTO>> ModifySystemManagerAsync(
        ModifyUserDTO modifyUserDTO)
    {
        var modifiedUser = await this.usersService.ModifyUserAsync(modifyUserDTO);

        return Ok(modifiedUser);
    }

    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<UserDTO>> RetrieveSystemManagerAsync(Guid id)
    {
        var selectedById = await this.usersService.RetrieveUserByIdAsync(id);

        return Ok(selectedById);
    }

    public IActionResult RetrieveAllSystemManagers()
    {
        var allUsers = this.usersService.RetrieveUsers();

        return Ok(allUsers);
    }

    public async ValueTask<ActionResult<UserDTO>> DeleteSystemManagerByIdAsync(Guid id)
    {
        var deletedUser = await this.usersService.RemoveUserAsync(id);

        return Ok(deletedUser);
    }

}
