using MediatR;

namespace Permissions.Api.Application.Commands
{
    public class RequestPermissionCommand : IRequest<bool>
    {
        public RequestPermissionCommand()
        {

        }

        public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, bool>
        {
            private readonly ILogger<RequestPermissionCommandHandler> _logger;
            public RequestPermissionCommandHandler(ILogger<RequestPermissionCommandHandler> logger)
            {
                _logger = logger;
            }
            public Task<bool> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
