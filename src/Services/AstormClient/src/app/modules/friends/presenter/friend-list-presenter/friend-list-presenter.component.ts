import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { LoadFriend } from 'src/app/modules/chat/store/actions/friend.actions';
import { getFriends } from 'src/app/modules/chat/store/selectors';
import { Friend } from 'src/app/shared/models/friend.model';

@Component({
  selector: 'app-friend-list-presenter',
  templateUrl: './friend-list-presenter.component.html',
  styleUrls: ['./friend-list-presenter.component.scss']
})
export class FriendListPresenterComponent implements OnInit {

  friends: Observable<Friend[]>;
  userId: string;

  constructor(private store: Store) {}

  ngOnInit(): void {
    this.userId = localStorage.getItem('id');
    this.store.dispatch(LoadFriend({userId: this.userId}));
    this.friends = this.store.pipe(select(getFriends));
  }

}
