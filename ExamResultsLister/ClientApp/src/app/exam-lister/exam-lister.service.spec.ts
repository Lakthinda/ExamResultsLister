import { TestBed } from '@angular/core/testing';

import { ExamListerService } from './exam-lister.service';

describe('ExamListerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ExamListerService = TestBed.get(ExamListerService);
    expect(service).toBeTruthy();
  });
});
