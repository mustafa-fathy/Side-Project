using Application.Countries.Commands.Create;
using Application.Countries.Commands.Delete;
using Application.Countries.Commands.Edit;
using Application.Countries.Dtos;
using Application.Countries.Queries;
using GoldenAirport.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_With_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController<CountriesController>
    {
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCountryCommand command)
        {
            command.CurruntUserId = CurruntUserId;
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedCountry = new DeleteCountrycommand
            {
                Id = id
            };
            var result = await Mediator.Send(deletedCountry);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCountryDto dto)
        {
            var updatedcountry = new UpdateCountryCommand
            {
                Id = id,
                CurruntUserId = CurruntUserId,
                Dto = dto
            };
            var result = await Mediator.Send(updatedcountry);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Result);
        }
        [HttpGet("Fetch")]
        public async Task<IActionResult> GetCountries([FromQuery] int pagenumber)
        {
            var getcountries = new GetCountriesQuery { PageNumber = pagenumber };
            var result = await Mediator.Send(getcountries);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Result);
        }

    }
}
