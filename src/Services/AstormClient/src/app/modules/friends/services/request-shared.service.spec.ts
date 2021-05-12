import { TestBed } from '@angular/core/testing';

import { RequestSharedService } from './request-shared.service';

describe('RequestSharedService', () => {
  let service: RequestSharedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RequestSharedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
