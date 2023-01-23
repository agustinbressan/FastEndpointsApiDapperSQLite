# Clients Agenda API
This project is a .NET 7 Minimal Web Api created with the dotnet CLI and modified to implement the FastEndpoints library as a POC.

The app is a CRUD Web Api to manage a basic Client domain entity.
### API Endpoints:

> `GET /clients`\
Get all the existing clients in the database.

> `GET /clients/{id:guid}`\
Get an existing client by Id.

> `POST /clients`\
Create a new client.\
Expected body: `{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string"
}`

> `PUT /clients`\
Update/edit an existing client.\
Expected body: `{
  "id": "string",
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "phone": "string"
}`

> `DELETE /clients/{id:guid}`\
Delete an existing client by Id.

# Libraries used
## FastEndpoints
A developer friendly alternative to Minimal APIs & MVC.\
Used to split and extract the API endpoints in different classes keeping the `Program.cs` file much more cleaner and with less code.\
Links and nuget package:
- https://fast-endpoints.com/
- https://github.com/FastEndpoints/FastEndpoints
- https://www.nuget.org/packages/FastEndpoints/

## FastEndpoints.Swagger
Swagger support for FastEndpoints.\
Used to implement the Swagger UI interface. TODO: Endpoints documentation.\
Links and nuget package:
- https://fast-endpoints.com/docs/swagger-support
- https://www.nuget.org/packages/FastEndpoints.Swagger/

## Dapper
A high performance Micro-ORM.\
Used to manipulate the database using extension methonds and SQL queries.
Links and nuget package:
- https://github.com/DapperLib/Dapper
- https://www.nuget.org/packages/Dapper

## SQLite
A software library that implements a self-contained, serverless, zero-configuration, transactional SQL database engine.\
Used to simplify the data storage in the project.

NOTE: Used the `Microsoft.Data.Sqlite` NuGet package: A lightweight ADO.NET provider for SQLite.

Links and nuget package:
- https://www.sqlite.org/
- https://learn.microsoft.com/es-mx/dotnet/standard/data/sqlite/?tabs=netcore-cli
- https://www.nuget.org/packages/Microsoft.Data.Sqlite.Core



