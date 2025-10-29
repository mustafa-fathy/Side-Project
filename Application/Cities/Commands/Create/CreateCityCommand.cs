using Application.Common.Dtos;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cities.Commands.Create
{
    public class CreateCityCommand :IRequest<ResponseDto>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int CountryId { get; set; }
        public string? CurruntUserId { get; set; }
        public class CreateCityHandler:IRequestHandler<CreateCityCommand,ResponseDto>
        {
            private readonly IAppDbContext _dbContext;
            public CreateCityHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto> Handle(CreateCityCommand request,CancellationToken cancellationToken)
            {
                var city = new City
                {
                    NameAr=request.NameAr,
                    NameEn=request.NameEn,
                    CountryId=request.CountryId,
                    CreatedById=request.CurruntUserId,
                    CreationDate = DateTime.Now
                };
                _dbContext.Cities.Add(city);
                await _dbContext.SaveChangesAsync();
                return ResponseDto.Success(new ResultDto
                {

                });

            }
        }
    }
}
