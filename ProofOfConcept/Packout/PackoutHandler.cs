using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Packout;
using Contracts.Packout.Commands;
using Contracts.Packout.Events;
using Contracts.Routing.Commands;
using Contracts.Routing.Events;
using Contracts.Wip;
using Domain;
using NServiceBus;
using Persistence;

namespace Packout
{
    public class PackoutHandler :
        IHandleMessages<PackWip>,
        IHandleMessages<MoveWipToPackout>,
        IHandleMessages<WipMovedToPackout>
    {
        public IBus Bus { get; set; }

        public void Handle(PackWip message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new WipPacked { WipId = message.WipId });
        }

        public void Handle(MoveWipToPackout message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new WipMovedToPackout { WipId = message.WipId });
        }

        public void Handle(WipMovedToPackout message)
        {
            var wip = Repository.Get(message.WipId);
            wip.Station = "Packout";
            Repository.Save(message.WipId, wip);
        }
    }
}
