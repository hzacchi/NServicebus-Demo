using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages;
using NServiceBus;
using Newtonsoft.Json;

namespace Operation
{
    class Handler :
        IHandleMessages<WipEnqueuedAtRouteStep> 
    {
        public void Handle(WipEnqueuedAtRouteStep message)
        {
            var state = File.Exists(State.FilePath)
                            ? JsonConvert.DeserializeObject<State>(File.ReadAllText(State.FilePath))
                            : new State();

            state.InQueue.Add(message.Id);

            var json = JsonConvert.SerializeObject(state);
            File.WriteAllText(State.FilePath, json);

            Console.WriteLine("1: Recieved message {0} with Id {1}", message.GetType().Name, message.Id.ToString());
        }
         
    }
}
