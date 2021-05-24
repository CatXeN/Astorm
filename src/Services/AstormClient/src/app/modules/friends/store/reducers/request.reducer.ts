import { EntityState, EntityAdapter, createEntityAdapter } from '@ngrx/entity';
import { createFeatureSelector, createReducer, on } from '@ngrx/store';
import { RequestModel } from 'src/app/shared/models/request.model';
import * as request from '../actions/request.actions';

export interface RequestState extends EntityState<RequestModel> {}

export const adapter: EntityAdapter<RequestModel> =
  createEntityAdapter<RequestModel>();

export const initialRequestListState: RequestState = adapter.getInitialState();

export const requestReducer = createReducer(
  initialRequestListState,
  on(request.RequestListLoad, (state) => {
    return { ...state };
  }),
  on(request.RequestListSuccesful, (state, { request }) => {
    return adapter.setAll(request, state);
  }),
  on(request.RequestListFail, (state) => {
    return { ...state };
  }),
  on(request.AcceptRequestLoad, (state) => {
    return { ...state };
  }),
  on(request.AcceptRequestSuccesful, (state, { request }) => {
    return adapter.removeOne(request.id, state);
  }),
  on(request.AcceptRequestFail, (state) => {
    return { ...state };
  }),
  on(request.DeclineRequestLoad, (state) => {
    return { ...state };
  }),
  on(request.DeclineRequestSuccesful, (state, { request }) => {
    return adapter.removeOne(request.id, state);
  }),
  on(request.DeclineRequestFail, (state) => {
    return { ...state };
  }),
  on(request.AddRequest, (state) => {
    return {...state}
  }),
  on(request.AddRequestSuccesful, (state) => {
    return {...state}
  }),
  on(request.AddRequestFail, (state) => {
    return {...state}
  }),
);

export const selectState = createFeatureSelector<RequestState>('request');

export const { selectIds, selectEntities, selectAll, selectTotal } =
  adapter.getSelectors(selectState);
