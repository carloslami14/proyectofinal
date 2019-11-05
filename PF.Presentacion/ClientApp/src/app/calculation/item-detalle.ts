import { IItem } from "../items/item";
import { IConstruction } from "../construction/construction";


export interface IItemDetalle {
  id?: number;
  contructionId?: number;
  contruction?: IConstruction;
  itemId: number;
  item: IItem;
  quantity: number;
}
