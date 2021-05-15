import { MessageUser } from './../../../../shared/models/messsageUser.model';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Friend } from 'src/app/shared/models/friend.model';
import { select, Store } from '@ngrx/store';
import { AppState } from 'src/app/shared/state/app.interfaces';
import { ActivatedRoute } from '@angular/router';
import { getFriend } from '../../store/selectors';
import { getMessages } from '../../store/selectors/message.selector';
import { LoadMessage } from '../../store/actions/message.action';
import { GetMessage } from 'src/app/shared/models/getMessage.model';


@Component({
  selector: 'app-chat-card-presenter',
  templateUrl: './chat-card-presenter.component.html',
  styleUrls: ['./chat-card-presenter.component.scss']
})
export class ChatCardPresenterComponent {
  text = "";
  messages: Array<{content: MessageUser, name: string}> = [];
  friend: Friend;
  showEmoji: boolean = false;
  id: string;

  constructor(private store: Store<AppState>, activatedRoute: ActivatedRoute) {
    activatedRoute.params.subscribe(params => {
      this.id = params['id'];

      this.store.pipe(select(getFriend, this.id)).subscribe(result => {
        this.friend = result;
      });


      let json: GetMessage = {
        userId: localStorage.getItem('id'),
        friendId: this.id
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
    });
  }

  @Input() set selectedFriend(value: Friend) {
    if(value && this.id != ""){
      this.friend = value;
    }
  }

  @Input() set SetMessages(value: Array<{content: MessageUser, name: string}>) {
    if (value) {
      this.messages = value;
    }
  }

  @Output() sendMessageEmitter = new EventEmitter<MessageUser>();

  sendMessage() {
    let message: MessageUser = {
      friendId: this.friend.friendId,
      content: this.text,
      userId: ''
    };

    if (message.content !== "") {
      this.sendMessageEmitter.emit(message);
      this.text = "";
    }
  }

  filtrMessages() {
    return this.messages.
      filter(x => x.content.userId == this.friend.friendId || x.content.friendId == this.friend.friendId);
  }

  getMessage() {

  }

  addEmoji($event) {
    if($event && $event.emoji.native != undefined) {
      this.text += $event.emoji.native;
    }
  }

  switchEmojiKeyboard() {
    this.showEmoji = !this.showEmoji;
  }
}


