import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { createReducer } from "@ngrx/store";
import { of } from "rxjs";
import { catchError, exhaustMap, map } from "rxjs/operators";
import { MessageService } from "../../service/message.service";
import { LoadMessage, LoadMessageFail, LoadMessageSuccesful } from "../actions/message.action";


@Injectable()

export class MessageEffects {

  loadMessages$ = createEffect(
    () => this.actions$.pipe(
      ofType(LoadMessage),
      exhaustMap(action =>
        this.messageService.getMessages(action.getMessage).pipe(
          map(messages => LoadMessageSuccesful ({message: messages})),
          catchError(errorMessage => of(LoadMessageFail ({errorMessage})))
        )
      )
    )
  )

  constructor(private actions$: Actions, private messageService: MessageService ) {}
}
