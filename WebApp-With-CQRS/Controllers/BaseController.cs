using Application.Interfaces;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GoldenAirport.WebAPI.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        



        private IMediator _mediator;
        private IAppDbContext _ctx;
        protected IAppDbContext _context => _ctx ?? (_ctx = HttpContext.RequestServices.GetService<IAppDbContext>());
        protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected string CurruntUserId => User.Claims.FirstOrDefault(c => c.Type == "uid")?.Value;
        protected string CurruntUserName => User.FindFirstValue(ClaimTypes.NameIdentifier);
        



    }
}
