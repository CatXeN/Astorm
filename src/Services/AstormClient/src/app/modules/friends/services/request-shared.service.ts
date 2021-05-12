import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Friend } from 'src/app/shared/models/friend.model';
import { RequestModel } from '../../../shared/models/request.model';

@Injectable({
  providedIn: 'root',
})
export class RequestSharedService {
  //empty
  emptyFriend: Friend[] = [];
  emptyRequest: RequestModel[] = [];
//Behaviour Subjects
  friends = new BehaviorSubject(this.emptyFriend);
  requests = new BehaviorSubject(this.emptyRequest);

  getFriends() {
    return this.friends.asObservable();
  }

  getPendingRequest() {
    return this.requests.asObservable();
  }

  shareFriends(friend: Friend[]) {
    this.friends.next(friend);
  }

  shareRequests(request: RequestModel[]) {
    this.requests.next(request);
  }
}
