import { ActionReducerMap, MetaReducer } from "@ngrx/store";
import { environment } from "src/environments/environment";
import { AppState } from "./app.interfaces";
import { storeFreeze } from 'ngrx-store-freeze';
import { routerReducer } from "@ngrx/router-store";
import { friendReducer } from "src/app/modules/chat/store/reducers/friend.reducer";
import { messageReducer } from "src/app/modules/chat/store/reducers/message.reducer";
import { requestReducer } from 'src/app/modules/friends/store/reducers/request.reducer';

export const appReducer: ActionReducerMap<AppState> = {
    router: routerReducer,
    friend: friendReducer,
    message: messageReducer,
    request: requestReducer
};

export const appMetaReducers: MetaReducer<AppState>[] = !environment.production
?[storeFreeze]: [];
