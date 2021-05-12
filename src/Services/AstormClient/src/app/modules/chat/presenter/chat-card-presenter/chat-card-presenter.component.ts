import { MessageUser } from './../../../../shared/models/messsageUser.model';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Friend } from 'src/app/shared/models/friend.model';


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

  @Input() set selectedFriend(value: Friend) {
    if(value){
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


