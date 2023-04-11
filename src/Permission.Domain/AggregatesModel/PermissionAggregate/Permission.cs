using Permissions.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Domain.AggregatesModel.PermissionAggregate
{
    public class Permission : Entity
    {
        public int Id { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public PermissionType PermissionType { get; private set; }
        private int _permissionTypeId;

        public Permission(int permissionId, string tittle, string description, int permissionType)
        {
            Id = permissionId;
            Tittle = tittle;
            Description = description;
            _permissionTypeId = permissionType;
            PermissionType = Enumeration.FromValue<PermissionType>(permissionType);
        }
    }
}
