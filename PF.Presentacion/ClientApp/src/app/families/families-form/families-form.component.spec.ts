import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FamiliesFormComponent } from './families-form.component';

describe('FamiliesFormComponent', () => {
  let component: FamiliesFormComponent;
  let fixture: ComponentFixture<FamiliesFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FamiliesFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FamiliesFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
