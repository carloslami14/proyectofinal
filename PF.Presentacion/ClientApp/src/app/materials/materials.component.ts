import { Component, OnInit } from '@angular/core';
import { IMaterial } from './material';
import { MaterialsService } from './materials.service';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-materials',
    templateUrl: './materials.component.html',
    styleUrls: ['./materials.component.css']
})
export class MaterialsComponent implements OnInit {

    // Properties
    materials: IMaterial[] = [];

    constructor(private materialsServices: MaterialsService) { }

    ngOnInit() {
        this.loadData(false);
    }

    deleteMaterial(material: IMaterial) {
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
                this.materialsServices.deleteMaterial(material.id.toString())
                    .subscribe(() => this.loadData(true),
                        error => console.error(error));
            }
        })
    }

    loadData(message: boolean) {
        if (message) {
            Swal.fire(
                'Eliminado!',
                'Este material ha sido eliminada',
                'success'
            )
        }

        this.materialsServices.getMaterials()
            .subscribe(materials => this.materials = materials,
                error => console.error(error));
    }
}
