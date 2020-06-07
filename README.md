#ExamResultLister Angular App
- The ExamResultLister is an Angular and .net core app that is designed
to consume 3rd party API to get data.

- The business logic, in this case to sort out passed exams results grouped by 
year are done in .net core layer since Angular (front-end) should 
only contains application logic (how data are displayed).

- A seperate .net MVC app is used to communicate with 3rd party API, so 
the frontend will only have to communicate with internal application.

- The ExamResultLister was created using dotnet angular web template.
