import { createSelector } from '@ngrx/store';
import { RequestModel } from 'src/app/shared/models/request.model';
import { selectAll } from '../reducers/request.reducer';

export const requestList = createSelector(
  selectAll,
  (entires: RequestModel[]) => {
    return entires;
  }
);
