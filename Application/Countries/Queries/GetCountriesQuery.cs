using Application.Common;
using Application.Common.Dtos;
using Application.Countries.Dtos;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Countries.Queries
{
    public class GetCountriesQuery : IRequest<ResponseDto<object>>
    {
        public int PageNumber { get; set; } = 1;
        public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public GetCountriesHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
            {
                //1-pages number&size
                var pageNumber = request.PageNumber <= 0 ? 1 : request.PageNumber;
                var pageSize = 10;
                //2-getting a query ready to be Executed 
                var query = _dbContext.Countries.AsQueryable();
                //3-total Count&pages
                var totalCount = await query.CountAsync(cancellationToken);
                var totalPages = (totalCount + pageSize - 1) / pageSize;
                //4-getting countries from query
                var countries = await query.Select(
                   c => new GetCountriesDto
                   {
                       Id = c.Id,
                       Code = c.Code,
                       Icon = c.Icon,
                       NameAr = c.NameAr,
                       NameEn = c.NameEn
                   }).ToListAsync(cancellationToken);
                //5-assign countries to paginated list
                var paginatedList = new PaginatedList<GetCountriesDto>
                {
                    Items = countries,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = totalCount,
                    TotalPages = totalCount
                };
                //6-return a response
                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "All Countries",
                    Result = new
                    {
                        paginatedList
                    }
                });

            }
        }
    }
}
