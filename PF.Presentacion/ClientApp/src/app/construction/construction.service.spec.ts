import { TestBed } from '@angular/core/testing';

import { ConstructionService } from './construction.service';

describe('ConstructionService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ConstructionService = TestBed.get(ConstructionService);
    expect(service).toBeTruthy();
  });
});
