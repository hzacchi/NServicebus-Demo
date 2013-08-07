using System;
using System.Diagnostics;
using Contracts.Assemble;
using Contracts.Packout;
using Contracts.Scrap;
using Contracts.Wip;
using Contracts.Wip.Commands;
using Contracts.Wip.Events;
using Domain;
using NServiceBus;
using Persistence;

namespace Wip
{
    public class WipHandler : 
        IHandleMessages<ReleaseWip>,
        IHandleMessages<WipReleased>
    {
        public IBus Bus { get; set; }

        public void Handle(ReleaseWip message)
        {
            Console.WriteLine(message.ToString());
            //Business logic

            Bus.Publish(new WipReleased {WipId = message.WipId});
        }

        public void Handle(WipReleased message)
        {
            Console.WriteLine(message.ToString());
            Repository.Save(message.WipId, new WipItem {Id = message.WipId});
        }
    }
}