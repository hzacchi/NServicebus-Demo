using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Assemble;
using Contracts.Assemble.Commands;
using Contracts.Assemble.Events;
using Contracts.Routing.Commands;
using Contracts.Routing.Events;
using Contracts.Wip;
using Domain;
using NServiceBus;
using NServiceBus.Saga;
using Persistence;

namespace Assemble
{ 

    public class AssembleHandler :
        IHandleMessages<StartAssemble>, 
        IHandleMessages<PassAssemble>,
        IHandleMessages<FailAssemble>,
        IHandleMessages<MoveWipToAssemble>,
        IHandleMessages<WipMovedToAssemble>
    {
        public IBus Bus { get; set; }

        public void Handle(PassAssemble message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new AssemblePassed {WipId = message.WipId});
        }

        public void Handle(FailAssemble message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new AssembleFailed {WipId = message.WipId});
        }

        public void Handle(MoveWipToAssemble message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new WipMovedToAssemble {WipId = message.WipId});
        }

        public void Handle(WipMovedToAssemble message)
        {
            Console.WriteLine(message.ToString());
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "Assemble";
            Repository.Save(message.WipId, wip);
        }

        public void Handle(StartAssemble message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new AssembleStarted { WipId = message.WipId });
        }
    }
}