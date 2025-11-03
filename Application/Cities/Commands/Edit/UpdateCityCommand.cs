using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Cities.Commands.Edit
{
    public class UpdateCityCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int? CountryId { get; set; }
        public string? CurrentUserId { get; set; }
        public class UpdateCityHandler : IRequestHandler<UpdateCityCommand, ResponseDto<object>>
        {

            private readonly IAppDbContext _dbContext;
            public UpdateCityHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
            {
                var city = await _dbContext.Cities.FindAsync(request.Id) ?? throw new NotFoundException("City Not Found.");

                city.NameEn = request.NameEn ?? city.NameEn;

                city.NameAr = request.NameAr ?? city.NameAr;

                city.CountryId = request.CountryId ?? city.CountryId;

                city.ModifiedById = request.CurrentUserId;

                city.ModificationDate = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Updates Approved.",
                    Result = new
                    {
                        CityId = city.Id
                    }

                });





            }
        }
    }
}
