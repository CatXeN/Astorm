import { Component, OnInit } from '@angular/core';
import { webSocket } from "rxjs/webSocket";


@Component({
  selector: 'app-chat-card-presenter',
  templateUrl: './chat-card-presenter.component.html',
  styleUrls: ['./chat-card-presenter.component.scss']
})
export class ChatCardPresenterComponent implements OnInit {

  subject: any;
  messages: Array<{content: string, name: string}> = [];
  text: string;

  constructor() {
    let token = localStorage.getItem('token');
    this.subject = webSocket({url:'ws://localhost:5000/ws?token=' + token});
   }

  ngOnInit(): void {
      this.subject.subscribe({
        next : (data) => {
          console.log(data);
          this.messages.push({name: data.Name, content: data.Content});
          console.log(this.messages);
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
