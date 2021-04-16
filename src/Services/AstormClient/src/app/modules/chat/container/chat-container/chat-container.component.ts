import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { Friend } from 'src/app/shared/models/friend.model';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { getFriends } from '../../store';
import { LoadFriend } from '../../store/actions/friend.actions';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.scss']
})
export class ChatContainerComponent implements OnInit {

 selectedFriend: Friend;
  $friends: Observable<Friend[]>;

  constructor(private store: Store<AppState>) { }

  ngOnInit(): void {
    this.store.dispatch(LoadFriend({userId: localStorage.getItem('id')}));
    this.$friends = this.store.pipe(select(getFriends));
  }

  selectedFriendOutput($event: Friend):void {
    this.selectedFriend = $event;
    console.log(this.selectedFriend);
  }
}
