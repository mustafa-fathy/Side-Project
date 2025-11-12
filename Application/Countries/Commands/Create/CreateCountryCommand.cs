using Application.Common.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Countries.Commands.Create
{
    public class CreateCountryCommand : IRequest<ResponseDto<object>>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string? CurruntUserId { get; set; }
        public byte Code { get; set; }
        public string Icon { get; set; }


        public class CreateCountryHandler : IRequestHandler<CreateCountryCommand, ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public CreateCountryHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
            {
                if (await _dbContext.Countries.AnyAsync(c => c.Code == request.Code, cancellationToken))
                    return ResponseDto<object>.Failure(new ErrorDto
                    {
                        Message = "Already Exists",
                        Code = request.Code
                    });

                var country = new Country
                {
                    NameAr = request.NameAr,
                    NameEn = request.NameEn,
                    CreatedById = request.CurruntUserId,
                    CreationDate = DateTime.Now,
                    Code = request.Code,
                    Icon = request.Icon
                };

                _dbContext.Countries.Add(country);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Country Created",
                    Result = new { CountryId = country.Id }
                });
            }
        }
    }
}
