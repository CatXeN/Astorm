import { createAction, props } from '@ngrx/store'
import { GetMessage } from 'src/app/shared/models/getMessage.model'
import { Message } from 'src/app/shared/models/message.model';

export const LoadMessage = createAction (
    "[Message] Load Messages",
    props<{getMessage: GetMessage}>()
)

export const LoadMessageSuccesful = createAction (
  "[Message] Load Messages Succesfully",
  props<{message: Message[]}>()
)

export const LoadMessageFail = createAction (
  "[Message] Load Messages Fail",
  props<{errorMessage: string}>()
)
