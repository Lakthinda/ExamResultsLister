# ExamResultLister Angular App
- The ExamResultLister is an Angular and .net core app that is designed
to consume 3rd party API to fetch data.

- The business logic, in this case to sort out passed exams results grouped by 
year are done in .net core layer since Angular (front-end) should 
only contains application logic.

- A seperate .net MVC app is used to communicate with 3rd party API, so 
the frontend will only have to communicate with internal application.

- The ExamResultLister was created using dotnet angular web template.

- ExamResultLister.Test project is created using Moq and NUnit


# ExamResultLister API
- Created using .Net Core Web API template

- RepositoryService is been used to get data, although it is hard-coded for this example, ideally
we can inject DataContext 'ExamRepositoryService' and query database. We can implement different 
repository classes to access data since it implements IRepositoryService without 
changing the underline controller thus without changing the client API calls.

- Use AutoMapper to map Model objects with ViewModel objects. Usually use to map DataContext objects (EF Objects) 
with ViewModel objects.

