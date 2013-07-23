using System;
using System.Collections.Generic;
using System.IO;
using Messages;
using Messages.Router;
using NServiceBus;
using Newtonsoft.Json;

namespace Assemble
{
    class Handler :
        IHandleMessages<WipEnqueuedAtRouteStep>,
        IHandleMessages<WipDequeuedAtRouteStep>
    {
        public void Handle(WipEnqueuedAtRouteStep message)
        {
            var state = File.Exists(State.FilePath)
                            ? JsonConvert.DeserializeObject<State>(File.ReadAllText(State.FilePath))
                            : new State();

            if (!state.InQueue.ContainsKey(message.RouteStepId))
            {
                state.InQueue.Add(message.RouteStepId, new List<Guid>());
            }
            state.InQueue[message.RouteStepId].Add(message.WipId);

            var json = JsonConvert.SerializeObject(state);
            File.WriteAllText(State.FilePath, json);

            Console.WriteLine("1: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(WipDequeuedAtRouteStep message)
        {
            var state = File.Exists(State.FilePath)
                            ? JsonConvert.DeserializeObject<State>(File.ReadAllText(State.FilePath))
                            : new State();

            if (!state.InQueue.ContainsKey(message.RouteStepId))
            {
                state.InQueue.Add(message.RouteStepId, new List<Guid>());
            }

            for (var i = 0; i < state.InQueue[message.RouteStepId].Count; i++)
            {
                if (state.InQueue[message.RouteStepId][i] == message.WipId)
                {
                    state.InQueue[message.RouteStepId].RemoveAt(i);
                    break;
                } 
            }

            var json = JsonConvert.SerializeObject(state);
            File.WriteAllText(State.FilePath, json);

            Console.WriteLine("1: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }
    }
}
