import { IItemDetalle } from "../calculation/item-detalle";

export interface IConstruction {
  id?: number;
  name?: string;
  cost: number;
  startDate?: Date;
  endDate?: Date;
  itemsDetalle: IItemDetalle[];
}
