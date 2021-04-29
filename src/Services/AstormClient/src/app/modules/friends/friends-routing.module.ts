import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { FriendsContainerComponent } from "./container/friends-container/friends-container.component";
import { FriendListPresenterComponent } from "./presenter/friend-list-presenter/friend-list-presenter.component";
import { PendingFriendsPresenterComponent } from "./presenter/pending-friends-presenter/pending-friends-presenter.component";

const routes: Routes = [
  {
    path: '',
    component: FriendsContainerComponent,
    children: [
      {
        path: 'list',
        component: FriendListPresenterComponent
      },
      {
        path: 'pending',
        component: PendingFriendsPresenterComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class FriendsRoutingModule { }
