import { IMaterial } from "../materials/material";

export interface IItem {
    id: number;
    name: string;
    price: number;
    materials: IMaterial[];
    items: IItem[];
}
