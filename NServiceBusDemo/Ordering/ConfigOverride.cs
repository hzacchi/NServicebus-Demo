using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Ordering
{
    class ConfigOverride : IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
                {
                    ErrorQueue = "error"
                };
        }
    }
}