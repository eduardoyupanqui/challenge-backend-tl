using MediatR;
using Permissions.Domain.AggregatesModel.EmployeeAggregate;
using Permissions.Domain.AggregatesModel.PermissionAggregate;
using Permissions.Domain.SeedWork;

namespace Permissions.Api.Application.Commands
{
    public class RequestPermissionCommand : IRequest<bool>
    {
        public int EmployeeId { get; private set; }
        public int PermissionId { get; private set; }
        public string Tittle { get; private set; }
        public string Description { get; private set; }
        public int PermissionType { get; set; }
        public RequestPermissionCommand(int employeeId, int permissionId, string tittle, string description, int permissionType)
        {
            EmployeeId = employeeId;
            PermissionId = permissionId;
            Tittle = tittle;
            Description = description;
            PermissionType = permissionType;
        }

        public class RequestPermissionCommandHandler : IRequestHandler<RequestPermissionCommand, bool>
        {
            private readonly ILogger<RequestPermissionCommandHandler> _logger;
            private readonly IEmployeeRepository _employeeRepository;
            
            public RequestPermissionCommandHandler(ILogger<RequestPermissionCommandHandler> logger, IEmployeeRepository employeeRepository)
            {
                _logger = logger;
                _employeeRepository = employeeRepository;
            }
            public async Task<bool> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetAsync(request.EmployeeId);

                if (employee is not null)
                {
                    employee.AddPermission(request.PermissionId, request.Tittle, request.Description, Enumeration.FromValue<PermissionType>(request.PermissionType));
                    _employeeRepository.Update(employee);
                }
                else
                {
                    throw new NotImplementedException();
                }

                return await _employeeRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            }
        }
    }
}
