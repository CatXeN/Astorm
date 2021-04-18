import { RouterReducerState } from "@ngrx/router-store";
import { FriendState } from "src/app/modules/chat/store/reducers/friend.reducer";
import { MessageState } from "src/app/modules/chat/store/reducers/message.reducer";
import { RouterStateUrl } from "./state.utilities";

export interface AppState {
    router: RouterReducerState<RouterStateUrl>;
    friend: FriendState;
    message: MessageState
}
