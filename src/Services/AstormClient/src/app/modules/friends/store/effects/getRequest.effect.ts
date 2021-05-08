import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { of } from 'rxjs';
import { catchError, exhaustMap, map } from 'rxjs/operators';
import { LoadFriendSuccesful } from 'src/app/modules/chat/store/actions/friend.actions';
import { RequestService } from '../../services/request.service';
import * as getRequest from '../actions/requestList.actions';
import { GetRequestListFail, GetRequestListLoad, GetRequestListSuccesful } from '../actions/requestList.actions';

@Injectable({
  providedIn: 'root'
})
export class getRqeusetList {

  getRequestList$ = createEffect(
    () => this.actions$.pipe(
      ofType(GetRequestListLoad),
      exhaustMap(action =>
        this.requestService.getRequestList(action.userId).pipe(
          map(requests => GetRequestListSuccesful ({requests})),
          catchError(message => of(GetRequestListFail ({message})))
        )
      )
    )
  )

  constructor(private actions$: Actions, private requestService: RequestService) {}
}
