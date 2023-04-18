import { Component, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TopicValue } from 'src/app/_models/topic';
import { ControlService } from 'src/app/_services/control.service';

@Component({
  selector: 'app-control-detailed',
  templateUrl: './control-detailed.component.html',
  styleUrls: ['./control-detailed.component.scss']
})
export class ControlDetailedComponent {
  id: string | null = "";
  topic: TopicValue | undefined;

  constructor(private activatedRoute: ActivatedRoute, private controlService: ControlService) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = params.get('id');
    });
  }

  getTopicByName(topicName: string | null) {
    this.controlService.getTopic(topicName).subscribe((response: TopicValue) => {
      this.topic = response;
    });
  }
}