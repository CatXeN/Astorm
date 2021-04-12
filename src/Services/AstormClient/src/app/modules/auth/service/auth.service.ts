import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { Login } from 'src/app/shared/models/login.model';
import { map, catchError } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper = new JwtHelperService();

  constructor(private http: HttpClient) { }

  login(user: Login) {
    return this.http.post(ApiEndpoints.auth.login, user).pipe(map((response: string) => {
      const user = response;
      if(user){
        localStorage.setItem('token', response);
        const decodedToken = this.jwtHelper.decodeToken(response);
        localStorage.setItem("id", decodedToken.nameid)
        localStorage.setItem('name', decodedToken.unique_name);
      }
    }));
  }

  register(user: Login) {
    return this.http.post(ApiEndpoints.auth.register, user);
  }
}
