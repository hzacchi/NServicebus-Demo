using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.Domain.Routing
{
    public class WipProcessStepHistory
    {
        public Guid Id { get; set; }
        public Wip Wip { get; set; }

        public string Audit { get; set; }
    }
}
