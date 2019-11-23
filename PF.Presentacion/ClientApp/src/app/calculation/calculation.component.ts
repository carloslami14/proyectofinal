import { Component, OnInit } from '@angular/core';
import { IItem } from '../items/item';
import { ItemsService } from '../items/items.service';
import { IItemDetalle } from './item-detalle';
import { IConstruction } from '../construction/construction';
import { ConstructionService } from '../construction/construction.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'app-calculation',
    templateUrl: './calculation.component.html',
    styleUrls: ['./calculation.component.css']
})
export class CalculationComponent implements OnInit {

    items: IItem[] = [];
    itemsDetail: IItemDetalle[] = [];
    itemId: number = 0;
    quantity: number = 1;
    total: number = 0;
    construction: IConstruction;
    constructionId: number = 0;

    constructor(private itemsServices: ItemsService,
        private constructionServices: ConstructionService,
        private router: Router,
        private activateRouter: ActivatedRoute) {
        itemsServices.getItems()
            .subscribe(items => this.items = items,
                error => console.error(error));
    }

    ngOnInit() {
        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                return;
            }

            //Create calculation of construction
            this.constructionId = params["id"];
            this.constructionServices.getConstructionById(this.constructionId.toString())
                .subscribe(construction => this.construction = construction,
                    error => console.error(error));
        });
    }

    onSelectItem() {
        let itemDetail: IItemDetalle;

        itemDetail = {
            id: 0,
            itemId: this.itemId,
            item: this.items.find(x => x.id == this.itemId),
            quantity: this.quantity,
        };
        this.itemsDetail.push(itemDetail);
        this.calcular();
    }

    deleteItem(index: number) {
        this.itemsDetail.splice(index, 1);
        this.calcular();
    }

    calcular() {
        this.total = this.itemsDetail.reduce((sum, value) => (sum + value.item.price * value.quantity), 0);
    }

    createCalculation() {
        let construction: IConstruction;
        var array = this.itemsDetail;
        array.forEach(function (element) {
            element.item = undefined;
        });

        //this.constructionService.createConstruction(construction)
        //    .subscribe(() => console.log("Guardado"),
        //        error => console.error(error));
    }
}
