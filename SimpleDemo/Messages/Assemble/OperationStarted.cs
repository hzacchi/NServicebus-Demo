using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages.Assemble
{
    public class OperationStarted
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; }
    }
}
