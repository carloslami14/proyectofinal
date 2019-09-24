import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IFamily } from './family';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class FamiliesService {

    private apiURL = this.baseUrl + "api/Families";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getFamilies(): Observable<IFamily[]> {
        return this.http.get<IFamily[]>(this.apiURL);
    }

    createFamily(family: IFamily): Observable<IFamily> {
        return this.http.post<IFamily>(this.apiURL, family);
    }

    getFamilyById(familyId: string): Observable<IFamily> {
        return this.http.get<IFamily>(this.apiURL + '/' + familyId);
    }

    updateFamily(family: IFamily): Observable<IFamily> {
        return this.http.put<IFamily>(this.apiURL + '/' + family.id, family);
    }

    deleteFamily(familyId: string) {
        return this.http.delete<IFamily>(this.apiURL + '/' + familyId);
    }
}
