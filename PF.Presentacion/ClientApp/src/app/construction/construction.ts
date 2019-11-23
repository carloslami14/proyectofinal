import { IItemDetalle } from "../calculation/item-detalle";

export interface IConstruction {
    id?: number;
    name?: string;
    cost: number;
    address: string;
    description: string;
    startDate?: Date;
    createdDate: Date;
    modificationDate: Date;
    endDate?: Date;
    itemsDetalle: IItemDetalle[];
}
