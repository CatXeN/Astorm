import { createAction, props } from "@ngrx/store";
import { RequestModel } from "src/app/shared/models/request.model";

export const GetRequestListLoad = createAction (
  '[Request] Load getRequestlist Load',
  props<{userId: string}>()
)
export const GetRequestListSuccesful = createAction (
  '[Request] getRequestList Succesfully',
  props<{requests: RequestModel[]}>()
  )
  export const GetRequestListFail = createAction (
    '[Request] getRequestList Fail',
    props<{message: string}>()
    )
