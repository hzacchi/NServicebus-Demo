using System;
using NServiceBus;

namespace Messages.Router
{
    public class DequeueWipAtRouteStep : ICommand
    {
        public Guid WipId { get; set; }
        public int RouteStepId { get; set; } 
    }
}