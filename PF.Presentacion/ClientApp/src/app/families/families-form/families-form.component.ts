import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IFamily } from '../family';
import { FamiliesService } from '../families.service';
import { Router, ActivatedRoute } from '@angular/router';
import { error } from 'protractor';

@Component({
    selector: 'app-families-form',
    templateUrl: './families-form.component.html',
    styleUrls: ['./families-form.component.css']
})
export class FamiliesFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    editionMode: boolean = false;
    familyId: number;

    constructor(private fb: FormBuilder,
        private familiesServices: FamiliesService,
        private router: Router,
        private activatedRouter: ActivatedRoute) { }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: ''
        });

        this.activatedRouter.params.subscribe(params => {
            if (params['id'] === undefined) {
                // Create Family
                return;
            }

            // Edit Family
            this.editionMode = true;
            this.familyId = params['id'];
            this.familiesServices.getFamilyById(this.familyId.toString())
                .subscribe(family => this.loadForm(family),
                    error => console.error(error));
        });
    }

    loadForm(family: IFamily) {
        this.formGroup.patchValue({
            name: family.name
        });
    }

    save() {
        // Get data of form
        let family: IFamily = Object.assign({}, this.formGroup.value);

        if (this.editionMode) {
            // Edit family
            family.id = this.familyId;
            this.familiesServices.updateFamily(family)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        } else {
            // Create family
            this.familiesServices.createFamily(family)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        }
    }

    onSaveSuccess() {
        this.router.navigate(['/families']);
    }
}
