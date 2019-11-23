import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IConstruction } from './construction';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ConstructionService {
    private apiURL = this.baseUrl + "api/Construction";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getConstructions(): Observable<IConstruction[]> {
        return this.http.get<IConstruction[]>(this.apiURL);
    }

    createConstruction(construction: IConstruction): Observable<IConstruction> {
        return this.http.post<IConstruction>(this.apiURL, construction)
    }

    getConstructionById(constructionId: string): Observable<IConstruction> {
        return this.http.get<IConstruction>(this.apiURL + '/' + constructionId);
    }

    updateConstruction(construction: IConstruction): Observable<IConstruction> {
        return this.http.put<IConstruction>(this.apiURL + '/' + construction.id, construction);
    }

    deleteConstruction(constructionId: string) {
        return this.http.delete<IConstruction>(this.apiURL + '/' + constructionId);
    }
}
