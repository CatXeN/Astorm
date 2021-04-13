import { Attribute } from "./attribute.model";

export interface Register {
  username: string,
  password: string,
  attributes: Attribute[]
}
