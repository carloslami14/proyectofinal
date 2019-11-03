import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoriesService } from '../../categories/categories.service';
import { MaterialsService } from '../materials.service';
import { ICategory } from '../../categories/category';
import { Router, ActivatedRoute } from '@angular/router';
import { IMaterial } from '../material';
import { IUnit } from '../../units/unit';
import { UnitsService } from '../../units/units.service';
import { error } from '@angular/compiler/src/util';
import { IFamily } from '../../families/family';
import { FamiliesService } from '../../families/families.service';

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
    families: IFamily[] = []
    familyId: number;
    categories: ICategory[] = [];
    categoryId: number;
    categoriesFiltered: ICategory[] = [];
    units: IUnit[] = [];
    unitId: number;


    constructor(private categoriesServices: CategoriesService,
        private materialsServices: MaterialsService,
        private unitsServices: UnitsService,
        private familiesServices: FamiliesService,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private fb: FormBuilder) {
        familiesServices.getFamilies()
            .subscribe(families => this.families = families,
                error => console.log(error));

        categoriesServices.getCategories()
            .subscribe(categories => this.categories = this.categoriesFiltered = categories,
                error => console.error(error));

        unitsServices.getUnits()
            .subscribe(units => this.units = units,
                error => console.log(error));
    }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            price: '0',
            unitId: '0',
            categoryId: '0',
            familyId: '0'
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
        this.familyId = material.category.familyId;
        this.categoriesFiltered = this.categories.filter(c => c.familyId == this.familyId);
        this.categoryId = material.categoryId;
        this.unitId = material.unitId;
    }

    onSelectUnit(unitId: number) {
        this.unitId = unitId;
    }

    onSelectFamily(familyId: number) {
        this.familyId = familyId;
        this.categoriesFiltered = this.categories.filter(c => c.familyId == familyId);
    }

    onSelectCategory(categoryId: number) {
        this.categoryId = categoryId;
    }

    save() {
        // Get data of form
        let material: IMaterial = Object.assign({}, this.formGroup.value);
        material.categoryId = this.categoryId;
        material.unitId = this.unitId;

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
