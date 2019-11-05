import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IConstruction } from './construction';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConstructionService {
  private apiURL = this.baseUrl + "api/Construction";

  constructor(private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) { }


  createConstruction(construction: IConstruction): Observable<IConstruction>{
    return this.http.post<IConstruction>(this.apiURL,construction)
  }
}
