using NServiceBus;

namespace Infrastructure
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
