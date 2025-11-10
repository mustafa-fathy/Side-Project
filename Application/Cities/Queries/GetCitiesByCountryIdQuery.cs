using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Application.Cities.Queries
{
    public class GetCitiesByCountryIdQuery : IRequest<ResponseDto<object>>
    {
        public int CountryId { get; set; }
        public class GetCitiesByCountryIdHandler : IRequestHandler<GetCitiesByCountryIdQuery,ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public GetCitiesByCountryIdHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(GetCitiesByCountryIdQuery request,CancellationToken cancellationToken)
            {
                var cities = await _dbContext.Cities.Where(d => d.CountryId == request.CountryId)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.NameAr : c.NameEn

                    }).ToListAsync();

                return ResponseDto<object>.Success(new ResultDto()
                {
                    Message = "Cities",
                    Result = cities

                });
                           
            }
            
        }

    }
}
