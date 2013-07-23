using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Router
{
    class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, AsA_Server
    { 
    }
}
