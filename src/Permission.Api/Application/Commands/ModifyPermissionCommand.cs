using MediatR;

namespace Permissions.Api.Application.Commands
{
    public class ModifyPermissionCommand : IRequest<bool>
    {
        public ModifyPermissionCommand()
        {

        }

        public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand, bool>
        {
            private readonly ILogger<ModifyPermissionCommandHandler> _logger;

            public ModifyPermissionCommandHandler(ILogger<ModifyPermissionCommandHandler> logger)
            {
                _logger = logger;
            }

            public Task<bool> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
