import { ICategory } from "../categories/category";
import { IUnit } from "../units/unit";

export interface IMaterial {
    id: number;
    name: string;
    price: number;
    unitId: number;
    unit: IUnit;
    categoryId: number;
    category: ICategory;
}
