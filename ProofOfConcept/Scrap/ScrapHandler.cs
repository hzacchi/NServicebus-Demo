using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Routing.Commands;
using Contracts.Routing.Events;
using Contracts.Scrap;
using Contracts.Scrap.Commands;
using Contracts.Scrap.Events;
using Contracts.Wip;
using Domain;
using NServiceBus;
using Persistence;

namespace Scrap
{
    public class ScrapHandler :
        IHandleMessages<ScrapWip>,
        IHandleMessages<MoveWipToScrap> ,
        IHandleMessages<WipMovedToScrap>
    {
        public IBus Bus { get; set; }

        public void Handle(ScrapWip message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new WipScrapped {WipId = message.WipId});
        }

        public void Handle(MoveWipToScrap message)
        {
            Console.WriteLine(message.ToString());
            Bus.Publish(new WipMovedToScrap { WipId = message.WipId });
        }

        public void Handle(WipMovedToScrap message)
        {
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "Scrap";
            Repository.Save(message.WipId, wip);
        }
    }
}