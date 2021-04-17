import { User } from "./user.model";

export interface Message {
  ownerId: string;
  recipentId: string;
  content: string;
  sendMessageDate: string;

  owner: User;
}
