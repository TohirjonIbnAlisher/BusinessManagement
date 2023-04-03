using BusinessManagement.Application.DataTransferObjects;
using BusinessManagement.Application.ServiceModel;
using BusinessManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LegalPersonController : ControllerBase
{
    private readonly ILegalPersonService legalPersonService;

    public LegalPersonController(
        ILegalPersonService legalPersonService)
    {
        this.legalPersonService = legalPersonService;
    }


    [HttpPost]
    public async ValueTask<ActionResult<LegalPersonDTO>> CreateLegalPersonAsync(
        LegalPersonCreationDTO legalPersonCreationDTO)
    {
        var createdLegalPerson = await this.legalPersonService
            .CreateLegalPersonAsync(legalPersonCreationDTO);

        return Created("", createdLegalPerson);
    }

    [HttpPut]
    public async ValueTask<ActionResult<LegalPersonDTO>> ModifyLegalPersonAsync(
        ModifyLegalPersonDTO modifyLegalPersonDTO)
    {
        var modifiedLegalPerson = await this.legalPersonService
            .ModifyLegalPersonAsync(modifyLegalPersonDTO);

        return Ok(modifiedLegalPerson);
    }

    [HttpGet("id : Guid")]
    public async ValueTask<ActionResult<LegalPersonDTO>> RetrieveLegalPersonAsync(Guid id)
    {
        var selectedById = await this.legalPersonService.RetrieveLegalPersonByIdAsync(id);

        return Ok(selectedById);
    }
    [HttpGet]
    public IActionResult RetrieveAllLegalPersons(
        [FromQuery] QueryParameter queryParameter)
    {
        var allLegalPersons = this.legalPersonService
            .RetrieveLegalPersons(queryParameter);

        return Ok(allLegalPersons);
    }
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<LegalPersonDTO>> DeleteLegalPersonByIdAsync(Guid id)
    {
        var deletedLegalPerson = await this.legalPersonService.RemoveLegalPersonAsync(id);

        return Ok(deletedLegalPerson);
    }

}
