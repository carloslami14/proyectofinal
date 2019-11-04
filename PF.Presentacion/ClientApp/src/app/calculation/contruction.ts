import { IItemDetalle } from "./item-detalle";

export interface IContruction {
  id: number;
  name: string;
  cost: number;
  startDate: Date;
  endDate: Date;
  itemsDetalle: IItemDetalle[];
}
