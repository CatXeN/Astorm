import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { LoadFriend } from 'src/app/modules/chat/store/actions/friend.actions';
import { getFriends } from 'src/app/modules/chat/store/selectors';
import { Friend } from 'src/app/shared/models/friend.model';
import { RequestSharedService } from '../../services/request-shared.service';

@Component({
  selector: 'app-friend-list-presenter',
  templateUrl: './friend-list-presenter.component.html',
  styleUrls: ['./friend-list-presenter.component.scss'],
})
export class FriendListPresenterComponent implements OnInit {
  friends: Friend[];
  userId: string;

  constructor(
    private store: Store,
    private requestSharedService: RequestSharedService
  ) {
    this.requestSharedService.friendList$.subscribe((friends) => {
      this.friends = friends;
    });
  }

  ngOnInit(): void {
    this.userId = localStorage.getItem('id');
  }
}
