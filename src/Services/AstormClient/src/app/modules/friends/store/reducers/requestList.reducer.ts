import { EntityState, EntityAdapter, createEntityAdapter } from "@ngrx/entity";
import { createFeatureSelector, createReducer, on } from "@ngrx/store";
import { RequestModel } from "src/app/shared/models/request.model";
import { GetRequestListFail, GetRequestListLoad, GetRequestListSuccesful } from "../actions/requestList.actions";


export interface getRequestListState extends EntityState<RequestModel> {}

export const adapter: EntityAdapter<RequestModel> = createEntityAdapter<RequestModel> ();

export const initialgetRequestListState: getRequestListState = adapter.getInitialState();

export const addRequestReducer = createReducer(
  initialgetRequestListState,
  on(GetRequestListLoad, (state) => {
    return {...state}
  }),
  on(GetRequestListSuccesful, (state) => {
    return {...state}
  }),
  on(GetRequestListFail, (state) => {
    return {...state}
  }),
);

export const selectState = createFeatureSelector<getRequestListState>(
  'getRequestList'
)

export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors(selectState)
