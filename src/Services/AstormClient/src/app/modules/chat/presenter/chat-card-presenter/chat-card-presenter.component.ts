import { Component, OnInit } from '@angular/core';
import { webSocket } from "rxjs/webSocket";


@Component({
  selector: 'app-chat-card-presenter',
  templateUrl: './chat-card-presenter.component.html',
  styleUrls: ['./chat-card-presenter.component.scss']
})
export class ChatCardPresenterComponent implements OnInit {

  subject: any;
  messages: Array<string> = [];
  text: string;

  constructor() {
    let token = localStorage.getItem('token');
    this.subject = webSocket({url:'ws://localhost:5000/ws?token=' + token, deserializer: e => e.data});
   }

  ngOnInit(): void {
      this.subject.subscribe({
        next : (data) => {
          console.log(data);
          this.messages.push(data);
        },
        error : console.log,
        complete : () => {}
      }
    );
  }

  sendMessage() {
    if(this.text !== undefined) {
      this.subject.next(this.text);
    }
  }
}
