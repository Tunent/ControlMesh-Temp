namespace ControlMesh.Database.Models
{
    public class MessageSystemProperties
    {
        public int Id { get; set; }
        public int MessagePropertyId { get; set; }
        public string? ContentType { get; set; }
        public string? CorrelationId { get; set; }
        public string? DeadLetterErrorDescription { get; set; }
        public string? DeadLetterReason { get; set; }
        public string? DeadLetterSource { get; set; }
        public int DeliveryCount { get; set; }
        public long EnqueuedSequenceNumber { get; set; }
        public DateTimeOffset EnqueuedTime { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public DateTimeOffset LockedUntil { get; set; }
        public string? LockToken { get; set; }
        /// <summary>
        /// This is from the servicebus itself with its own ServiceBusMessageId
        ///<para></para> <see cref="MessageForeignKey"/> Property used top link to Message Entity.
        /// </summary>
        public string? MessageId { get; set; }
        public string? PartitionKey { get; set; }
        public string? ReplyTo { get; set; }
        public string? ReplyToSessionId { get; set; }
        public DateTimeOffset ScheduledEnqueueTime { get; set; }
        public long SequenceNumber { get; set; }
        public string? SessionsId { get; set; }
        public string? State { get; set; }
        public string? Subject { get; set; }
        public TimeSpan TimeToLive { get; set; }
        public string? To { get; set; }
        public string? TransactionPartitionKey { get; set; }
        /// <summary>
        /// This is from the Message Property and is the for the Message entity and is the Foreign Key
        ///<para></para> <see cref="MessageId"/> Property gained from reading the ServicebusMessage.
        /// </summary>
        public int MessageForeignKey { get; set; }
        public virtual Message Message { get; set; }
    }
}