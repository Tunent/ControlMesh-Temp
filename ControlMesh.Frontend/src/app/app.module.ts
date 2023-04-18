import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { DividerModule } from 'primeng/divider';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { TopMenuBarComponent } from './layout/top-menu-bar/top-menu-bar.component';
import { MenubarModule } from 'primeng/menubar';
import { SideMenuBarComponent } from './layout/side-menu-bar/side-menu-bar.component';
import { SidebarModule } from 'primeng/sidebar';
import { ButtonModule } from 'primeng/button';
import { MenuModule } from 'primeng/menu';
import { DockModule } from 'primeng/dock';
import { TabViewModule } from 'primeng/tabview';
import { RadioButtonModule } from 'primeng/radiobutton';
import { HomeComponent } from './pages/home/home.component';
import { TableModule } from 'primeng/table';
import { PaginatorModule } from 'primeng/paginator';
import { ScrollTopModule } from 'primeng/scrolltop';
import { DataViewModule, DataViewLayoutOptions } from 'primeng/dataview';
import { MessagesOverviewComponent } from './components/messages-overview/messages-overview.component';
import { MessagesDetailedComponent } from './components/messages-detailed/messages-detailed.component';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { BreadcrumbService } from './_services/breadcrumb.service';
import { ControlComponent } from './components/control/control.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { ListboxModule } from 'primeng/listbox';
import { TreeModule } from 'primeng/tree';
import { SplitterModule } from 'primeng/splitter';
import { ControlDetailedComponent } from './components/control-detailed/control-detailed.component';
import { CardModule } from 'primeng/card';
import { HelperMethods } from './_utils/helper-methods';

@NgModule({
  declarations: [
    HomeComponent,
    AppComponent,
    TopMenuBarComponent,
    SideMenuBarComponent,
    MessagesOverviewComponent,
    MessagesDetailedComponent,
    ControlComponent,
    MessagesComponent,
    ControlDetailedComponent
  ],
  imports: [
    CardModule,
    SplitterModule,
    TreeModule,
    ListboxModule,
    BreadcrumbModule,
    ScrollTopModule,
    ScrollPanelModule,
    DividerModule,
    DataViewModule,
    TabViewModule,
    PaginatorModule,
    TableModule,
    FormsModule,
    RadioButtonModule,
    DockModule,
    MenuModule,
    BrowserAnimationsModule,
    ButtonModule,
    SidebarModule,
    MenubarModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [BreadcrumbService, HelperMethods],
  bootstrap: [AppComponent]
})
export class AppModule { }
