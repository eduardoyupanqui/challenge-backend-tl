using Permissions.Domain.AggregatesModel.PermissionAggregate;

namespace Permissions.Api.Application.Queries
{
    public class PermissionDto
    {
        public int PermissionId { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
