import { createEntityAdapter, EntityAdapter, EntityState } from "@ngrx/entity";
import { createFeatureSelector, createReducer, on } from "@ngrx/store";
import { Message } from 'src/app/shared/models/message.model';
import * as MessageActions from '../actions/message.action';

export interface MessageState extends EntityState<Message> {}

export const adapter: EntityAdapter<Message> = createEntityAdapter<Message> ();

export const initialMessageState: MessageState = adapter.getInitialState();

export const messageReducer = createReducer(
  initialMessageState,
  on(MessageActions.LoadMessage, (state) => {
    return {...state};
  }),
  on(MessageActions.LoadMessageSuccesful, (state, {message}) => {
    return adapter.setAll(message, state);
  }),
  on(MessageActions.LoadMessageFail, (state) => {
    return {...state};
  })

)

export const selectState = createFeatureSelector<MessageState>(
  'message'
);


export const {
  selectIds,
  selectEntities,
  selectAll,
  selectTotal,
} = adapter.getSelectors(selectState)
