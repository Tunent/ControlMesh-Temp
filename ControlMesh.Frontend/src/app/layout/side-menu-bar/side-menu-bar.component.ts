import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-side-menu-bar',
  templateUrl: './side-menu-bar.component.html',
  styleUrls: ['./side-menu-bar.component.scss']
})
export class SideMenuBarComponent {
  items: MenuItem[] = [];
  sidebarVisible: boolean = true;

  ngOnInit() {

    this.items = [
      {
        label: 'Messages',
        icon: 'pi pi-fw pi-envelope',
        routerLink: '/messages'
      },
      {
        label: 'Control',
        icon: 'pi pi-fw pi-cog',
        routerLink: '/control'
      }
    ];
  }
}
