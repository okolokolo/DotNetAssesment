Steps to run the api

1. Open up the project in visual studio
2. Set the startup project to DotNetAssessmentApi project
3. Run the following commands in the Package Manager Console using the DotNetAssesmentDataContext as Default project
	a. Add-Migration InitialCreate
	b. Update-Database
4. In both appSettings files, in the DataContext console and api applications, set the default connections to the file path of the generated sqlite database.
5. Run the DotNetAssesmentDataContext console application to seed the data. 
6. Set the Startup project back to the api and run the api to test the routes
7. Run the tests in the test project