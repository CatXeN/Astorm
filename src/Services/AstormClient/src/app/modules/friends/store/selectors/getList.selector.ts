import { createSelector } from "@ngrx/store";
import { RequestModel } from "src/app/shared/models/request.model";
import { selectAll } from "../reducers/requestList.reducer";

export const getRequestList = createSelector(
  selectAll ,
  (entires: RequestModel[]) => {return entires}
)
