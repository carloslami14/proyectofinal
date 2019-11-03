import { Component, OnInit } from '@angular/core';
import { ItemsService } from '../items.service';
import { MaterialsService } from '../../materials/materials.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IMaterial } from '../../materials/material';
import { IItem } from '../item';
import { IItemMaterial } from '../../materials/itemMaterial';

@Component({
    selector: 'app-items-form',
    templateUrl: './items-form.component.html',
    styleUrls: ['./items-form.component.css']
})
export class ItemsFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    editionMode: boolean = false;
    itemId: number;
    materials: IMaterial[] = [];
    selectedMaterials: IMaterial[] = [];
    materialId: number;
    price: number = 0;

    constructor(private itemsServices: ItemsService,
        private materialsServices: MaterialsService,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private fb: FormBuilder) {
        materialsServices.getMaterials()
            .subscribe(materials => this.materials = materials,
                error => console.error(error));
    }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            price: '0'
        });

        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                //Create Item
                return;
            }

            //Edit Item
            this.editionMode = true;
            this.itemId = params["id"];
            this.itemsServices.getItemById(this.itemId.toString())
                .subscribe(item => this.loadForm(item),
                    error => console.error(error));
        });
    }

    loadForm(item: IItem) {
        this.formGroup.patchValue({
            name: item.name,
        });
        this.price = item.price;
        this.selectedMaterials = item.materials;
    }

    onSelectMaterial(materialId: number) {
        this.materialId = materialId;
    }

    removeMaterial(i: number) {
        this.price -= this.selectedMaterials[i].price;
        this.selectedMaterials.splice(i, 1);
    }

    addMaterial() {
        if (this.materialId > 0) {
            let m = this.materials.find(m => m.id == this.materialId);
            this.selectedMaterials.push(m);
            this.price += m.price;
        }
    }

    save() {
        // Get data of form
        let item: IItem = Object.assign({}, this.formGroup.value);
        let itemMaterials: IItemMaterial[] = [];
        item.materials = this.selectedMaterials;
        item.price = this.price;

        if (this.editionMode) {
            // Edit Item
            item.id = this.itemId;
            this.itemsServices.updateItem(item)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        } else {
            // Create Item
            this.itemsServices.createItem(item)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        }
    }

    onSaveSuccess() {
        this.router.navigate(['/items']);
    }
}
