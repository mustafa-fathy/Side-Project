using Application.Cities.Commands.Create;
using Application.Cities.Commands.Delete;
using Application.Cities.Commands.Edit;
using Application.Cities.Dtos;
using Application.Cities.Queries;
using GoldenAirport.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_With_CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CitiesController : BaseController<CitiesController>
    {
       
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand command)
        {
            command.CurruntUserId = CurruntUserId;
            var result = await Mediator.Send(command);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteCity = new 
                DeleteCityCommand { Id = id };
            var result = await Mediator.Send(deleteCity);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id,[FromBody]UpdateCityDto dto )
        {
            var editCity = new UpdateCityCommand
            {
                Id = id,
                CountryId = dto.CountryId,
                CurrentUserId = CurruntUserId,
                NameAr = dto.NameAr,
                NameEn = dto.NameEn
            };
            var result = await Mediator.Send(editCity);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> GetCities([FromQuery] int pageNumber)
        {
            var getcities = new GetCitiesQuery { PageNumber = pageNumber };
            var result = await Mediator.Send(getcities);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

        [HttpGet("fetch1")]
        public async Task<IActionResult> GetCitiesById([FromQuery] int countryId)
        {
            var getcities = new GetCitiesByCountryIdQuery { CountryId = countryId };
            var result = await Mediator.Send(getcities);
            return result.IsSuccess ? Ok(result.Result) : BadRequest(result.Error);
        }

    }
}
