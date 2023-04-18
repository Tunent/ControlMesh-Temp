import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Queue, QueueValue } from '../_models/queue';
import { Topic, TopicValue } from '../_models/topic';
import { Subscription } from '../_models/subscription';
import { Rule, RuleValue } from '../_models/rule';

@Injectable({
    providedIn: 'root'
})
export class ControlService {
    baseUrl = environment.apiUrl + 'connections/';

    constructor(private http: HttpClient) { }

    getQueues() {
        return this.http.get<Queue[]>(this.baseUrl + 'queues');
    }

    getQueue(queueName: string) {
        return this.http.get<QueueValue>(this.baseUrl + `queues/${queueName}`)
    }

    getTopics() {
        return this.http.get<Topic[]>(this.baseUrl + 'topics');
    }

    getSubscriptions(topicName: string) {
        return this.http.get<Subscription[]>(this.baseUrl + `subscriptions/${topicName}`);
    }

    getRules(topicName: string | undefined, subscriptionName: string) {
        return this.http.get<Rule[]>(this.baseUrl + `rules/${topicName}/${subscriptionName}`);
    }

    getTopic(topicName: any) {
        return this.http.get<TopicValue>(this.baseUrl + `topics/${topicName}`);
    }

    getSubscription(topicName: string | undefined, subscriptionName: string) {
        return this.http.get<Subscription>(this.baseUrl + `subscriptions/${topicName}/${subscriptionName}`);
    }

    getRule(topicName: string | undefined, subscriptionName: string | undefined, ruleName: string | undefined) {
        return this.http.get<RuleValue>(this.baseUrl + `rules/${topicName}/${subscriptionName}/${ruleName}`);
    }


}