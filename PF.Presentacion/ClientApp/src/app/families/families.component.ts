import { Component, OnInit } from '@angular/core';
import { FamiliesService } from './families.service';
import { IFamily } from './family';
import { error } from '@angular/compiler/src/util';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-families',
  templateUrl: './families.component.html',
  styleUrls: ['./families.component.css']
})
export class FamiliesComponent implements OnInit {
    // Properties
    families: IFamily[] = [];

    constructor(private familiesServices: FamiliesService) { }

    ngOnInit() {
        this.loadData(false);
    }

    deleteFamily(family: IFamily) {
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
                this.familiesServices.deleteFamily(family.id.toString())
                    .subscribe(() => this.loadData(true),
                        error => console.error(error));
            }
        })
    }

    loadData(message: boolean) {
        if (message) {
            Swal.fire(
                'Eliminado!',
                'Esta familia ha sido eliminada',
                'success'
            )
        }

        this.familiesServices.getFamilies()
            .subscribe(families => this.families = families,
                error => console.error(error));
    }
}
