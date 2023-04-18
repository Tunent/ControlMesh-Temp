export interface TopicValue {
    hasValue: boolean
    value: Topic
}

export interface Topic {
    name: string;
    authorizationRules: []
    autoDeleteOnIdle: string;
    defaultMessageTimeToLive: string;
    duplicateDetectionHistoryTimeWindow: string
    enableBatchedOperations: boolean
    enablePartitioning: boolean
    maxMessageSizeInKilobytes: number
    maxSizeInMegabytes: number
    requiresDuplicateDetection: boolean
    status: {}
    supportOrdering: boolean
    userMetadata: null
}