import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { IFamily } from '../family';
import { FamiliesService } from '../families.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-families-form',
  templateUrl: './families-form.component.html',
  styleUrls: ['./families-form.component.css']
})
export class FamiliesFormComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private familiesServices: FamiliesService,
    private router: Router) { }

  formGroup: FormGroup;

  ngOnInit() {
    this.formGroup = this.fb.group({
      name: ''
    });
  }

  save(){
    let family: IFamily = Object.assign({}, this.formGroup.value);

    this.familiesServices.createFamily(family)
      .subscribe(family => this.onSaveSuccess(),
      error => console.error(error));
  }

  onSaveSuccess(){
    this.router.navigate(['/families']);
  }  
}
