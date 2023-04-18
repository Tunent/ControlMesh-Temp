using ControlMesh.Database.Models;
using ControlMesh.Services.ViewModels;

namespace ControlMesh.Services
{
    public class MessageServiceMapper : IMessageServiceMapper
    {
        public MessageViewModel GetMessageMapper(Message message)
        {
            var mappedObject = new MessageViewModel
            {
                Id = message.Id,
                Content = message.Content,
                Created = message.Created,
                MessageCustomProperties = new MessageCustomPropertiesViewModel //null checking voor alles?
                {
                    MessageType = message?.MessageCustomProperties?.MessageType,
                    EndPoint = message?.MessageCustomProperties?.EndPoint
                },
                MessageSystemProperties = new MessageSystemPropertiesViewModel
                {
                    MessagePropertyId = message.MessageSystemProperties.MessagePropertyId,
                    ContentType = message.MessageSystemProperties.ContentType,
                    CorrelationId = message.MessageSystemProperties.CorrelationId,
                    DeadLetterErrorDescription = message.MessageSystemProperties.DeadLetterErrorDescription,
                    DeadLetterReason = message.MessageSystemProperties.DeadLetterReason,
                    DeadLetterSource = message.MessageSystemProperties.DeadLetterSource,
                    DeliveryCount = message.MessageSystemProperties.DeliveryCount,
                    EnqueuedSequenceNumber = message.MessageSystemProperties.EnqueuedSequenceNumber,
                    EnqueuedTime = message.MessageSystemProperties.EnqueuedTime,
                    ExpiresAt = message.MessageSystemProperties.ExpiresAt,
                    LockedUntil = message.MessageSystemProperties.LockedUntil,
                    LockToken = message.MessageSystemProperties.LockToken,
                    PartitionKey = message.MessageSystemProperties.PartitionKey,
                    ReplyTo = message.MessageSystemProperties.ReplyTo,
                    ReplyToSessionId = message.MessageSystemProperties.ReplyToSessionId,
                    ScheduledEnqueueTime = message.MessageSystemProperties.ScheduledEnqueueTime,
                    SequenceNumber = message.MessageSystemProperties.SequenceNumber,
                    SessionsId = message.MessageSystemProperties.SessionsId,
                    State = message.MessageSystemProperties.State,
                    Subject = message.MessageSystemProperties.Subject,
                    TimeToLive = message.MessageSystemProperties.TimeToLive,
                    To = message.MessageSystemProperties.To,
                    TransactionPartitionKey = message.MessageSystemProperties.TransactionPartitionKey,
                }
            };
            return mappedObject;
        }
    }
}