import { environment } from "src/environments/environment";

export const ApiEndpoints = {

  auth: {
    register: `${environment.apiUrl}/api/Auth/register`,
    login: `${environment.apiUrl}/api/Auth/authorization`
  },
  friend: {
    getFriend: `${environment.apiUrl}/api/Friend/{0}`,
    addFriend : `${environment.apiUrl}//api/Friend/`
  }
}
