import { IItemConstruction } from "../calculation/item-construction";

export interface IConstruction {
    id: number;
    name: string;
    cost: number;
    address: string;
    description: string;
    startDate?: Date;
    createdDate: Date;
    modificationDate: Date;
    endDate?: Date;
    items: IItemConstruction[];
}
