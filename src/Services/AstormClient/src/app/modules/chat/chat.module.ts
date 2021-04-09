import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatContainerComponent } from './container/chat-container/chat-container.component';
import { ChatRoutingModule } from './chat-routing.module';
import { FriendsCardPresenterComponent } from './presenter/friends-card-presenter/friends-card-presenter.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [ChatContainerComponent, FriendsCardPresenterComponent],
  imports: [
    CommonModule,
    ChatRoutingModule,
    SharedModule
  ]
})
export class ChatModule { }
