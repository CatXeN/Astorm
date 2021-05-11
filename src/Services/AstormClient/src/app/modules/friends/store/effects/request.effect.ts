import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, exhaustMap, map } from 'rxjs/operators';
import { LoadFriendSuccesful } from 'src/app/modules/chat/store/actions/friend.actions';
import { RequestService } from '../../services/request.service';
import * as getRequest from '../actions/request.actions';
import {AcceptRequestLoad, RequestListFail, RequestListLoad, RequestListSuccesful} from '../actions/request.actions';

@Injectable({
  providedIn: 'root'
})
export class RequestEffects {

  getRequestList$ = createEffect(
    () => this.actions$.pipe(
      ofType(RequestListLoad),
      exhaustMap(action =>
        this.requestService.getRequestList(action.userId).pipe(
          map(request => RequestListSuccesful ({request})),
          catchError(message => of(RequestListFail ({message})))
        )
      )
    )
  )

  // addRequest$ = createEffect(
  //   () => this.actions$.pipe(
  //     ofType(AcceptRequestLoad),
  //     exhaustMap(action =>
  //     this.requestService.acceptRequest(action.request).pipe(
  //       map()
  //       catchError(message => of(AddRequestFail ({message})))
  //     )
  //     )
  //   )
  // )

  constructor(private actions$: Actions, private requestService: RequestService) {}
}
