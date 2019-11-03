import { IItemMaterial } from "../materials/itemMaterial";
import { IMaterial } from "../materials/material";

export interface IItem {
    id: number;
    name: string;
    price: number;
    itensMaterials: IItemMaterial[];
    materials: IMaterial[];
}
