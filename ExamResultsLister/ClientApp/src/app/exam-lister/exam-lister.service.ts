import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";

import { IExamResult } from './exam-result';


@Injectable({
  providedIn: 'root'
})

export class ExamListerService {

  private examResultUrl = '/examresults';

  constructor(private http: HttpClient) { }

  getExamResults() : Observable<IExamResult[]>{
    return this.http.get<IExamResult[]>(this.examResultUrl).pipe(
      tap(data => console.log(`All: `+JSON.stringify(data))),
      catchError(this.handleError)
    );
  }

  private handleError(err : HttpErrorResponse) {
    let errorMessage = '';
    if(err.error instanceof ErrorEvent){      
      errorMessage = `A client-side or network error occured:${err.error.message}`;
    }else{      
      errorMessage = `The backend returned an unsuccessful response code: ${err.status}, Error message is: ${err.status}`;
    }

    console.error(errorMessage);
    return throwError(errorMessage);
  }
}
