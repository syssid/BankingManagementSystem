# BankingManagementSystem

## Overview
BankingManagementSystem is a layered banking application designed using Clean Architecture principles.
It separates concerns into Domain, Application, Infrastructure, API, and UI layers.

## Technology Stack
- C#
- Dotnet 8
- ASP.NET Web API
- .NET Framework
- SQL Server
- Visual Studio 2022

## Solution Structure
- **Bank.Domain**  
  Core business entities and rules.

- **Bank.Application**  
  Application logic and service interfaces.

- **Bank.Infrastructure**  
  Database access and external integrations.

- **Bank.API**  
  RESTful APIs for client applications.

- **Bank.UI**  
  User interface layer.

## Architecture Flow
UI / API → Application → Domain  
Infrastructure → Application / Domain

## How to Run
1. Open `BankingManagementSystem.sln` in Visual Studio 2015
2. Restore NuGet packages
3. Set `Bank.API` and `Bank.UI`as Multi Startup Project
4. Update database connection string
5. Run the application

## Future Enhancements
- Authentication & Authorization
- Transaction history
- Logging and exception handling
