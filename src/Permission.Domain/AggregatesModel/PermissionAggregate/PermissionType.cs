using Permissions.Domain.Exceptions;
using Permissions.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permissions.Domain.AggregatesModel.PermissionAggregate
{
    public class PermissionType : Enumeration
    {
        public static PermissionType GlobalAccess = new PermissionType(1, nameof(GlobalAccess).ToLowerInvariant());
        public static PermissionType SelfAccess = new PermissionType(2, nameof(SelfAccess).ToLowerInvariant());
        public PermissionType(int id, string name)
        : base(id, name)
        {
        }

        public static IEnumerable<PermissionType> List() => new[] { GlobalAccess, SelfAccess };
        public static PermissionType FromName(string name)
        {
            var state = List()
                .SingleOrDefault(s => String.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (state == null)
            {
                throw new PermissionDomainException($"Possible values for PermissionType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }

        public static PermissionType From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);

            if (state == null)
            {
                throw new PermissionDomainException($"Possible values for PermissionType: {String.Join(",", List().Select(s => s.Name))}");
            }

            return state;
        }
    }
}
