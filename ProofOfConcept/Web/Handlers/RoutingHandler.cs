using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contracts.Assemble.Events;
using Contracts.Routing.Events;
using Contracts.Wip.Events;
using Microsoft.AspNet.SignalR;
using NServiceBus;

namespace Web.Handlers
{
    public class RoutingHandler :
        IHandleMessages<WipReleased>,
        IHandleMessages<AssemblePassed>,
        IHandleMessages<AssembleFailed>,
        IHandleMessages<WipMovedToAssemble>,
        IHandleMessages<WipMovedToPackout>,
        IHandleMessages<WipMovedToScrap>
    {
        public void Handle(WipReleased message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.wipReleased(new
            {
                message.WipId
            });
        }

        public void Handle(AssemblePassed message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.assemblePassed(new
            {
                message.WipId
            });
        }

        public void Handle(AssembleFailed message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.assembleFailed(new
            {
                message.WipId
            });
        }

        public void Handle(WipMovedToAssemble message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.wipMovedToAssemble(new
                {
                    message.WipId
                });
        }

        public void Handle(WipMovedToPackout message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.wipMovedToPackout(new
                {
                    message.WipId
                });
        }

        public void Handle(WipMovedToScrap message)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RoutingHub>();

            context.Clients.All.wipMovedToScrap(new
                {
                    message.WipId
                });
        }
    }
}