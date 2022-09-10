using Core.Application.Requests;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Dtos;
using KodlamaIO.Application.Features.ProgrammingLanguages.Models;
using KodlamaIO.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using KodlamaIO.Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIO.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Accepted("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(
            [FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Accepted("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery languageQuery)
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(languageQuery);
            return Ok(programmingLanguageGetByIdDto);
        }
    }
}
