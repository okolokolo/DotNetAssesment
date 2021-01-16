Steps to run the api

1. Open up the project in visual studio
2. Set the startup project to DotNetAssessmentApi project
3. Run the following commands in the Package Manager Console using the DotNetAssesmentDataContext as Default project
	a. Add-Migration InitialCreate
	b. Update-Database
4. Set the appSettings configuration in the DotNetAssesmentDataContext console application
5. Run the DotNetAssesmentDataContext console application to seed the data. 