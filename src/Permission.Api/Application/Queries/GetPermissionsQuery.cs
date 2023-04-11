using MediatR;
using Permissions.Api.Application.Commands;

namespace Permissions.Api.Application.Queries
{
    public class GetPermissionsQuery : IRequest<IEnumerable<PermissionDto>>
    {
        public GetPermissionsQuery()
        {

        }

        public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, IEnumerable<PermissionDto>>
        {
            private readonly ILogger<GetPermissionsQueryHandler> _logger;
            public GetPermissionsQueryHandler(ILogger<GetPermissionsQueryHandler> logger)
            {
                _logger = logger;
            }
            public Task<IEnumerable<PermissionDto>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
