import { Component, OnInit } from '@angular/core';
import {RequestSharedService} from '../../services/request-shared.service';
import {RequestModel} from '../../../../shared/models/request.model';

@Component({
  selector: 'app-pending-friends-presenter',
  templateUrl: './pending-friends-presenter.component.html',
  styleUrls: ['./pending-friends-presenter.component.scss']
})
export class PendingFriendsPresenterComponent implements OnInit {

  request: RequestModel[]

  constructor(private requestSharedService: RequestSharedService) {
    this.requestSharedService.requests.subscribe(x => {
      this.request = x;
    })
  }

  ngOnInit(): void {
  }

}
