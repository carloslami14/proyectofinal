import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CategoriesService } from '../categories.service';
import { FamiliesService } from '../../families/families.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IFamily } from '../../families/family';
import { ICategory } from '../category';

@Component({
    selector: 'app-categories-form',
    templateUrl: './categories-form.component.html',
    styleUrls: ['./categories-form.component.css']
})
export class CategoriesFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    families: IFamily[] = [];
    editionMode: boolean = false;
    familyId: number;
    categoryId: number;

    constructor(private fb: FormBuilder,
        private categoriesServices: CategoriesService,
        private familiesServices: FamiliesService,
        private router: Router,
        private activateRouter: ActivatedRoute) {
        familiesServices.getFamilies()
            .subscribe(families => this.families = families,
                error => console.error(error));
    }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            familyId: '0'
        });

        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                //Create Category
                return;
            }

            //Edit Category
            this.editionMode = true;
            this.categoryId = params["id"];
            this.categoriesServices.getCategoryById(this.categoryId.toString())
                .subscribe(category => this.loadForm(category),
                    error => console.error(error));
        });
    }

    loadForm(category: ICategory) {
        this.formGroup.patchValue({
            name: category.name
        });
        this.familyId = category.familyId;
    }

    onSelectFamily(familyId: number) {
        this.familyId = familyId;
    }

    save() {
        // Get data of form
        let category: ICategory = Object.assign({}, this.formGroup.value);
        category.familyId = this.familyId;

        if (this.editionMode) {
            // Edit Category
            category.id = this.categoryId;
            this.categoriesServices.updateCategory(category)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        } else {
            // Create Category
            this.categoriesServices.createCategory(category)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        }
    }

    onSaveSuccess() {
        this.router.navigate(['/categories']);
    }
}
