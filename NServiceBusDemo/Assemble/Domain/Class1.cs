using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Identities;

namespace Assemble.Domain
{
    public class RouteStepAssemblePolicy
    {
        public RouteStepId RouteStepId { get; set; }

        public IList<MaterialId> AssociatedRouteMaterials { get; set; }
 
        public RouteStepAssemblePolicy()
        {
            AssociatedRouteMaterials = new List<MaterialId>();
        }
    }
}
