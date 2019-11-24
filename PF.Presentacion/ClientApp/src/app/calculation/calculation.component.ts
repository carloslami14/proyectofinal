import { Component, OnInit } from '@angular/core';
import { IItem } from '../items/item';
import { ItemsService } from '../items/items.service';
import { IItemConstruction } from './item-construction';
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
    itemsContructions: IItemConstruction[] = [];
    itemId: number = 0;
    quantity: number = 1;
    total: number = 0;
    construction: IConstruction;
    constructionId: number = 0;
    flag: boolean = true;

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
                .subscribe(construction => this.loadForm(construction),
                    error => console.error(error));
        });
    }

    loadForm(construction: IConstruction) {
        this.construction = construction;
        this.total = construction.cost;
    }

    onSelectItem() {
        let itemConstruction: IItemConstruction;

        itemConstruction = {
            itemId: this.itemId,
            item: this.items.find(x => x.id == this.itemId),
            constructionId: this.constructionId,
            construction: this.construction,
            quantity: this.quantity,
        };

        this.construction.items.push(itemConstruction);
        this.calcular();
    }

    deleteItem(index: number) {
        this.construction.items.splice(index, 1);
        this.calcular();
    }

    calcular() {
        this.flag = !(this.construction.items.length > 0);
        this.total = this.construction.items.reduce((sum, value) => (sum + value.item.price * value.quantity), 0);
    }

    createCalculation() {
        console.log(this.construction);
        console.log(this.constructionId);
        let construction = { ...this.construction }

        construction.items.forEach(function (i) {
            i.item = undefined;
            i.construction = undefined;
        });
        construction.cost = this.total;

        this.constructionServices.updateConstruction(construction)
            .subscribe(() => this.onSaveSuccess(),
                error => console.error(error));
    }

    onSaveSuccess() {
        this.router.navigate(['/construction-detail/' + this.constructionId]);
    }
}
