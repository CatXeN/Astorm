import { createAction, props } from "@ngrx/store";
import { RequestModel } from "src/app/shared/models/request.model";

export const addResquestLoad = createAction (
  '[Request] Load addRequest',
  props<{request: RequestModel}>()
)

export const addRequestSuccesful = createAction (
  '[Request] Load addRequest Succesfully',
  props<{message: string}>()
)

export const addRequestFail = createAction (
  '[Request] Load addRequest Fail',
  props<{message: string}>()
)
