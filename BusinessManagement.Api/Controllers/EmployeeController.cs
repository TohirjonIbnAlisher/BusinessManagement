using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Application.Services.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [Authorize(Roles = "SystemManager, BusinessManager")]
    [HttpPost]
    public async ValueTask<ActionResult<EmployeeDTO>> CreateEmployeeAsync(
        CreationEmployeeDTO creationEmployeeDTO)
    {
        var createdEmployee = await this.employeeService
            .CreateEmployeeAsync(creationEmployeeDTO);

        return Created("", createdEmployee);
    }

    [Authorize(Roles = "SystemManager, BusinessManager")]
    [HttpPut]
    public async ValueTask<ActionResult<EmployeeDTO>> ModifyEmployeeAsync(
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        var modifiedEmployee = await this.employeeService
            .UpdateEmployeeAsync(modifyEmployeeDTO);

        return Ok(modifiedEmployee);
    }

    [Authorize(Roles = "SystemManager, BusinessManager")]
    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<EmployeeDTO>> RetrieveEmployeeAsync(Guid id)
    {
        var selectedById = await this.employeeService
            .RetrieveEmployeeByIdAsync(id);

            return Ok(selectedById);
    }

    [Authorize(Roles = "SystemManager, BusinessManager")]
    [HttpGet]
    public IActionResult RetrieveAllEmployees(
        [FromQuery] QueryParameter queryParameter)
    {
        var allEmployee = this.employeeService
            .RetrieveAllEmployeees(queryParameter);

        return Ok(allEmployee);
    }

    [Authorize(Roles = "SystemManager, BusinessManager")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<EmployeeDTO>> DeleteEmployeeByIdAsync(Guid id)
    {
        var deletedEmployee = await this.employeeService
            .DeleteEmployeeAsync(id);

    return Ok(deletedEmployee);
    }
}
