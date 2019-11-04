import { IItem } from "../items/item";
import { IContruction } from "./contruction";

export interface IItemDetalle {
  id: number;
  contructionId: number;
  contruction: IContruction;
  itemId: number;
  item: IItem;
  quantity: number;
}
