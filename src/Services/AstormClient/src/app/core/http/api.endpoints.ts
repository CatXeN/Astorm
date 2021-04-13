import { environment } from "src/environments/environment";

export const ApiEndpoints = {

  auth: {
    register: `${environment.apiUrl}/api/Auth/register`,
    login: `${environment.apiUrl}/api/Auth/authorization`
  }
}
