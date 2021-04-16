import { createSelector, select } from "@ngrx/store";
import { Friend } from "src/app/shared/models/friend.model";
import { selectAll } from "./reducers/friend.reducer";

export const getFriends = createSelector(
  selectAll ,
  (entries: Friend[]) => {return entries}
)
