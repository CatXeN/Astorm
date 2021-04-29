import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { AcceptRequest } from 'src/app/shared/models/acceptRequest.model';
import { Friend } from 'src/app/shared/models/friend.model';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(private http: HttpClient) { }

  addRequest(requestModel: Request):void {
    this.http.post(ApiEndpoints.request.createRequest, requestModel);
  }

  declineRequest(userId: string, friendId: string) {
    this.http.delete(ApiEndpoints.request.deleteRequest.format(String(userId), String(friendId)))
  }

  acceptRequest(acceptRequest: AcceptRequest) {
    this.http.post(ApiEndpoints.request.acceptRequest, acceptRequest);
  }
}
