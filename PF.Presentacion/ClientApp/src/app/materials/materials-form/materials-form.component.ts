import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoriesService } from '../../categories/categories.service';
import { MaterialsService } from '../materials.service';
import { ICategory } from '../../categories/category';
import { error } from '@angular/compiler/src/util';
import { Router, ActivatedRoute } from '@angular/router';
import { IMaterial } from '../material';
import { IUnitEnum } from '../../enums/unit';

@Component({
    selector: 'app-materials-form',
    templateUrl: './materials-form.component.html',
    styleUrls: ['./materials-form.component.css']
})
export class MaterialsFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    editionMode: boolean = false;
    materialId: number;
    categories: ICategory[] = [];
    categoryId: number;
    //units: IUnitEnum;
    //unitId: number;

    constructor(private categoriesServices: CategoriesService,
        private materialsServices: MaterialsService,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private fb: FormBuilder) {
        categoriesServices.getCategories()
            .subscribe(categories => this.categories = categories,
                error => console.error(error));
    }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            price: '0',
            //unit: '0',
            categoryId: '0'
        });

        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                //Create Material
                return;
            }

            //Edit Material
            this.editionMode = true;
            this.materialId = params["id"];
            this.materialsServices.getMaterialById(this.materialId.toString())
                .subscribe(material => this.loadForm(material),
                    error => console.error(error));
        });
    }

    loadForm(material: IMaterial) {
        this.formGroup.patchValue({
            name: material.name,
            price: material.price,
        });
        this.categoryId = material.categoryId;
    }

    onSelectCategory(categoryId: number) {
        this.categoryId = categoryId;
    }

    //onSelectUnit(unitId: number) {
    //    this.unitId = unitId;
    //}

    save() {
        // Get data of form
        let material: IMaterial = Object.assign({}, this.formGroup.value);
        material.categoryId = this.categoryId;

        if (this.editionMode) {
            // Edit Material
            material.id = this.materialId;
            this.materialsServices.updateMaterial(material)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        } else {
            // Create Material
            this.materialsServices.createMaterial(material)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        }
    }

    onSaveSuccess() {
        this.router.navigate(['/materials']);
    }
}
