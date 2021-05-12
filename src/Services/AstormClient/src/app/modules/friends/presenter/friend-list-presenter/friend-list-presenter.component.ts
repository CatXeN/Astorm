import { Component, OnDestroy, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { LoadFriend } from 'src/app/modules/chat/store/actions/friend.actions';
import { getFriends } from 'src/app/modules/chat/store/selectors';
import { Friend } from 'src/app/shared/models/friend.model';
import { RequestSharedService } from '../../services/request-shared.service';

@Component({
  selector: 'app-friend-list-presenter',
  templateUrl: './friend-list-presenter.component.html',
  styleUrls: ['./friend-list-presenter.component.scss'],
})
export class FriendListPresenterComponent implements OnInit, OnDestroy {
  friends: Friend[];
  userId: string;
  subscription: Subscription;
  constructor(
    private store: Store,
    private requestSharedService: RequestSharedService
  ) {}

  ngOnInit(): void {
    this.requestSharedService.getFriends().subscribe((x) => {
      this.friends = x;
    });
    this.userId = localStorage.getItem('id');
  }

  ngOnDestroy(): void {
    // this.subscription.unsubscribe();
  }
}
