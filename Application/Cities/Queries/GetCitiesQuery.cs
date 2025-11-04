using Application.Cities.Dtos;
using Application.Common;
using Application.Common.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Application.Cities.Queries
{
    public class GetCitiesQuery :IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;

        public class GetCitiesHandler:IRequestHandler<GetCitiesQuery,ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public GetCitiesHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(GetCitiesQuery request, CancellationToken cancellationToken)
            {
                var pagenumber = request.PageNumber >= 0 ? 1 : request.PageNumber;
                var pageSize = 10;


                var query = _dbContext.Cities.AsQueryable();
                var totalCount = await query.CountAsync(cancellationToken);
                var totalPages = (totalCount + pageSize - 1) / pageSize;
                var cities = await query.Select(
                    c => new GetCitiesDto
                    {
                        Id = c.Id,
                        NameAr = c.NameAr,
                        NameEn = c.NameEn,
                        Country = new CountryDto
                        {
                            Id = c.CountryId,
                            Name = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "ar" ? c.Country.NameAr : c.Country.NameEn,
                        }
                    }).ToListAsync(cancellationToken);
                var paginatedlist = new PaginatedList<GetCitiesDto>
                {
                    Items = cities,
                    TotalPages = totalPages,
                    TotalCount = totalCount,
                    PageSize = pageSize,
                    PageNumber = pagenumber
                };
                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "All Cities",
                    Result =new
                    {
                        paginatedlist
                    }
                });


            }

        }
    }
}
