import { environment } from "src/environments/environment";

export const ApiEndpoints = {

  auth: {
    register: `${environment.apiUrl}/api/Auth/register`,
    login: `${environment.apiUrl}/api/Auth/authorization`
  },
  friend: {
    getFriend: `${environment.apiUrl}/api/Friend/{0}`,
    addFriend : `${environment.apiUrl}//api/Friend/`
  },
  message: {
    getMessage: `${environment.apiUrl}/api/Message`
  },
  user: {
    changeStatus: `${environment.apiUrl}/api/User/changeStatus/{0}&{1}`
  },
  request: {
    createRequest: `${environment.apiUrl}/api/Friend/addRequest`,
    deleteRequest: `${environment.apiUrl}/api/Friend/declineRequest/{0}&{1}`,
    acceptRequest: `${environment.apiUrl}/api/Friend/acceptRequest`,
    requestList: `${environment.apiUrl}/api/Friend/getRequest/{0}`
  }
}
