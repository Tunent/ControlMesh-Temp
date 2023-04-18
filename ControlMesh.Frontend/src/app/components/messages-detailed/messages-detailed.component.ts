import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { Message } from 'src/app/_models/message';
import { BreadcrumbService } from 'src/app/_services/breadcrumb.service';
import { MessagesService } from 'src/app/_services/messages.service';
import { HelperMethods } from 'src/app/_utils/helper-methods';
HelperMethods

@Component({
  selector: 'app-messages-detailed',
  templateUrl: './messages-detailed.component.html',
  styleUrls: ['./messages-detailed.component.scss']
})
export class MessagesDetailedComponent {
  message?: Message;
  id: string | null = ""
  breadcrumbItems: MenuItem[] = [];

  constructor(private activatedRoute: ActivatedRoute, private messagesService: MessagesService, private breadcrumb: BreadcrumbService
    , public helper: HelperMethods) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = params.get('id');
      this.getMessageById(this.id)
    });
    this.breadcrumbItems.push({ label: 'Messages', routerLink: '/messages' });
    this.breadcrumbItems.push({ label: 'Detailed Message' });
    this.breadcrumb.setBreadcrumb(this.breadcrumbItems);
  }

  getMessageById(id: any) {
    this.messagesService.getMessageById(id).subscribe((response: Message) => {
      this.message = response;
    });
  }
}