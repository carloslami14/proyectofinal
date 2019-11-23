import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConstructionFormComponent } from './construction-form.component';

describe('ConstructionFormComponent', () => {
  let component: ConstructionFormComponent;
  let fixture: ComponentFixture<ConstructionFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConstructionFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConstructionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
