using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.AspNetCore.Mvc;

namespace ControlMesh.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController : ControllerBase
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ServiceBusAdministrationClient _sbAdminClient;

        public ConnectionsController(ServiceBusClient serviceBusClient, ServiceBusAdministrationClient sbAdminClient)
        {
            _serviceBusClient = serviceBusClient;
            _sbAdminClient = sbAdminClient;
        }

        [HttpGet]
        public IActionResult GetConnectionsAsync()
        {
            return Ok(_serviceBusClient.FullyQualifiedNamespace);
        }

        [HttpGet("queues")]
        public async Task<IActionResult> GetQueues()
        {
            var result = await _sbAdminClient.GetQueuesAsync().ToListAsync();
            return Ok(result);
        }

        [HttpGet("queues/{queueName}")]
        public async Task<IActionResult> GetQueue(string queueName)
        {
            var result = await _sbAdminClient.GetQueueAsync(queueName);

            return Ok(result);
        }

        [HttpGet("topics")]
        public async Task<IActionResult> GetTopics()
        {
            var result = await _sbAdminClient.GetTopicsAsync().ToListAsync();
            return Ok(result);
        }

        [HttpGet("subscriptions/{topicName}")]
        public async Task<IActionResult> GetSubscriptions(string topicName)
        {
            var result = await _sbAdminClient.GetSubscriptionsAsync(topicName).ToListAsync();
            return Ok(result);
        }

        [HttpGet("rules/{topicName}/{subscriptionName}")]
        public async Task<IActionResult> GetRules(string topicName, string subscriptionName, CancellationToken cancellationToken)
        {
            var results = await _sbAdminClient.GetRulesAsync(topicName, subscriptionName).ToListAsync();

            return Ok(results);
        }

        [HttpGet("topics/{topicName}")]
        public async Task<IActionResult> GetTopic(string topicName)
        {
            var result = await _sbAdminClient.GetTopicAsync(topicName);
            return Ok(result);
        }

        [HttpGet("subscriptions/{topicName}/{subscriptionName}")]
        public async Task<IActionResult> GetSubscription(string topicName, string subscriptionName)
        {
            var result = await _sbAdminClient.GetSubscriptionAsync(topicName, subscriptionName);

            return Ok(result);
        }

        [HttpGet("rules/{topicName}/{subscriptionName}/{ruleName}")]
        public async Task<IActionResult> GetRule(string topicName, string subscriptionName, string ruleName)
        {
            var result = await _sbAdminClient.GetRuleAsync(topicName, subscriptionName, ruleName);

            return Ok(result);
        }
    }
}