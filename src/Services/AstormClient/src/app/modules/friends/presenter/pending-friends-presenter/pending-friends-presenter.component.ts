import { Component, OnDestroy, OnInit } from '@angular/core';
import {RequestSharedService} from '../../services/request-shared.service';
import {RequestModel} from '../../../../shared/models/request.model';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../shared/state/app.interfaces';
import {AcceptRequestLoad} from '../../store/actions/request.actions';
import {Subscription} from 'rxjs';

@Component({
  selector: 'app-pending-friends-presenter',
  templateUrl: './pending-friends-presenter.component.html',
  styleUrls: ['./pending-friends-presenter.component.scss']
})
export class PendingFriendsPresenterComponent implements OnInit, OnDestroy {

  subscription: Subscription;
  request: RequestModel[]

  constructor(private store: Store<AppState>, private requestSharedService: RequestSharedService) {
  }

  ngOnInit(): void {
  this.subscription = this.requestSharedService.getPendingRequest().subscribe(x => {this.request = x})
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe()
  }

  acceptRequest(request: RequestModel){
  this.store.dispatch(AcceptRequestLoad({request}))
  }
}
