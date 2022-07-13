# A simple chatroom application that uses RabbitMQ as broker 🧚

Main chat entities use EF Core InMemory instead of a real working database, so everytime the application starts there will be no message. 2 rooms are created by default this way to allow testing.

For Identity it uses a local Sql Server, using DefaultConnection. Can use ef core migration to create the tables required for Identity. 

Uses default port, guest user and password for connecting to RabbitMQ (localhost).

# Features
- Multiple chatrooms supported
- Command for searching stocks supported (/stock aapl.us)

# Using Docker for RabbitMQ and local SQL Server

RabbitMQ
```bash
docker run -d -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

Sql Server
```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPassword123@" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

For Sql Server Create a database and then use EF Core migrations to create de Identity tables.
(MSDN Sample: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-6.0&tabs=netcore-cli)

```bash
cd Chat-Room.App
dotnet ef migrations add CreateIdentitySchema -c ApplicationDbContext
dotnet ef database update -c ApplicationDbContext
```
