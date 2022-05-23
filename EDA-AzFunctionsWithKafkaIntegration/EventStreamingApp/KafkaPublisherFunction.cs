using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Confluent.Kafka;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using EventStreamingApp.Models;
using Newtonsoft.Json;
namespace EventStreamingApp
{
    public static class KafkaPublisherFunction
    {
        [FunctionName("KafkaOutput")]
        public static IActionResult Output(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Kafka("BootstrapServer",
            "topic",
            Username = "ConfluentCloudUserName",
            Password = "ConfluentCloudPassword",
            Protocol = BrokerProtocol.SaslSsl,
           AuthenticationMode = BrokerAuthenticationMode.Plain
    )] out string eventData,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var eventToKafka = new OrderEventModel
            {
                address = new Address
                {
                    city = "City_288",
                    state = "State_56",
                    zipcode = 73558
                },
                ordertime= DateTime.UtcNow.Ticks,
                orderid=1000,
                itemid= "Item_963",
                orderunits=1
            };

            string message = JsonConvert.SerializeObject(eventToKafka);
            string responseMessage = "Ok";
            eventData = message;

            return new OkObjectResult(responseMessage);
        }
    }
}
