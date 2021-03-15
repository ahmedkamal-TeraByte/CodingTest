This API project is created in .NET 5.0
Pre-requisites:
    .Net SDK 5.0
    MSSQL Server

- Open the solution in Visual studio
- Open Package Manager Console
- Run Command "update-database"
- this will create a database whose connection string is specified in appsettings.json file
- run the API and send HTTP requests in format specified in requirements.
    - {host}/songs/1 to get song with id 1
    - {host}/audiobook/1 to get audiobook with id 1
    
