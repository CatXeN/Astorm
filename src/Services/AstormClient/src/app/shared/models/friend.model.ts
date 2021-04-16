import { User } from "./user.model";

export interface Friend {
  id: string,
  userid: string,
  friendId: string,

  friend: User
}
