import { IMaterial } from "./material";
import { IItem } from "../items/item";

export interface IItemMaterial {
    itemId: number;
    materialId: number;
    material: IMaterial;
    item: IItem;
}
