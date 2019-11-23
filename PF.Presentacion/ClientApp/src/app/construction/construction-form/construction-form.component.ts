import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ConstructionService } from '../construction.service';
import { IConstruction } from '../construction';
import { DatePipe } from '@angular/common';

@Component({
    selector: 'app-construction-form',
    templateUrl: './construction-form.component.html',
    styleUrls: ['./construction-form.component.css']
})
export class ConstructionFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    editionMode: boolean = false;
    constructionId: number;

    constructor(private fb: FormBuilder,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private constructionServices: ConstructionService,
        public datepipe: DatePipe) { }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: '',
            endDate: '',
            startDate: '',
            address: '',
            description: ''
        });

        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                //Create Construction
                return;
            }

            //Edit Construction
            this.editionMode = true;
            this.constructionId = params["id"];
            this.constructionServices.getConstructionById(this.constructionId.toString())
                .subscribe(construction => this.loadForm(construction),
                    error => console.error(error));
        });
    }

    loadForm(construction: IConstruction) {
        this.formGroup.patchValue({
            name: construction.name,
            endDate: this.datepipe.transform(construction.endDate, 'yyyy-MM-dd'),
            startDate: this.datepipe.transform(construction.startDate, 'yyyy-MM-dd'),
            address: construction.address,
            description: construction.description
        });
    }

    save() {
        // Get data of form
        let construction: IConstruction = Object.assign({}, this.formGroup.value);

        if (this.editionMode) {
            // Edit Construction
            construction.id = this.constructionId;
            this.constructionServices.updateConstruction(construction)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        } else {
            // Create Construction
            this.constructionServices.createConstruction(construction)
                .subscribe(() => this.onSaveSuccess(),
                    error => console.error(error));
        }
    }

    onSaveSuccess() {
        this.router.navigate(['/construction']);
    }
}

@Component({
    selector: 'app-construction-form',
    templateUrl: './construction-detail-form.component.html',
    styleUrls: ['./construction-form.component.css']
})
export class ConstructionDetailFormComponent implements OnInit {

    // Properties
    formGroup: FormGroup;
    constructionId: number;
    construction: IConstruction;
    constructionName: string;

    constructor(private fb: FormBuilder,
        private router: Router,
        private activateRouter: ActivatedRoute,
        private constructionServices: ConstructionService,
        public datepipe: DatePipe) { }

    ngOnInit() {
        this.formGroup = this.fb.group({
            name: new FormControl({ value: '', disabled: true }),
            createdDate: new FormControl({ value: '', disabled: true }),
            endDate: new FormControl({ value: '', disabled: true }),
            startDate: new FormControl({ value: '', disabled: true }),
            address: new FormControl({ value: '', disabled: true }),
            description: new FormControl({ value: '', disabled: true })
        });

        this.activateRouter.params.subscribe(params => {
            if (params["id"] === undefined) {
                //Create construction
                return;
            }

            //Edit construction
            this.constructionId = params["id"];
            this.constructionServices.getConstructionById(this.constructionId.toString())
                .subscribe(construction => this.loadForm(construction),
                    error => console.error(error));
        });
    }

    loadForm(construction: IConstruction) {
        this.formGroup.patchValue({
            createdDate: this.datepipe.transform(construction.createdDate, 'yyyy-MM-dd'),
            endDate: this.datepipe.transform(construction.endDate, 'yyyy-MM-dd'),
            startDate: this.datepipe.transform(construction.startDate, 'yyyy-MM-dd'),
            address: construction.address,
            description: construction.description
        });
        this.constructionName = construction.name;
    }
}
