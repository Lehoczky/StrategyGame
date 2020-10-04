/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AttackService } from './attack.service';

describe('Service: Attack', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AttackService]
    });
  });

  it('should ...', inject([AttackService], (service: AttackService) => {
    expect(service).toBeTruthy();
  }));
});
