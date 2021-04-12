import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { Login } from 'src/app/shared/models/login.model';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(user: Login) {
    return this.http.post(ApiEndpoints.auth.login, user).pipe(map((response: string) => {
      const user = response;
      if(user){
        localStorage.setItem('token', response);
      }
    }));
  }
}
