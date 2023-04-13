using MediatR;
using Permissions.Domain.AggregatesModel.EmployeeAggregate;
using Permissions.Domain.AggregatesModel.PermissionAggregate;
using Permissions.Domain.SeedWork;
using Permissions.Infrastructure.Repositories;

namespace Permissions.Api.Application.Commands
{
    public class RequestPermissionCommand : IRequest<bool>
    {
        public int EmployeeId { get; private set; }
        public DateTime DatePermission { get; private set; }
        public string Comment { get; private set; }
        public int PermissionType { get; set; }
        public RequestPermissionCommand(int employeeId, DateTime datePermission, string comment, int permissionType)
        {
            EmployeeId = employeeId;
            DatePermission = datePermission;
            Comment = comment;
            PermissionType = permissionType;
        }

        public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, bool>
        {
            private readonly ILogger<RequestPermissionCommandHandler> _logger;
            private readonly IEmployeeRepository _employeeRepository;
            private readonly IPermissionRepository _permissionRepository;
            public RequestPermissionCommandHandler(ILogger<RequestPermissionCommandHandler> logger, IEmployeeRepository employeeRepository, IPermissionRepository permissionRepository)
            {
                _logger = logger;
                _employeeRepository = employeeRepository;
                _permissionRepository = permissionRepository;
            }
            public async Task<bool> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetAsync(request.EmployeeId);

                var newPermission = new Permission(request.DatePermission, request.Comment, employee, Enumeration.FromValue<PermissionType>(request.PermissionType));
                _permissionRepository.Add(newPermission);

                return await _permissionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
