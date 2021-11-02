import { Message } from "@angular/compiler/src/i18n/i18n_ast";
import { createSelector, select } from "@ngrx/store";
import { Friend } from "src/app/shared/models/friend.model";
import { selectAll } from "../reducers/friend.reducer";

export const getFriends = createSelector(
  selectAll ,
  (entries: Friend[]) => {return entries}
)

export const getFriend = createSelector(
  selectAll,
  (result: any[], props: string) => {
    let friend: Friend;
    friend = result.find(x => x.friendId.toString() === props);
    console.log(friend);
    console.log(result);
    return friend;
  }
);


