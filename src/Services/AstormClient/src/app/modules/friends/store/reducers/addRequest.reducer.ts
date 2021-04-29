import { EntityState, EntityAdapter, createEntityAdapter } from "@ngrx/entity";
import { createFeatureSelector, createReducer, on } from "@ngrx/store";
import { addRequestFail, addRequestSuccesful, addResquestLoad } from "../actions/addRequest.actions";


export interface addRequestState extends EntityState<Request> {}

export const adapter: EntityAdapter<Request> = createEntityAdapter<Request> ();

export const initialaddRequestState: addRequestState = adapter.getInitialState();

export const addRequestReducer = createReducer(
  initialaddRequestState,
  on(addResquestLoad, (state) => {
    return {...state}
  }),
  on(addRequestSuccesful, (state) => {
    return {...state}
  }),
  on(addRequestFail, (state) => {
    return {...state}
  }),
);

export const selectState = createFeatureSelector<addRequestState>(
  'addRequest'
)

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors(selectState)
