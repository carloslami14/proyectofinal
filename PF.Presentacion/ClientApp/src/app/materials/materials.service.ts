import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IMaterial } from './material';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MaterialsService {

    private apiURL = this.baseUrl + "api/Materials";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getMaterials(): Observable<IMaterial[]> {
        return this.http.get<IMaterial[]>(this.apiURL);
    }

    createMaterial(material: IMaterial): Observable<IMaterial> {
        return this.http.post<IMaterial>(this.apiURL, material);
    }

    getMaterialById(materialId: string): Observable<IMaterial> {
        return this.http.get<IMaterial>(this.apiURL + '/' + materialId);
    }

    updateMaterial(material: IMaterial): Observable<IMaterial> {
        return this.http.put<IMaterial>(this.apiURL + '/' + material.id, material);
    }

    deleteMaterial(materialId: string) {
        return this.http.delete<IMaterial>(this.apiURL + '/' + materialId);
    }
}
