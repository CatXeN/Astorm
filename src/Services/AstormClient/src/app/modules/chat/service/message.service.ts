import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpoints } from 'src/app/core/http/api.endpoints';
import { GetMessage } from 'src/app/shared/models/getMessage.model';
import { Message } from 'src/app/shared/models/message.model';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private http: HttpClient) { }

  getMessages(message: GetMessage): Observable<Message[]> {
    return this.http.post<Message[]>(ApiEndpoints.message.getMessage, message);
  }
}
