import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, exhaustMap, map, switchMap } from 'rxjs/operators';
import {LoadFriend, LoadFriendSuccesful} from 'src/app/modules/chat/store/actions/friend.actions';
import { RequestService } from '../../services/request.service';
import * as getRequest from '../actions/request.actions';
import {
  AcceptRequestFail,
  AcceptRequestLoad,
  AcceptRequestSuccesful,
  RequestListFail,
  RequestListLoad,
  RequestListSuccesful
} from '../actions/request.actions';

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

  acceptRequest$ = createEffect(
    () => this.actions$.pipe(
      ofType(AcceptRequestLoad),
      switchMap(action =>
      this.requestService.acceptRequest(action.request).pipe(
       switchMap(() => {
         return[
           LoadFriend(action.request),
           AcceptRequestSuccesful({request: action.request})
         ]
       }),
        catchError(message => of(AcceptRequestFail ({message})))
      )
      )
    )
  )

  constructor(private actions$: Actions, private requestService: RequestService) {}
}
