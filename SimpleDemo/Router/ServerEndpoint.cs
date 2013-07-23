using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using Messages.Orders;
using Messages.Router;
using NServiceBus;

namespace Router
{
    public class ServerEndpoint : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press any key to send a new message");
             
            while (Console.ReadLine() != null)
            {
                //var eventMessage = new WipEnqueuedAtRouteStep();
                //Bus.Publish(eventMessage);

                //Console.WriteLine("Published WipEnqueuedAtRouteStep event with Id {0}.", eventMessage.Id);
                //Console.WriteLine("==========================================================================");


                var cmd = new WipReleased {WipId = Guid.NewGuid()};
                Bus.Publish(cmd);

                Console.WriteLine("Published WipEnqueuedAtRouteStep cmd with Id {0}.", cmd.WipId);
                Console.WriteLine("==========================================================================");
            }
        }

        public void Stop()
        { 
        }
    }  
}
