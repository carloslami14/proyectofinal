import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';
import { IItem } from './item';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemsService {

    private apiURL = this.baseUrl + "api/Items";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getItems(): Observable<IItem[]> {
        return this.http.get<IItem[]>(this.apiURL);
    }

    createItem(item: IItem): Observable<IItem> {
        return this.http.post<IItem>(this.apiURL, item);
    }

    getItemById(itemId: string): Observable<IItem> {
        return this.http.get<IItem>(this.apiURL + '/' + itemId);
    }

    updateItem(item: IItem): Observable<IItem> {
        return this.http.put<IItem>(this.apiURL + '/' + item.id, item);
    }

    deleteItem(itemId: string) {
        return this.http.delete<IItem>(this.apiURL + '/' + itemId);
    }
}
