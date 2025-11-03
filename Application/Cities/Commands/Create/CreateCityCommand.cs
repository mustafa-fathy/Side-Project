using Application.Common.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Cities.Commands.Create
{
    public class CreateCityCommand :IRequest<ResponseDto<object>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int CountryId { get; set; }
        public string? CurruntUserId { get; set; }
        public class CreateCityHandler:IRequestHandler<CreateCityCommand,ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public CreateCityHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(CreateCityCommand request,CancellationToken cancellationToken)
            {
                //1-Taking Values From Request With New Variable Of The Same Type
                var city = new City
                {
                    NameAr=request.NameAr,
                    NameEn=request.NameEn,
                    CountryId=request.CountryId,
                    CreatedById=request.CurruntUserId,
                    CreationDate = DateTime.Now
                };

                //2-Adding Result To The Tracker and in DbContext
                _dbContext.Cities.Add(city);
                //3-Saving Chang into Database
                await _dbContext.SaveChangesAsync();
                //4-Returning Response
                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Created Successfuly ",
                    Result = new
                    {
                        CityId = city.Id
                    }

                });

            }
        }
    }
}
