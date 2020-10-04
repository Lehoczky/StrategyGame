/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { UpgradeService } from './upgrade.service';

describe('Service: Upgrade', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [UpgradeService]
    });
  });

  it('should ...', inject([UpgradeService], (service: UpgradeService) => {
    expect(service).toBeTruthy();
  }));
});
