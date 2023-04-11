using Microsoft.EntityFrameworkCore;
using Permissions.Domain.AggregatesModel.EmployeeAggregate;
using Permissions.Domain.AggregatesModel.PermissionAggregate;
using Permissions.Domain.SeedWork;

namespace Permissions.Infrastructure
{
    public class PermissionDbContext : DbContext, IUnitOfWork
    {
        public PermissionDbContext(DbContextOptions<PermissionDbContext> options) : base(options)
        { }

        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Permission> Permissions => Set<Permission>();

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
