import { Component, OnInit } from '@angular/core';
import { ICategory } from './category';
import { CategoriesService } from './categories.service';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-categories',
    templateUrl: './categories.component.html',
    styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

    // Properties
    categories: ICategory[];

    constructor(private categoriesServices: CategoriesService) { }

    ngOnInit() {
        this.loadData(false);
    }

    deleteFamily(category: ICategory) {
        Swal.fire({
            title: '¿Esta seguro que desea eliminar?',
            text: "No podra deshacer el cambio",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!'
        }).then((result) => {
            if (result.value) {
                this.categoriesServices.deleteCategory(category.id.toString())
                    .subscribe(() => this.loadData(true),
                        error => console.error(error));
            }
        })
    }

    loadData(message: boolean) {
        if (message) {
            Swal.fire(
                'Eliminado!',
                'Esta categoria ha sido eliminada',
                'success'
            )
        }

        this.categoriesServices.getCategories()
            .subscribe(categories => this.categories = categories,
                error => console.error(error));
    }
}
