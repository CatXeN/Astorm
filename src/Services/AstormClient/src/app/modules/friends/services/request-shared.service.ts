import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Friend } from 'src/app/shared/models/friend.model';
import {RequestModel} from '../../../shared/models/request.model';

@Injectable({
  providedIn: 'root',
})
export class RequestSharedService {
  friends = new Subject<Friend[]>();
  requests = new Subject<RequestModel[]>();

  requestList$ = this.requests.asObservable();
  friendList$ = this.friends.asObservable();

  shareFriends(friend: Friend[]) {
    this.friends.next(friend);
  }

  shareRequests(request: RequestModel[]) {
    this.requests.next((request));
  }
}
