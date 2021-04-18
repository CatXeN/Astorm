import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import "src/app/core/extensions/string.formater";
@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  changeStatus(statusId, userId) {

    var args = [statusId, userId];

    return this.http.post(ApiEndpoints.user.changeStatus.format(String()))
  }
}
