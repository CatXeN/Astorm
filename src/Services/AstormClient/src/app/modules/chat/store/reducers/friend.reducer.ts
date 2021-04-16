import { state } from "@angular/animations";
import { createEntityAdapter, EntityAdapter, EntityState } from "@ngrx/entity";
import { createFeatureSelector, createReducer, on } from "@ngrx/store";
import { Friend } from "src/app/shared/models/friend.model";
import * as FriendActions from '../actions/friend.actions';

export interface FriendState extends EntityState<Friend> {}

export const adapter: EntityAdapter<Friend> = createEntityAdapter<Friend> ();

export const initialFriendState: FriendState = adapter.getInitialState();

export const friendReducer = createReducer(
  initialFriendState,
  on(FriendActions.LoadFriend, (state) => {
    return {...state};
}),
  on(FriendActions.LoadFriendSuccesful, (state, {friends}) => {
    return adapter.setAll(friends, state);
  }),
  on(FriendActions.LoadFriendFail, (state) => {
    return {...state};
  })
);

export const selectState = createFeatureSelector<FriendState>(
  'friend'
);

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors(selectState)

