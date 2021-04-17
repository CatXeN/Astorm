import { HttpClient } from '@angular/common/http';
import { Message } from '@angular/compiler/src/i18n/i18n_ast';
import { stringify } from '@angular/compiler/src/util';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { Friend } from 'src/app/shared/models/friend.model';
import { User } from 'src/app/shared/models/user.model';
import "../../../core/extensions/string.formater";

@Injectable({
  providedIn: 'root'
})
export class FriendService {

  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient ) { }

  addFriend(user: Friend) {
  }

  getFriendList(userId: string): Observable<Friend[]> {
    return this.http.get<Friend[]>(ApiEndpoints.friend.getFriend.format(String(userId)));
  }

}
