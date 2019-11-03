import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IUnit } from './unit';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class UnitsService {

    private apiURL = this.baseUrl + "api/Units";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getUnits(): Observable<IUnit[]> {
        return this.http.get<IUnit[]>(this.apiURL);
    }

    /* We don´t need it, for now
     * 
    createMaterial(material: IUnit): Observable<IUnit> {
        return this.http.post<IUnit>(this.apiURL, material);
    }

    getMaterialById(materialId: string): Observable<IUnit> {
        return this.http.get<IUnit>(this.apiURL + '/' + materialId);
    }

    updateMaterial(material: IUnit): Observable<IUnit> {
        return this.http.put<IUnit>(this.apiURL + '/' + material.id, material);
    }

    deleteMaterial(materialId: string) {
        return this.http.delete<IUnit>(this.apiURL + '/' + materialId);
    }
    */
}
