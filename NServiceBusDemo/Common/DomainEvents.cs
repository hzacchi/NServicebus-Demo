using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace Common
{
    public class DomainEvents
    {
        public static IBus Bus { get; set; }

        public static void Publish<T>(T @event)
        {
            Bus.Publish(@event);
        }
    }
}
