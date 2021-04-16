import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Friend } from 'src/app/shared/models/friend.model';

@Component({
  selector: 'app-friends-card-presenter',
  templateUrl: './friends-card-presenter.component.html',
  styleUrls: ['./friends-card-presenter.component.scss']
})
export class FriendsCardPresenterComponent  {

 @Output() selectedFriendEmitter = new EventEmitter<Friend>();

  friends: Friend[]

  @Input() set friendList(value: Friend[]) {
    if(value) {
      this.friends = value;
    }
  }

  selectFriend(friend: Friend): void {
    this.selectedFriendEmitter.emit(friend);
  }
}
