import { Injectable } from '@angular/core';
import {act, Actions, createEffect, ofType} from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, exhaustMap, map, switchMap } from 'rxjs/operators';
import {LoadFriend, LoadFriendSuccesful} from 'src/app/modules/chat/store/actions/friend.actions';
import { RequestService } from '../../services/request.service';
import * as getRequest from '../actions/request.actions';
import {
  AcceptRequestFail,
  AcceptRequestLoad,
  AcceptRequestSuccesful,
  AddRequestFail,
  AddRequest,
  AddRequestSuccesful,
  DeclineRequestFail,
  DeclineRequestLoad,
  DeclineRequestSuccesful,
  RequestListFail,
  RequestListLoad,
  RequestListSuccesful
} from '../actions/request.actions';
import {RequestModel} from '../../../../shared/models/request.model';
import {addRequestModel} from '../../../../shared/models/addRequest.model';

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

  declineRequest$ = createEffect(
    () => this.actions$.pipe(
      ofType(DeclineRequestLoad),
      switchMap(action =>
        this.requestService.declineRequest(action.request).pipe(
          switchMap( () => {
            return [
                 RequestListLoad(action.request),
              DeclineRequestSuccesful({request: action.request})
            ]
          }),
          catchError(message => of(DeclineRequestFail ({message})))
        )
      )
    )
  )

  addRequest$ = createEffect(
    () => this.actions$.pipe(
      ofType(AddRequest),
      exhaustMap(action =>
      this.requestService.addRequest(action).pipe(
        map( () => AddRequestSuccesful()),
        catchError(message => of(AddRequestFail ({message}))
        )
      )
      )
    )
  )

  constructor(private actions$: Actions, private requestService: RequestService) {}
}
