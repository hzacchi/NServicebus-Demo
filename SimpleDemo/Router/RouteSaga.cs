using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messages.Assemble;
using Messages.Orders;
using Messages.Router;
using NServiceBus;
using NServiceBus.Saga;

namespace Router
{
    public class RouteSaga : Saga<RouteSagaData>,
                             IAmStartedByMessages<WipReleased>,
                             IHandleMessages<WipEnqueuedAtRouteStep>,
                             IHandleMessages<WipDequeuedAtRouteStep>,
                             IHandleMessages<OperationStarted>,
                             IHandleMessages<OperationComplete>
    {
        private const string ROUTER = "Router";

        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<WipEnqueuedAtRouteStep>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<OperationStarted>(m => m.WipId).ToSaga(s => s.WipId);
            ConfigureMapping<OperationComplete>(m => m.WipId).ToSaga(s => s.WipId);
        }

        public void Handle(WipReleased message)
        {
            Data.WipId = message.WipId;

            Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = message.WipId, RouteStepId = 1 });
            Console.WriteLine("0: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(WipEnqueuedAtRouteStep message)
        {
            Data.InQueue.Add(message.RouteStepId);
            Console.WriteLine("0: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(WipDequeuedAtRouteStep message)
        {
            if (Data.InQueue.Contains(message.RouteStepId))
            {
                Data.InQueue.Remove(message.RouteStepId);
            }
            Console.WriteLine("0: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(OperationStarted message)
        {
            DequeueAll();
            Data.InQueue.Clear();
            Data.ChangeRouteStep(message.RouteStepId);
            Console.WriteLine("0: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        public void Handle(OperationComplete message)
        {
            Data.ChangeRouteStep(null);

            switch (message.RouteStepId)
            {
                case 1:
                    OnRouteStep1Complete(message);
                    break;
                case 2:
                    OnRouteStep2Complete(message);
                    break;
                case 3:
                    OnRouteStep3Complete(message);
                    break;
                case 4:
                    OnRouteStep4Complete(message);
                    break;
                case 5:
                    OnRouteStep5Complete(message);
                    break;
                case 6:
                    OnRouteStep6Complete(message);
                    break;
                case 7:
                    OnRouteStep7Complete(message);
                    break;
            }
            Console.WriteLine("0: Recieved message {0} with Id {1}", message.GetType().Name, message.WipId.ToString());
        }

        private void OnRouteStep1Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 2 });
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 3 });
                    break;
                case OperationResult.Fail:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 5 });
                    break;
                case OperationResult.Abort:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep2Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 4 });
                    break;
                case OperationResult.Fail:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 5 });
                    break;
                case OperationResult.Abort:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep3Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 4 });
                    break;
                case OperationResult.Fail:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 5 });
                    break;
                case OperationResult.Abort:
                    Data.InProcess = null;
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep4Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 6 });
                    break;
                case OperationResult.Fail:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 5 });
                    break;
                case OperationResult.Abort: 
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep5Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = Data.VisitedRouteSteps.Peek() });
                    break;
                case OperationResult.Fail:
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = 7 });
                    break;
                case OperationResult.Abort: 
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep6Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    break;
                case OperationResult.Fail:
                    break;
                case OperationResult.Abort: 
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep { WipId = Data.Id, RouteStepId = message.RouteStepId });
                    break;
            }
        }

        private void OnRouteStep7Complete(OperationComplete message)
        {
            switch (message.Result)
            {
                case OperationResult.Pass:
                    break;
                case OperationResult.Fail:
                    break;
                case OperationResult.Abort: 
                    Bus.Send(ROUTER, new EnqueueWipAtRouteStep {WipId = Data.Id, RouteStepId = message.RouteStepId});
                    break;
            }
        }

        private void DequeueAll()
        {
            foreach (var step in Data.InQueue)
            {
                Bus.Send(ROUTER, new DequeueWipAtRouteStep {WipId = Data.WipId, RouteStepId = step});
            }
        }
    }
}
