import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FriendsContainerComponent } from './container/friends-container/friends-container.component';
import { FriendListPresenterComponent } from './presenter/friend-list-presenter/friend-list-presenter.component';
import { PendingFriendsPresenterComponent } from './presenter/pending-friends-presenter/pending-friends-presenter.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FriendsRoutingModule } from './friends-routing.module';
import { AddRequestPresenterComponent } from './presenter/add-request-presenter/add-request-presenter.component';

@NgModule({
  declarations: [
    FriendsContainerComponent,
    FriendListPresenterComponent,
    PendingFriendsPresenterComponent,
    AddRequestPresenterComponent,
  ],
  imports: [CommonModule, SharedModule, FriendsRoutingModule],
})
export class FriendsModule {}
