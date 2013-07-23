using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using Messages.Router;
using NServiceBus;

namespace Reporting
{
    class Handler :
        IHandleMessages<EnqueueWipAtRouteStep>
    {
        public void Handle(EnqueueWipAtRouteStep message)
        { 
        }

    }
}
