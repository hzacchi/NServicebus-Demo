using System;
using Contracts.Assemble.Events;
using Contracts.Packout.Events;
using Contracts.Routing.Commands;
using Contracts.Scrap.Events;
using Contracts.Wip.Events;
using Domain;
using NServiceBus;
using NServiceBus.Saga;
using Persistence;

namespace Wip
{
    public class WipRoutingSaga : Saga<WipRoutingSagaData>,
                                  IAmStartedByMessages<WipReleased>,
                                  IHandleMessages<AssemblePassed>,
                                  IHandleMessages<AssembleFailed>,
                                  IHandleMessages<WipPacked>,
                                  IHandleMessages<WipScrapped>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<WipReleased>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<AssemblePassed>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<AssembleFailed>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<WipPacked>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<WipScrapped>(m => m.WipId).ToSaga(s => s.WipId); 
        } 

        public void Handle(WipReleased message)
        {
            Data.WipId = message.WipId;

            Console.WriteLine(message.ToString());
            Bus.Send(new MoveWipToAssemble {WipId = message.WipId});
        }

        public void Handle(AssemblePassed message)
        {
            Console.WriteLine(message.ToString());
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "";
            Repository.Save(message.WipId, wip);
            Bus.Send(new MoveWipToPackout {WipId = message.WipId});
        }

        public void Handle(AssembleFailed message)
        {
            Console.WriteLine(message.ToString());
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "";
            Repository.Save(message.WipId, wip);
            Bus.Send(new MoveWipToScrap {WipId = message.WipId});
        }

        public void Handle(WipPacked message)
        {
            Console.WriteLine(message.ToString());
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "";
            wip.IsComplete = true;
            Repository.Save(message.WipId, wip);
            MarkAsComplete();
        }

        public void Handle(WipScrapped message)
        {
            Console.WriteLine(message.ToString());
            var wip = Repository.Get<WipItem>(message.WipId);
            wip.Station = "";
            wip.IsComplete = true;
            Repository.Save(message.WipId, wip);
            MarkAsComplete();
        }
    }
}