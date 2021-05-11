import { createAction, props } from '@ngrx/store';
import { RequestModel } from 'src/app/shared/models/request.model';

// Get Request List
export const RequestListLoad = createAction(
  '[Request] Requestlist Load',
  props<{ userId: string }>()
);
export const RequestListSuccesful = createAction(
  '[Request] RequestList Succesfully',
  props<{ request: RequestModel[] }>()
);
export const RequestListFail = createAction(
  '[Request] RequestList Fail',
  props<{ message: string }>()
);

//Accept Request

export const AcceptRequestLoad = createAction(
  '[Request] AcceptRequest Load',
  props<{request: RequestModel}>()
);
export const AcceptRequestSuccesful = createAction(
  '[Request] AcceptRequest Succesfully'
);
export const AcceptRequestFail = createAction(
  '[Request] AcceptRequest Fail',
  props<{message: string}>()
)

