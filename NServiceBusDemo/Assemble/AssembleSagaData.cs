using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Domain.Identities;
using NServiceBus.Saga;

namespace Assemble
{
    public class AssembleSagaData : IContainSagaData
    {
        // the following properties are mandatory
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        [Unique]
        public string UniqueId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_uniqueId))
                {
                    return string.Format("{0}.{1}", WipId.Id, RouteStepId.Id);
                }
                return _uniqueId;
            }
            set { _uniqueId = value; }
        }
        private string _uniqueId;

        // all other properties you want persisted
        public RouteStepId RouteStepId { get; set; }
        public WipId WipId { get; set; }
        public IList<MaterialId> MaterialsToAssemble { get; set; }
        public IList<MaterialId> AssembledMaterials { get; set; }

        public InProcessOperationResult ResultWhenCompletingWithMaterialRemainingToBeAssembled { get; set; }

        public AssembleSagaData()
        {
            MaterialsToAssemble = new List<MaterialId>();
        }
    }
}
