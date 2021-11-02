import { User } from "./user.model";

export interface Friend {
  id: string,
  userid: string,
  friendId: string,
  userStatus: number,
  user: User,
  friend: User
}
