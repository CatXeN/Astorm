import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { webSocket } from 'rxjs/webSocket';
import { Friend } from 'src/app/shared/models/friend.model';
import { MessageUser } from 'src/app/shared/models/messsageUser.model';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { getFriends } from '../../store';
import { LoadFriend } from '../../store/actions/friend.actions';

@Component({
  selector: 'app-chat-container',
  templateUrl: './chat-container.component.html',
  styleUrls: ['./chat-container.component.scss']
})
export class ChatContainerComponent implements OnInit {

  selectedFriend: Friend;
  $friends: Observable<Friend[]>;
  subject: any;
  messages: Array<{content: MessageUser, name: string}> = [];
  userId: string;

  constructor(private store: Store<AppState>) {
    let token = localStorage.getItem('token');
    this.subject = webSocket({url:'ws://localhost:5000/ws?token=' + token});

    this.subject.subscribe({
        next : (data) => {
          let content : MessageUser = JSON.parse(data.content);

          if(content.friendId == this.userId || content.userId == this.userId) {
            this.messages.push({name: data.name, content: content});
          }
        },
        error : console.log,
        complete : () => {}
      }
    );

    this.userId = localStorage.getItem('id');
  }

  ngOnInit(): void {
    this.store.dispatch(LoadFriend({userId: this.userId}));
    this.$friends = this.store.pipe(select(getFriends));
  }

  sendMessage($event: MessageUser) {
    $event.userId = this.userId;
    this.subject.next($event);
  }

  selectedFriendOutput($event: Friend):void {
    this.selectedFriend = $event;
    console.log(this.selectedFriend);
  }
}
