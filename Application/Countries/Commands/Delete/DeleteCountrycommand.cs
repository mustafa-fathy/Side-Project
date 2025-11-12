using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;
using SendGrid.Helpers.Errors.Model;

namespace Application.Countries.Commands.Delete
{
    public class DeleteCountrycommand : IRequest<ResponseDto<object>>
    {
        public int Id { get; set; }
        public string? CurruntUserId { get; set; }
        public class DeleteCountryHandler : IRequestHandler<DeleteCountrycommand, ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public DeleteCountryHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle(DeleteCountrycommand request, CancellationToken cancellationToken)
            {
                var country = await _dbContext.Countries.FindAsync(request.Id) ?? throw new NotFoundException("country not Found !!");
                country.Deleted = true;
                country.ModificationDate = DateTime.Now;
                country.ModifiedById = request.CurruntUserId;
                await _dbContext.SaveChangesAsync(cancellationToken);
                return ResponseDto<object>.Success(new ResultDto
                {
                    Message = "Deleted Successful ",
                    Result = new
                    {
                        CountryId = country.Id
                    }
                });


            }
        }
    }
}
