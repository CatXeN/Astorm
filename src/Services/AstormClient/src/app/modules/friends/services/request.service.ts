import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { RequestModel } from 'src/app/shared/models/request.model';
import {addRequestModel} from '../../../shared/models/addRequest.model';

@Injectable({
  providedIn: 'root'
})
export class RequestService {

  constructor(private http: HttpClient) { }

  addRequest(addRequest: any) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      })
    };
  const json = {
    userId: addRequest.userId,
    userToAdd: addRequest.userToAdd
  }
   return this.http.post(ApiEndpoints.request.createRequest, addRequest, httpOptions);
  }

  declineRequest(request: RequestModel) {
  return this.http.delete(ApiEndpoints.request.deleteRequest.format(String(request.userId), String(request.friendId)))
  }

  acceptRequest(acceptRequest: RequestModel) {
     return this.http.post(ApiEndpoints.request.acceptRequest, acceptRequest);
  }

  getRequestList(userId: string) : Observable<RequestModel[]>{
   return this.http.get<RequestModel[]>(ApiEndpoints.request.requestList.format(String(userId)));
  }
}
