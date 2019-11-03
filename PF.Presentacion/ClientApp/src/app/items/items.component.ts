import { Component, OnInit } from '@angular/core';
import { IItem } from './item';
import { ItemsService } from './items.service';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-items',
    templateUrl: './items.component.html',
    styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

    // Properties
    items: IItem[] = [];

    constructor(private itemsServices: ItemsService) { }

    ngOnInit() {
        this.loadData(false);
    }

    deleteItem(item: IItem) {
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
                this.itemsServices.deleteItem(item.id.toString())
                    .subscribe(() => this.loadData(true),
                        error => console.error(error));
            }
        })
    }

    loadData(message: boolean) {
        if (message) {
            Swal.fire(
                'Eliminado!',
                'Este item ha sido eliminado',
                'success'
            )
        }

        this.itemsServices.getItems()
            .subscribe(items => this.items = items,
                error => console.error(error));
    }

    detailsItem(item: IItem) {
        Swal.fire(
            'Show item details',
            'Este item ha sido eliminado',
            'success'
        )
    }
}
