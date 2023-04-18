export interface QueueValue {
    value: Queue;
    hasValue: boolean;
}

export interface Queue {
    name: string
    lockDuration: string;
    maxSizeInMegabytes: number;
    requiresDuplicateDetection: boolean;
    requiresSession: boolean;
    defaultMessageTimeToLive: string;
    autoDeleteOnIdle: string;
    deadLetteringOnMessageExpiration: boolean;
    duplicateDetectionHistoryTimeWindow: string;
    maxDeliveryCount: number;
    enableBatchedOperations: boolean;
    authorizationRules: [],
    status: {},
    forwardTo: string
    forwardDeadLetteredMessagesTo: string,
    enablePartitioning: boolean;
    userMetadata: string,
    maxMessageSizeInKilobytes: number;
}