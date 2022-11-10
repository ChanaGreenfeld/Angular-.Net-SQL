import { TestBed } from '@angular/core/testing';

import { ShoppingbagService } from './shoppingbag.service';

describe('ShoppingbagService', () => {
  let service: ShoppingbagService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShoppingbagService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
