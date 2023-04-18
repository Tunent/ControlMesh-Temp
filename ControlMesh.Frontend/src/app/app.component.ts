import { Component, EventEmitter, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { BreadcrumbService } from './_services/breadcrumb.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ControlMesh.Frontend';
  breadcrumb: MenuItem[] = [];

  constructor(private breadcrumbService: BreadcrumbService) {
    // whenever breadcrumb changes, update it
    this.breadcrumbService.breadcrumbChanged.subscribe(breadcrumb => { this.breadcrumb = breadcrumb });
  }
}