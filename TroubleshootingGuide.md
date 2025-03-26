# Database Connection Troubleshooting Guide

This guide will help you troubleshoot and resolve connection issues with the SQL Server database.

## Testing Database Connection

I've created a `TestDatabaseConnection.cs` class that can be used to test your database connection independently of the Movie form. To use it:

1. Open `Program.cs`
2. Comment out the current startup line and uncomment the test line:
   ```csharp
   // Uncomment this line to test database connection
   TestDatabaseConnection.RunTest();
   
   // Comment out these lines
   // ApplicationConfiguration.Initialize();
   // Application.Run(new Movie_form());
   ```
3. Run the application
4. The console will show detailed information about the connection attempt

## Common Connection Issues and Solutions

### 1. Incorrect Connection String

The current connection string is:
```
Server=100.102.207.92\cmpt291;Database=MovieRentalDB;User ID=sa;Password=Levitron14;TrustServerCertificate=True;Encrypt=False;
```

Several alternative formats are provided in `Alternative_Connection_Strings.txt`. Try them if the current one doesn't work.

Common connection string issues:
- **Wrong instance name**: If your SQL Server doesn't use a named instance, try removing `\cmpt291`
- **Port issues**: If SQL Server is running on a non-default port, specify it like `100.102.207.92,1433`
- **Authentication mode**: SQL Server must be configured to allow SQL Authentication (not just Windows Authentication)

### 2. SQL Server Configuration Issues

Ensure your SQL Server instance is configured correctly:

- **Remote connections**: SQL Server must allow remote connections
- **SQL Authentication**: SQL Server must allow SQL Authentication mode
- **Firewall**: The firewall on the SQL Server machine must allow connections on port 1433
- **SQL Browser Service**: For named instances, ensure SQL Browser service is running on port 1434
- **Docker configuration**: If using Docker, ensure ports are properly exposed

### 3. Database/Table Creation

If the database or tables don't exist:

1. Connect to your SQL Server using SQL Server Management Studio
2. Run the script in `SQL_scripts/CreateMovieDB.sql` to create the database and tables

### 4. Error Code Reference

- **Error 4060**: Database doesn't exist
- **Error 18456**: Login failed (incorrect username/password or account locked)
- **Error 53 or 10061**: Server not reachable (wrong address, server not running, or firewall blocking)
- **Error 40**: Timeout (server too busy or network issues)
- **Error 26**: Error locating specified instance

## Docker-Specific Tips

If your SQL Server is running in Docker:

1. Ensure port 1433 is exposed:
   ```
   docker ps
   ```
   Look for a mapping like `0.0.0.0:1433->1433/tcp`

2. Check Docker container logs:
   ```
   docker logs [container_name]
   ```
   Look for SQL Server startup messages or errors

3. Try connecting directly to the container:
   ```
   docker exec -it [container_name] /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Levitron14
   ```
   If this works but your application can't connect, it's likely a networking issue

## Testing in SQL Server Management Studio

Test your connection parameters in SQL Server Management Studio:

1. Open SQL Server Management Studio
2. Connect with these settings:
   - Server type: Database Engine
   - Server name: 100.102.207.92\cmpt291 (or alternative format from testing)
   - Authentication: SQL Server Authentication
   - Login: sa
   - Password: Levitron14

If SSMS connects successfully but your application doesn't, there may be an issue with the application's connection parameters or permissions.
