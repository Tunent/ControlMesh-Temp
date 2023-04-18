using Azure.Messaging.ServiceBus;
using ControlMesh.Database.Models;
using ControlMesh.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ControlMesh.Host
{
    public class AuditListener : BackgroundService, IAuditListener
    {
        private readonly IMessageRepo _messageRepo;
        private readonly ServiceBusClient _serviceBusClient;
        private readonly ILogger<AuditListener> _logger;

        public AuditListener(IMessageRepo messageRepo, ServiceBusClient serviceBusClient,
                ILogger<AuditListener> logger)
        {
            _messageRepo = messageRepo;
            _serviceBusClient = serviceBusClient;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await ListenToAuditQueueAsync();
        }

        public async Task ListenToAuditQueueAsync()
        {
            ServiceBusProcessor processor;

            processor = _serviceBusClient.CreateProcessor("auditqueue", new ServiceBusProcessorOptions());

            await StartServiceBusProcessAsync(processor);
        }

        private async Task StartServiceBusProcessAsync(ServiceBusProcessor processor)
        {

            processor.ProcessMessageAsync += MessageHandlerAsync;

            processor.ProcessErrorAsync += AnyErrorHandler;

            await processor.StartProcessingAsync();
        }

        private async Task MessageHandlerAsync(ProcessMessageEventArgs args)
        {
            try
            {
                Message? message = JsonSerializer.Deserialize<Message>(args.Message.Body.ToString());
                args.Message.ApplicationProperties.TryGetValue("Type", out var messageType);
                args.Message.ApplicationProperties.TryGetValue("EndPoint", out var endPoint);

                MessageCustomProperties messageCustomProperties = new MessageCustomProperties
                {
                    MessageType = messageType?.ToString(),
                    EndPoint = endPoint?.ToString()
                };

                MessageSystemProperties messageSystemProperties = new MessageSystemProperties
                {
                    ContentType = args.Message.ContentType?.ToString(),
                    CorrelationId = args.Message.CorrelationId?.ToString(),
                    DeadLetterErrorDescription = args.Message.DeadLetterErrorDescription?.ToString(),
                    DeadLetterReason = args.Message.DeadLetterReason?.ToString(),
                    DeadLetterSource = args.Message.DeadLetterSource?.ToString(),
                    DeliveryCount = args.Message.DeliveryCount,
                    EnqueuedSequenceNumber = args.Message.EnqueuedSequenceNumber,
                    EnqueuedTime = args.Message.EnqueuedTime,
                    ExpiresAt = args.Message.ExpiresAt,
                    LockedUntil = args.Message.LockedUntil,
                    LockToken = args.Message.LockToken,
                    MessageId = args.Message.MessageId,
                    PartitionKey = args.Message.PartitionKey,
                    ReplyTo = args.Message.ReplyTo,
                    ReplyToSessionId = args.Message.ReplyToSessionId,
                    ScheduledEnqueueTime = args.Message.ScheduledEnqueueTime,
                    SequenceNumber = args.Message.SequenceNumber,
                    SessionsId = args.Message.SessionId,
                    State = args.Message.State.ToString(),
                    Subject = args.Message.Subject,
                    //TimeToLive = TimeSpan.Parse(args.Message.TimeToLive),
                    To = args.Message.To,
                    TransactionPartitionKey = args.Message.TransactionPartitionKey,
                };

                message.MessageCustomProperties = messageCustomProperties;
                message.MessageSystemProperties = messageSystemProperties;
                await _messageRepo.InsertAsync(message);

                await args.CompleteMessageAsync(args.Message);
            }

            catch (Exception ex) when (ex is JsonException || ex is ArgumentNullException)
            {
                _logger.LogError($"Error Deserializing Message:{ex}");
                await args.DeadLetterMessageAsync(args.Message);
            }

            catch (Exception ex)
            {
                _logger.LogError($"Error Saving Message:{ex}");
                await args.AbandonMessageAsync(args.Message);
            }
        }

        private Task AnyErrorHandler(ProcessErrorEventArgs args)
        {
            _logger.LogError("AnyErrorHandler - any exception occured: ", args);
            return Task.CompletedTask;
        }
    }
}