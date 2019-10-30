import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MaterialsFormComponent } from './materials-form.component';

describe('MaterialsFormComponent', () => {
  let component: MaterialsFormComponent;
  let fixture: ComponentFixture<MaterialsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MaterialsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MaterialsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
