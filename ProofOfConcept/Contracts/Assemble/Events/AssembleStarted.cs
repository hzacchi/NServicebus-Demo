using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Contracts.Assemble.Events
{
    public class AssembleStarted : IEvent
    {
        public Guid WipId { get; set; }

        public override string ToString()
        {
            return string.Format("Assemble started for {0}", WipId);
        }
    }
}
