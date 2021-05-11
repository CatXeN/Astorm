import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable, Subject } from 'rxjs';
import { LoadFriend } from 'src/app/modules/chat/store/actions/friend.actions';
import { getFriends } from 'src/app/modules/chat/store/selectors';
import { Friend } from 'src/app/shared/models/friend.model';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { RequestListLoad } from '../../store/actions/request.actions';
import { RequestSharedService } from '../../services/request-shared.service';
import {requestList} from '../../store/selectors/request.selector';
import {RequestModel} from '../../../../shared/models/request.model';

@Component({
  selector: 'app-friends-container',
  templateUrl: './friends-container.component.html',
  styleUrls: ['./friends-container.component.scss'],
})
export class FriendsContainerComponent implements OnInit {
  userId: string;

  constructor(
    private store: Store<AppState>,
    private requestSharedService: RequestSharedService
  ) {
    this.userId = localStorage.getItem('id');
  }

  ngOnInit(): void {
    this.getFriendList();
    this.getPendingList();
  }

  getFriendList(): void {
    this.store.dispatch(LoadFriend({ userId: this.userId }));
    this.store.pipe(select(getFriends)).subscribe((x) => {
      this.requestSharedService.shareFriends(x);
    });
  }

  getPendingList(): void {
    this.store.dispatch(RequestListLoad({ userId: this.userId }));
    this.store.pipe(select(requestList)).subscribe((x: RequestModel[]) => {
      this.requestSharedService.shareRequests(x);
    })
  }
}
