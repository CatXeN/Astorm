import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { AcceptRequest } from 'src/app/shared/models/acceptRequest.model';
import { Friend } from 'src/app/shared/models/friend.model';
import { RequestModel } from 'src/app/shared/models/request.model';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(private http: HttpClient) { }

  addRequest(requestModel: Request) {
   return this.http.post(ApiEndpoints.request.createRequest, requestModel);
  }

  declineRequest(userId: string, friendId: string) {
  return this.http.delete(ApiEndpoints.request.deleteRequest.format(String(userId), String(friendId)))
  }

  acceptRequest(acceptRequest: AcceptRequest) {
     return this.http.post(ApiEndpoints.request.acceptRequest, acceptRequest);
  }

  getRequestList(userId: string) : Observable<RequestModel[]>{
   return this.http.get<RequestModel[]>(ApiEndpoints.request.RequestList.format(String(userId)));
  }
}
