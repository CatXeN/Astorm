import { RouterReducerState } from "@ngrx/router-store";
import { FriendState } from "src/app/modules/chat/store/reducers/friend.reducer";
import { MessageState } from "src/app/modules/chat/store/reducers/message.reducer";
import { RouterStateUrl } from "./state.utilities";
import {RequestState} from '../../modules/friends/store/reducers/request.reducer';

export interface AppState {
    router: RouterReducerState<RouterStateUrl>;
    friend: FriendState;
    message: MessageState;
    request: RequestState;
}
