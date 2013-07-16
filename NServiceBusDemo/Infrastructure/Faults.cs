using NServiceBus;

namespace Infrastructure
{
    public class Faults
    {
        public static IBus Bus { get; set; }

        public static void Raise<T>(T fault)
        {
            Bus.Reply(fault);
        } 
    }
}