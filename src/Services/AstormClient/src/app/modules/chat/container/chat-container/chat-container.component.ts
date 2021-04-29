import { Component, OnInit } from '@angular/core';
import { select, Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { webSocket } from 'rxjs/webSocket';
import { Friend } from 'src/app/shared/models/friend.model';
import { MessageUser } from 'src/app/shared/models/messsageUser.model';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { getFriends } from '../../store/selectors';
import { LoadFriend } from '../../store/actions/friend.actions';
import { GetMessage } from 'src/app/shared/models/getMessage.model';
import { LoadMessage } from '../../store/actions/message.action';
import { getMessages } from '../../store/selectors/message.selector';

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
  friendList: boolean = true;

  constructor(private store: Store<AppState>) {
    let token = localStorage.getItem('token');
    this.subject = webSocket({url:'ws://localhost:5000/ws?token=' + token});

    this.subject.subscribe({
        next : (data) => {
          console.log(data);
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
    this.getMessages(this.selectedFriend.friendId);
  }

  getMessages(recipentId: string):void {
    let json: GetMessage = {
      userId: this.userId,
      friendId: recipentId
    }
    this.store.dispatch(LoadMessage({getMessage: json}))
    this.store.pipe(select(getMessages)).subscribe(m => {
      this.messages = [];
      m.forEach(x => {

        let messageUser: MessageUser = {
          userId: x.ownerId,
          friendId: x.recipientId,
          content: x.content
        }
        this.messages.push({name: x.owner.username, content: messageUser})
      })
    })
  }
}
