using BusinessManagement.Application.DataTransferObjects.Employee;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Application.Services.Employee;
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

    [HttpPost]
    public async ValueTask<ActionResult<EmployeeDTO>> CreateEmployeeAsync(
        CreationEmployeeDTO creationEmployeeDTO)
    {
        var createdEmployee = await this.employeeService
            .CreateEmployeeAsync(creationEmployeeDTO);

        return Created("", createdEmployee);
    }

    [HttpPut]
    public async ValueTask<ActionResult<EmployeeDTO>> ModifyEmployeeAsync(
        ModifyEmployeeDTO modifyEmployeeDTO)
    {
        var modifiedEmployee = await this.employeeService
            .UpdateEmployeeAsync(modifyEmployeeDTO);

        return Ok(modifiedEmployee);
    }

    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<EmployeeDTO>> RetrieveEmployeeAsync(Guid id)
    {
        var selectedById = await this.employeeService
            .RetrieveEmployeeByIdAsync(id);

            return Ok(selectedById);
        }
        [HttpGet]
        public IActionResult RetrieveAllEmployees(
            [FromQuery] QueryParameter queryParameter)
        {
            var allEmployee = this.employeeService
                .RetrieveAllEmployeees(queryParameter);

            return Ok(allEmployee);
        }
        [HttpDelete("id : Guid")]
        public async ValueTask<ActionResult<EmployeeDTO>> DeleteEmployeeByIdAsync(Guid id)
        {
            var deletedEmployee = await this.employeeService
                .DeleteEmployeeAsync(id);

        return Ok(deletedEmployee);
    }
}
