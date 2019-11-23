import { Component, OnInit } from '@angular/core';
import { IConstruction } from './construction';
import { ConstructionService } from './construction.service';
import Swal from 'sweetalert2';

@Component({
    selector: 'app-construction',
    templateUrl: './construction.component.html',
    styleUrls: ['./construction.component.css']
})
export class ConstructionComponent implements OnInit {

    // Properties
    constructions: IConstruction[] = [];

    constructor(private constructionServices: ConstructionService) { }

    ngOnInit() {
        this.loadData(false);
    }

    loadData(message: boolean) {
        if (message) {
            Swal.fire(
                'Eliminado!',
                'Esta construccion ha sido eliminada',
                'success'
            )
        }

        this.constructionServices.getConstructions()
            .subscribe(constructions => this.constructions = constructions,
                error => console.log(error));
    }

    deleteConstruction(construnction: IConstruction) {
    }
}
