import { Component, Inject } from '@angular/core';
import { ExamListerService } from './exam-lister.service';

import { IExamResult } from './exam-result';

@Component({
  selector: 'app-exam-lister',
  templateUrl: './exam-lister.component.html'
})
export class ExamListerComponent {
  public examResults: IExamResult[];

  constructor(private examListService: ExamListerService){    
  }

  ngOnInit() {
    this.examListService.getExamResults().subscribe(
        results => {
            this.examResults = results;
        });
  }
}