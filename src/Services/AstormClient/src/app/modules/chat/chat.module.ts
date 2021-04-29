import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatContainerComponent } from './container/chat-container/chat-container.component';
import { ChatRoutingModule } from './chat-routing.module';
import { FriendsCardPresenterComponent } from './presenter/friends-card-presenter/friends-card-presenter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChatCardPresenterComponent } from './presenter/chat-card-presenter/chat-card-presenter.component';
import { OperationCardPresenterComponent } from './presenter/operation-card-presenter/operation-card-presenter.component';



@NgModule({
  declarations: [
    ChatContainerComponent,
    FriendsCardPresenterComponent,
    ChatCardPresenterComponent,
    ChatCardPresenterComponent,
    OperationCardPresenterComponent,
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    SharedModule
  ]
})
export class ChatModule { }
