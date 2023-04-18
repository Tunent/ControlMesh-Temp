import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MessagesDetailedComponent } from './components/messages-detailed/messages-detailed.component';
import { HomeComponent } from './pages/home/home.component';
import { ControlComponent } from './components/control/control.component';
import { MessagesComponent } from './pages/messages/messages.component';
import { ControlDetailedComponent } from './components/control-detailed/control-detailed.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'messages', component: MessagesComponent },
  { path: 'messages/:id', component: MessagesDetailedComponent },
  { path: 'control', component: ControlComponent },
  { path: 'topics/:id', component: ControlDetailedComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
