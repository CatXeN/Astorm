import { createAction, props } from '@ngrx/store';
import { RequestModel } from 'src/app/shared/models/request.model';
import {addRequestModel} from '../../../../shared/models/addRequest.model';

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
  props<{ request: RequestModel }>()
);
export const AcceptRequestSuccesful = createAction(
  '[Request] AcceptRequest Succesfully',
  props<{ request: RequestModel }>()
);
export const AcceptRequestFail = createAction(
  '[Request] AcceptRequest Fail',
  props<{ message: string }>()
);

// Decline Request

export const DeclineRequestLoad = createAction(
  '[Request] DeclineRequest Load',
  props<{request: RequestModel}>()
);

export const DeclineRequestSuccesful = createAction(
  '[Request] DeclineRequest Succesfully',
  props<{request: RequestModel}>()
);

export const DeclineRequestFail = createAction(
  '[Request] DeclineRequest Fail',
  props<{message: string}>()
);

// Add Request

export const AddRequest = createAction(
  '[Request] AddRequest Load',
  props<{addRequest: addRequestModel}>()
);
export const AddRequestSuccesful = createAction(
  '[Request] AddRequest Succesfully'
);
export const AddRequestFail = createAction(
  '[Request AddRequest Fail',
  props<{message: string}>()
);

