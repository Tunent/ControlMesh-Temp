import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { map } from 'rxjs';
import { Message } from 'src/app/_models/message';
import { BreadcrumbService } from 'src/app/_services/breadcrumb.service';

import { MessagesService } from 'src/app/_services/messages.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      {
        label: 'ControlMesh',
        icon: 'pi pi-fw pi-thumbs-up',
        routerLink: '/'
      }
    ]

  }
}