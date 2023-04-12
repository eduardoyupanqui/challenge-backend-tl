using Permissions.Domain.AggregatesModel.EmployeeAggregate;
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
        public string Tittle { get; private set; }
        public string Description { get; private set; }
        public PermissionType PermissionType { get; private set; }
        private int _permissionTypeId;


        private readonly List<Employee> _employees;
        public IReadOnlyCollection<Employee> Employees => _employees;

        protected Permission()
        {
            _employees = new List<Employee>();
        }
        public Permission(string tittle, string description, PermissionType permissionType)
        {
            Tittle = tittle;
            Description = description;
            PermissionType = permissionType;
            _permissionTypeId = permissionType.Id;
        }

        public void UpdatePermission(string tittle, string description, PermissionType permissionType)
        {
            Tittle = tittle;
            Description = description;
            PermissionType = permissionType;
            _permissionTypeId = permissionType.Id;
        }
    }
}
