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
    materials: IItemMaterial[] = [];
    materialsComboBox: IMaterial[] = [];
    materialId: number = 0;
    price: number = 0;
    quantity: number = 1;

    constructor(private itemsServices: ItemsService,
        private materialsServices: MaterialsService,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private fb: FormBuilder) {
        materialsServices.getMaterials()
            .subscribe(materials => this.materialsComboBox = materials,
                error => console.error(error));
    }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            price: '0',
            materialId: '0',
            quantity: '1'
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
            quantity: '1',
            materialId: '0'
        });
        this.price = item.price;
        this.materials = item.itemsMaterials;
    }

    onSelectMaterial(materialId: number) {
        this.materialId = materialId;
    }

    removeMaterial(i: number) {
        this.materials.splice(i, 1);
        this.calculateTotal();
    }

    addMaterial() {
        if (this.materialId > 0) {
            let m = this.materialsComboBox.find(m => m.id == this.materialId);
            let itemMaterial: IItemMaterial = {
                materialId: m.id,
                material: m,
                quantity: (this.quantity === null || this.quantity === 0)  ? 1 : this.quantity,
                itemId: 0,
                item: null
            }

            this.materials.push(itemMaterial);
            this.calculateTotal();
        }
    }

    calculateTotal() {
        this.price = this.materials.reduce((sum, current) => sum + (current.quantity * current.material.price), 0);
    }

    save() {
        // Get data of form
        let item: IItem = Object.assign({}, this.formGroup.value);
        item.itemsMaterials = this.materials;
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
