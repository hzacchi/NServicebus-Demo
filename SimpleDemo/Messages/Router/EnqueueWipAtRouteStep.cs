using System;
using NServiceBus;

namespace Messages.Router
{
    public class EnqueueWipAtRouteStep : ICommand
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; }

        public EnqueueWipAtRouteStep()
        {
            WipId = Guid.NewGuid();
        }
    }
}