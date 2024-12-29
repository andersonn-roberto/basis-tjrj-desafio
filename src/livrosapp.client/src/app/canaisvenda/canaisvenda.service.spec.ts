import { TestBed } from '@angular/core/testing';

import { CanaisvendaService } from './canaisvenda.service';

describe('CanaisvendaService', () => {
  let service: CanaisvendaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CanaisvendaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
