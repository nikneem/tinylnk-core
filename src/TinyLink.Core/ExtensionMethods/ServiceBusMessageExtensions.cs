using Azure.Messaging.ServiceBus;
using System.Text;
using Newtonsoft.Json;
using TinyLink.Core.Abstractions.Commands;

namespace TinyLink.Core.ExtensionMethods;

    public static class ServiceBusMessageExtensions
    {
        public static ServiceBusMessage ToServiceBusMessage(this IUrlShortnerCommand payload, string? correlationId = null)
        {
            var payloadJson = JsonConvert.SerializeObject(payload);
            var message = new ServiceBusMessage(Encoding.UTF8.GetBytes(payloadJson))
            {
                CorrelationId = correlationId ?? Guid.NewGuid().ToString()
            };
            return message;
        }

    }
