export interface MessageSystemProperties {
      contentType?: string;
      correlationId: string;
      deadLetterErrorDescription?: string;
      deadLetterReason?: string;
      deadLetterSource?: string;
      deliveryCount: number;
      enqueuedSequenceNumber: number; //long  
      enqueuedTime: Date; // DateTimeOffset  
      expiresAt: Date; //DateTimeOffset
      lockedUntil: Date; //DateTimeOffset
      lockToken?: string;
      /// <summary>
      /// This is from the servicebus itself with its own ServiceBusMessageId
      ///<para></para> <see cref="MessageForeignKey"/> Property used top link to Message Entity.
      /// </summary>
      messageId?: string;
      partitionKey?: string;
      replyTo?: string;
      replyToSessionId?: string;
      scheduledEnqueueTime: Date; //DateTimeOffset   
      sequenceNumber: number //long 
      sessionsId?: string;
      state?: string;
      subject?: string;
      timeToLive: Date; //TimeSpan 
      to?: string;
      transactionPartitionKey?: string;
}