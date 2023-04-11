using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Domain.AggregatesModel.EmployeeAggregate
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);

        void Update(Employee employee);

        Task<Employee> GetAsync(int employeeId);
    }
}
