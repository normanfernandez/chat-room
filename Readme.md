# A simple chatroom application that uses RabbitMQ as broker 🧚

Main chat entities use EF Core InMemory instead of a real working database, so everytime the application starts there will be no message. 2 rooms are created by default this way to allow testing.

For Identity it uses a local Sql Server, using DefaultConnection. Can use ef core migration to create the tables required for Identity. 

Uses default port, guest user and password for connecting to RabbitMQ (localhost).

# Features
- Multiple chatrooms supported
- Command for searching stocks supported (/stock aapl.us)
