using MediatR;
using MediatR.Wrappers;
using Permissions.Domain.AggregatesModel.PermissionAggregate;
using Permissions.Domain.SeedWork;

namespace Permissions.Api.Application.Commands
{
    public class ModifyPermissionCommand : IRequest<bool>
    {
        public int PermissionId { get; private set; }
        public string Tittle { get; private set; }
        public string Description { get; private set; }
        public int PermissionType { get; set; }
        public ModifyPermissionCommand(int permissionId, string tittle, string description)
        {
            PermissionId = permissionId;
            Tittle = tittle;
            Description = description;
        }

        public class ModifyPermissionCommandHandler : IRequestHandler<ModifyPermissionCommand, bool>
        {
            private readonly ILogger<ModifyPermissionCommandHandler> _logger;
            private readonly IPermissionRepository _permissionRepository;
            public ModifyPermissionCommandHandler(ILogger<ModifyPermissionCommandHandler> logger, IPermissionRepository permissionRepository)
            {
                _logger = logger;
                _permissionRepository = permissionRepository;
            }

            public async Task<bool> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
            {
                var permission = await _permissionRepository.GetAsync(request.PermissionId);

                if (permission == null)
                {
                    _permissionRepository.Add(new Permission(request.Tittle, request.Description, Enumeration.FromValue<PermissionType>(request.PermissionType)));
                }
                else
                {
                    permission.UpdatePermission(request.Tittle, request.Description, Enumeration.FromValue<PermissionType>(request.PermissionType));
                    _permissionRepository.Update(permission);
                }
                return await _permissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
