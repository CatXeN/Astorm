import { User } from "./user.model";

export interface Message {
  ownerId: string;
  recipientId: string;
  content: string;
  sendMessageDate: string;

  owner: User;
}
