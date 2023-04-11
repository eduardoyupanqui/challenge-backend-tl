using Permissions.Domain.AggregatesModel.PermissionAggregate;
using Permissions.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Domain.AggregatesModel.EmployeeAggregate
{
    public class Employee : Entity
    {
        public string Nombres { get; set; }
        private readonly List<Permission> _permissions;
        public IReadOnlyCollection<Permission> Permissions => _permissions;
        protected Employee() 
        {
            _permissions = new List<Permission>();
        }

        public void AddPermission(int permissionId, string tittle, string description, int permissionType)
        {
            var existingPermission = _permissions.Where(o => o.Id == permissionId)
                .SingleOrDefault();

            if (existingPermission != null)
            {

            }
            else
            {
                var permission = new Permission(permissionId, tittle, description, permissionType);
                _permissions.Add(permission);
            }
        }
    }
}
