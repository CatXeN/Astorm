import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatContainerComponent } from './container/chat-container/chat-container.component';

const routes: Routes = [
  {
    path: '',
    component: ChatContainerComponent,
  },
  {
    path: ':id',
    component: ChatContainerComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ChatRoutingModule { }
