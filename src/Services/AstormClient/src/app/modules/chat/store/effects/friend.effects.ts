import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { of } from "rxjs";
import { catchError, exhaustMap, map, mergeMap, switchMap } from "rxjs/operators";
import { FriendService } from "../../service/friend.service";
import { LoadFriend, LoadFriendFail, LoadFriendSuccesful } from "../actions/friend.actions";

@Injectable()

export class FriendEffects {

  loadFriends$ = createEffect(
    () => this.actions$.pipe(
      ofType(LoadFriend),
      exhaustMap(action =>
        this.friendService.getFriendList(action.userId).pipe(
          map(friends => LoadFriendSuccesful ({friends})),
          catchError(message => of(LoadFriendFail ({message})))
        )
      )
    )
  )

  constructor(private actions$: Actions, private friendService: FriendService ) {}
}
