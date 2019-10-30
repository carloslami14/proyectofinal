import { IFamily } from "../families/family";

export interface ICategory {
    id: number;
    name: string;
    familyId: number;
    famlily: IFamily;
}
