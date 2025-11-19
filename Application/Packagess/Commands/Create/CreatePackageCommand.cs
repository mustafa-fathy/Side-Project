using Application.Common.Dtos;
using Application.Interfaces;
using MediatR;

namespace Application.Packagess.Commands.Create
{
    public class CreatePackageCommand : IRequest<ResponseDto<object>>
    {
        public class CreatePackageHandler : IRequestHandler<CreatePackageCommand , ResponseDto<object>>
        {
            private readonly IAppDbContext _dbContext;
            public CreatePackageHandler(IAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<ResponseDto<object>> Handle (CreatePackageCommand request , CancellationToken cancellationToken)
            {

            }
        }
    }
}
