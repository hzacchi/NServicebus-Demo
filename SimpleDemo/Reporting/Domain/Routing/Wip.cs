using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Domain.Routing
{
    public class Wip
    {
        public Guid Id { get; set; }
        public IList<WipProcessStepHistory> History { get; set; }

        public int CurrentRouteStepId { get; set; }
    }
}
