import { TestBed } from '@angular/core/testing';

import { WaterfeatureService } from './waterfeature.service';

describe('WaterfeatureService', () => {
  let service: WaterfeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WaterfeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
