using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurrentUserId { get; set; }

        public class DeleteCityHandler : IRequestHandler<DeleteCityCommand, ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;

            public DeleteCityHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _dbContext.Cities.FindAsync(request.Id) ?? throw new NotFoundException("City Not Found!");
                city.Deleted = true;
                city.ModifiedById = request.CurrentUserId;
                city.ModificationDate = DateTime.Now;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto
                {

                    Message = "Deleted Success",
                    Result = new
                    {
                        CityId = city.Id
                    }

                });

            }
        }
    }
}