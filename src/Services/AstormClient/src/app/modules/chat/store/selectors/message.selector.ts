import { createSelector } from "@ngrx/store"
import { Message } from "src/app/shared/models/message.model"
import { selectAll } from "../reducers/message.reducer"

export const getMessages = createSelector(
  selectAll,
  (entries: Message[]) => {return entries}
)
