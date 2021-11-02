import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChatContainerComponent } from './container/chat-container/chat-container.component';
import { ChatRoutingModule } from './chat-routing.module';
import { FriendsCardPresenterComponent } from './presenter/friends-card-presenter/friends-card-presenter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ChatCardPresenterComponent } from './presenter/chat-card-presenter/chat-card-presenter.component';
import { PickerModule } from '@ctrl/ngx-emoji-mart';


@NgModule({
  declarations: [
    ChatContainerComponent,
    FriendsCardPresenterComponent,
    ChatCardPresenterComponent,
    ChatCardPresenterComponent,
  ],
  imports: [
    CommonModule,
    ChatRoutingModule,
    SharedModule,
    PickerModule
  ]
})
export class ChatModule { }
