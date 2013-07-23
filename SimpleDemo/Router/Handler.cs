using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Router;
using NServiceBus;

namespace Router
{
    internal class Handler :
        IHandleMessages<EnqueueWipAtRouteStep>,
        IHandleMessages<DequeueWipAtRouteStep>
    {
        public IBus Bus { get; set; }

        public void Handle(EnqueueWipAtRouteStep message)
        {
            //BUSINESS RULES

            Bus.Publish(new WipEnqueuedAtRouteStep { WipId = message.WipId, RouteStepId = message.RouteStepId });
            Console.WriteLine("3: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(DequeueWipAtRouteStep message)
        {
            //BUSINESS RULES

            Bus.Publish(new WipDequeuedAtRouteStep { WipId = message.WipId, RouteStepId = message.RouteStepId });
            Console.WriteLine("3: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }
    }
}