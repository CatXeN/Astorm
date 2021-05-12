import { User } from "./user.model";

export interface AcceptRequest {
  id: string,
  userId: string,
  friendId: string,

  user: User,
  friend: User
}
