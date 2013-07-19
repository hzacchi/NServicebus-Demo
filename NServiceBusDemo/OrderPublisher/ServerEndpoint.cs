using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.V1.Ordering;
using NServiceBus;

namespace OrderPublisher
{
    public class ServerEndpoint : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("This will publish IEvent, EventMessage, and AnotherEventMessage alternately.");
            Console.WriteLine("Press 'Enter' to publish a message.To exit, Ctrl + C");

            int nextEventToPublish = 0;
            while (Console.ReadLine() != null)
            {
                OrderCreated eventMessage = new OrderCreated(); 

                eventMessage.EventId = Guid.NewGuid(); 

                Bus.Publish(eventMessage);

                Console.WriteLine("Published event with Id {0}.", eventMessage.EventId);
                Console.WriteLine("==========================================================================");
            }
        }

        public void Stop()
        {

        }
    }
}
