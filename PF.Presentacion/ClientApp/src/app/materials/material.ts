import { ICategory } from "../categories/category";

export interface IMaterial {
    id: number;
    name: string;
    price: number;
    unit: number;
    categoryId: number;
    category: ICategory;
}
