import { createAction, props } from "@ngrx/store";

export const addResquestLoad = createAction (
  '[Request] Load addRequest',
  props<{request: Request}>()
)

export const addRequestSuccesful = createAction (
  '[Request] Load addRequest Succesfully',
  props<{message: string}>()
)

export const addRequestFail = createAction (
  '[Request] Load addRequest Fail',
  props<{message: string}>()
)
