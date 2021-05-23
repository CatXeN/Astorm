import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup} from '@angular/forms';
import {Store} from '@ngrx/store';
import {AppState} from '../../../../shared/state/app.interfaces';
import {
  AddRequest,
} from '../../store/actions/request.actions';

@Component({
  selector: 'app-add-request-presenter',
  templateUrl: './add-request-presenter.component.html',
  styleUrls: ['./add-request-presenter.component.scss']
})
export class AddRequestPresenterComponent implements OnInit {

  addRequest = new FormGroup({
      userId: new FormControl(localStorage.getItem('id')),
      userToAdd: new FormControl('')
    })
  constructor(
  private store: Store<AppState>
  ) { }

  ngOnInit(): void {
  }

  sendRequest() {
    console.log(this.addRequest.value)
    this.store.dispatch(AddRequest(this.addRequest.value))
  }
}
