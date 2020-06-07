import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ExamListerComponent } from './exam-lister/exam-lister.component';

@NgModule({
  declarations: [
    AppComponent,    
    ExamListerComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,    
    RouterModule.forRoot([
      { path: '', component: ExamListerComponent, pathMatch: 'full' }      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
