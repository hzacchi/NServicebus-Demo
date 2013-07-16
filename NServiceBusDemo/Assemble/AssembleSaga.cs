using Common;
using Messages;
using NServiceBus;
using NServiceBus.Saga;

namespace Assemble
{
    public class AssembleSaga : Saga<AssembleSagaData>,
                                IAmStartedByMessages<OperationStartedAtRouteStep>,
                                IHandleMessages<PartAssembled>,
                                IHandleMessages<PartDisassembled>,
                                IHandleMessages<CompleteAssemble>
    { 

        public void Handle(OperationStartedAtRouteStep message)
        { 
        }

        public void Handle(PartAssembled message)
        {
            var assembled = false;

            for (var i = 0; i < Data.MaterialsToAssemble.Count; i++)
            {
                if (Data.MaterialsToAssemble[i] == message.MaterialId)
                {
                    Data.AssembledMaterials.Add(Data.MaterialsToAssemble[i]);
                    Data.MaterialsToAssemble.RemoveAt(i);
                    assembled = true;
                }
            }

            if (!assembled)
            {
                //generate a fault
            }
            else if (Data.MaterialsToAssemble.Count == 0)
            {
                Bus.Send("", new CompleteAssemble {});
            }
        }

        public void Handle(PartDisassembled message)
        {
            var disassembled = false;

            for (var i = 0; i < Data.AssembledMaterials.Count; i++)
            {
                if (Data.MaterialsToAssemble[i] == message.MaterialId)
                {
                    Data.MaterialsToAssemble.Add(Data.MaterialsToAssemble[i]);
                    Data.AssembledMaterials.RemoveAt(i);
                    disassembled = true;
                }
            }

            if (!disassembled)
            {
                //generate a fault
            }
        }

        public void Handle(CompleteAssemble message)
        {
            if (Data.MaterialsToAssemble.Count > 0)
            {
                switch (Data.ResultWhenCompletingWithMaterialRemainingToBeAssembled)
                { 
                    case InProcessOperationResult.Fail:
                        Bus.Publish(new OperationFailedAtRouteStep
                            {
                                WipId = message.WipId,
                                MaterialId = message.MaterialId,
                                RouteStepId = message.RouteStepId,
                                ResourceId = message.ResourceId
                            });
                        return;
                    case InProcessOperationResult.Abort:
                        Bus.Publish(new OperationAbortedAtRouteStep 
                            {
                                WipId = message.WipId,
                                MaterialId = message.MaterialId,
                                RouteStepId = message.RouteStepId,
                                ResourceId = message.ResourceId
                            });
                        return; 
                        //drop through to pass
                }
            }

            Bus.Publish(new OperationPassedAtRouteStep
                {
                    WipId = message.WipId,
                    MaterialId = message.MaterialId,
                    RouteStepId = message.RouteStepId,
                    ResourceId = message.ResourceId
                });
        }
    }
}