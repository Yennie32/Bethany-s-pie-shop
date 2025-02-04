# Bethany-s-pie-shop

**WITH VSCODE**
.net tutorial

Project Template = Empty
npm install bootstrap jquery --save

Packages installed with command line:

- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore.Tools
- dotnet restore to complete
- dotnet build to generates files to execute app
- dotnet run to launch app

Migrations:

- dotnet tool install --global dotnet-ef
- dotnet ef migrations add InitialCreate = 'commit' the migration
- dotnet ef database update = applies the migration
- To undo this action, use 'ef migrations remove'
  Add connection string to appsettings.json

Add to fornavigation with tag helpers in View Imports
@addTagHelper \*, Microsoft.AspNetCore.Mvc.TagHelpers
