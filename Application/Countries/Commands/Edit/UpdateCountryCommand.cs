using Application.Common.Dtos;
using Application.Countries.Dtos;
using Application.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Countries.Commands.Edit
{
    public class UpdateCountryCommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public UpdateCountryDto Dto { get; set; }
        public string? CurruntUserId { get; set; }
        public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand, ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public UpdateCountryHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
            {
                var country = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("Not Found");

                if (request.Dto.NameAr != null)
                    country.NameAr = request.Dto.NameAr;

                if (request.Dto.NameEn != null)
                    country.NameEn = request.Dto.NameEn;

                if (request.Dto.Icon != null)
                    country.Icon = request.Dto.Icon;

                if (request.Dto.Code != null)
                    country.Code = (byte)request.Dto.Code;

                if (request.Dto.Icon != null)
                    country.Icon = request.Dto.Icon;

                country.ModifiedById = request.CurruntUserId;

                country.ModificationDate = DateTime.UtcNow;

                await _dbContext.SaveChangesAsync(cancellationToken);

                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Updated Successfully",
                    Result = new
                    {
                        CountryId = country.Id
                    }
                });


            }
        }
    }
}
