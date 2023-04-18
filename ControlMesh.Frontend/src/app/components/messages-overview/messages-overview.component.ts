import { Component } from '@angular/core';
import { Message } from 'src/app/_models/message';
import { MessagesService } from 'src/app/_services/messages.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-messages-overview',
  templateUrl: './messages-overview.component.html',
  styleUrls: ['./messages-overview.component.scss']
})
export class MessagesOverviewComponent {
  baseUrl = environment.apiUrl;
  messages: Message[] = [];
  pageNumber: number = 1;
  count: number = 0;
  rows: number = 10;

  constructor(private messagesService: MessagesService) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  onPageChange(event: any) {
    this.paginatedMessages(event);
  }

  paginatedMessages(event?: any) {
    this.messagesService.paginatedMessages(this.rows, event).subscribe(result => {
      this.messages = result.items;
      this.pageNumber = event.first + 1,
        this.count = result.count;
      this.rows = event.rows;
    });
  }

  loadMessages() {
    this.messagesService.getMessages()
      .subscribe(response => {
        this.messages = response.items;
        this.pageNumber = response.pageIndex
        this.count = response.count
      });
  }
}
