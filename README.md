# ASP.NET Core CiberNiteco
## Technologies
- ASP.NET
- Entity Framework
## Install Packages
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.InMemory
- FluentValidation.AspNetCore
- Newtonsoft.Json
## How to configure run
- Open solution CiberNiteco.sln in Visual Studio 2019
- Set startup project is CiberNiteco.Entities
- Change connection string in Appsetting.json in CiberNiteco.Entities project
- Open Tools --> Nuget Package Manager --> Package Manager Console in Visual Studio
- Run Update-database and Enter.
- Change database connection in appsettings.Development.json in CiberNiteco.AdminWeb.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 2 Projects: CiberNiteco.Api, CiberNiteco.AdminWeb
## How to contribute
