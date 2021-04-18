import { createAction, props, } from "@ngrx/store";
import { Friend } from "src/app/shared/models/friend.model";

export const LoadFriend = createAction (
  '[Friend] Load Friends',
  props<{userId: string}>()
)

export const LoadFriendSuccesful = createAction (
  '[Friend] Load Friends Succesful',
    props<{friends: Friend[]}>()
);

export const LoadFriendFail = createAction (
  '[Friend] Load Friends Fail',
    props<{message: string}>()
);
