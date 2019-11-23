import { IItem } from "../items/item";
import { IConstruction } from "../construction/construction";


export interface IItemConstruction {
  constructionId: number;
  construction: IConstruction;
  itemId: number;
  item: IItem;
  quantity: number;
}
