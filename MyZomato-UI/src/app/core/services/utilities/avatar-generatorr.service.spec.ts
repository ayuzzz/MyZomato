import { TestBed } from '@angular/core/testing';

import { AvatarGeneratorrService } from './avatar-generatorr.service';

describe('AvatarGeneratorrService', () => {
  let service: AvatarGeneratorrService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvatarGeneratorrService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
