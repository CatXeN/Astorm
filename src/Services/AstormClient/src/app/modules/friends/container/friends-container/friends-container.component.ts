import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { LoadFriend } from 'src/app/modules/chat/store/actions/friend.actions';
import { getFriends } from 'src/app/modules/chat/store/selectors';
import { Friend } from 'src/app/shared/models/friend.model';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { GetRequestListLoad } from '../../store/actions/requestList.actions';


@Component({
  selector: 'app-friends-container',
  templateUrl: './friends-container.component.html',
  styleUrls: ['./friends-container.component.scss']
})
export class FriendsContainerComponent implements OnInit {

  userId: string;
  $friendList = new Subject<Friend[]>();
  friends: Friend[]

  constructor(private store: Store<AppState>) {
    this.userId = localStorage.getItem('id');
  }

  ngOnInit(): void {
    this.getFriendList();
  }

  getFriendList() {
    this.store.dispatch(LoadFriend({userId: this.userId}));
    this.$friendList == this.store.pipe(select(getFriends));
    this.$friendList.next(this.friends);
  }

  getPendingList() {
    this.store.dispatch(GetRequestListLoad({userId: this.userId}))
  }
}
