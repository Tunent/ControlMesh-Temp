import { Component, OnInit } from '@angular/core';
import { TreeNode } from 'primeng/api';
import { QueueValue } from 'src/app/_models/queue';
import { Queue } from 'src/app/_models/queue';
import { Rule } from 'src/app/_models/rule';
import { Subscription } from 'src/app/_models/subscription';
import { Topic } from 'src/app/_models/topic';
import { ControlService } from 'src/app/_services/control.service';
import { HelperMethods } from 'src/app/_utils/helper-methods';

interface TreeNodeData {
  category: string,
}

@Component({
  selector: 'app-control',
  templateUrl: './control.component.html',
  styleUrls: ['./control.component.scss']
})
export class ControlComponent implements OnInit {
  queues: Queue[] = [];
  nodes: TreeNode<TreeNodeData>[] = [];
  loading: boolean = false;
  currentNodeValue: string | undefined;
  detailedValue: any; //give it a proper name
  detailedQueueValue: QueueValue | undefined = undefined;

  constructor(private controleService: ControlService, public helper: HelperMethods) { }

  ngOnInit(): void {
    this.getQueues();
    this.getTopics();
  }

  getQueues() {
    this.controleService.getQueues().subscribe((queues: Queue[]) => {
      this.queues = queues;
    });
  }

  getTopics() {
    this.controleService.getTopics().subscribe((topics: Topic[]) => {
      for (let i = 0; i < topics.length; i++) {
        this.nodes[i] = {
          key: topics[i].name,
          label: topics[i].name,
          children: [{}],
          data: {
            category: 'topic',
          }
        };
      }
    });
  }


  nodeSelect(event: { node: TreeNode<TreeNodeData> }) {
    if (event.node && event.node.key) {
      this.loading = true;
      this.currentNodeValue = event.node?.key;
      switch (event.node.data?.category) {
        case "topic":
          this.getTopic(this.currentNodeValue);
          break;
        case "subscription":
          this.getSubscription(event.node.parent?.key, event.node.key);
          break;
        case "rule":
          this.getRule(event.node.parent?.parent?.key, event.node.parent?.key, event.node.key)
          break;
        default:
      }
    }
    this.loading = false;
  }


  nodeExpand(event: { node: TreeNode<TreeNodeData> }) {

    this.loading = true;
    this.currentNodeValue = event.node.key;
    switch (event.node.data?.category) {
      case "topic":
        this.getTopic(this.currentNodeValue);
        this.handleSubscriptions(event);
        break;
      case "subscription":
        this.handeRules(event);
        break;
      default:
        throw Error("should not happen");
    }

  }

  private handeRules(event: { node: TreeNode<TreeNodeData>; }) {
    if (event.node && event.node.key) {
      if (!event.node.children && event.node.parent?.key) {
        event.node.children = [];
      }
      this.getSubscription(event.node.parent?.key, event.node.key);

      this.controleService.getRules(event.node.parent?.key, event.node.key).subscribe((rules: Rule[]) => {
        if (!event.node.children) {
          event.node.children = [];
        }

        for (let i = 0; i < rules.length; i++) {
          event.node.children[i] = {
            key: rules[i].name,
            label: rules[i].name,
            data: {
              category: 'rule'
            }
          };
        }
      });
      this.loading = false;
    }
  }

  private handleSubscriptions(event: { node: TreeNode<TreeNodeData>; }) {
    if (event.node && event.node.key) {
      this.controleService.getSubscriptions(event.node.key).subscribe((subscriptions: Subscription[]) => {
        if (!event.node.children) {
          event.node.children = [];
        }

        for (let i = 0; i < subscriptions.length; i++) {
          event.node.children[i] = {
            key: subscriptions[i].subscriptionName,
            label: subscriptions[i].subscriptionName,
            children: [{}],
            data: {
              category: 'subscription',
            }
          };
        }
        this.loading = false;
      });
    }
  }

  getTopic(currentNodeValue: string | undefined) {
    this.controleService.getTopic(currentNodeValue).subscribe((response => {
      this.detailedValue = response;
    }));
  }

  getSubscription(topicName: string | undefined, subscriptionName: string) {
    this.controleService.getSubscription(topicName, subscriptionName).subscribe((response => {
      this.detailedValue = response;
    }));
  }

  showQueueDetails(queueName: string) {
    this.controleService.getQueue(queueName).subscribe((response => {
      this.detailedQueueValue = response;
    }));
  }

  getRule(topicName: string | undefined, subscriptionName: string | undefined, ruleName: string | undefined) {
    this.controleService.getRule(topicName, subscriptionName, ruleName).subscribe((response => {
      console.log(response.value);
      this.detailedValue = response;
    }))
  }
}