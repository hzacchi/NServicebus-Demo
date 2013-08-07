using System;
using NServiceBus.Saga;

namespace Wip
{
    public class WipRoutingSagaData : ContainSagaData
    {
        [Unique]
        public Guid WipId { get; set; }
    }
}