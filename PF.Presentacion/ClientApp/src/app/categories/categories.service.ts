import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICategory } from './category';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
    private apiURL = this.baseUrl + "api/Categories";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

    getCategories(): Observable<ICategory[]> {
        return this.http.get<ICategory[]>(this.apiURL);
    }

    createCategory(category: ICategory): Observable<ICategory> {
        return this.http.post<ICategory>(this.apiURL, category);
    }

    getCategoryById(categoryId: string): Observable<ICategory> {
        return this.http.get<ICategory>(this.apiURL + '/' + categoryId);
    }

    updateCategory(category: ICategory): Observable<ICategory> {
        return this.http.put<ICategory>(this.apiURL + '/' + category.id, category);
    }

    deleteCategory(categoryId: string) {
        return this.http.delete<ICategory>(this.apiURL + '/' + categoryId);
    }
}
