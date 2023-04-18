export interface Subscription {
    autoDeleteOnIdle: string;
    deadLetteringOnMessageExpiration: boolean;
    defaultMessageTimeToLive: string;
    enableBatchedOperations: boolean;
    enableDeadLetteringOnFilterEvaluationExceptions: boolean;
    forwardDeadLetteredMessagesTo: string;
    forwardTo: string;
    lockDuration: string;
    maxDeliveryCount: number;
    requiresSession: boolean
    status: object;
    subscriptionName: string;
    topicName: string;
    userMetadata: string;
}