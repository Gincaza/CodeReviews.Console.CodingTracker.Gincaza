# Coding Time Tracker

A console application for tracking coding sessions with a clean architecture approach.

## Overview

Coding Time Tracker is a .NET console application that allows developers to track their coding sessions by recording start and end times. It provides a simple interface to add, view, update, and delete coding sessions, helping developers monitor their productivity and time management.

## Features

- **Add new coding sessions**: Record when you start and end your coding work
- **View all coding sessions**: See a list of all your recorded coding sessions
- **Delete coding sessions**: Remove unwanted or incorrect session records
- **Update coding sessions**: Modify the details of previously recorded sessions
- **Duration calculation**: Automatic calculation of time spent coding

## Architecture

The application follows a clean architecture approach with separation of concerns:

- **Presentation Layer**: Console UI, user input handling, and validation
- **Business Logic Layer**: Core application logic and domain models
- **Data Access Layer**: Database operations and data persistence
- **Data Classes**: Shared DTOs and entities between layers

### Project Structure

```
CodeReviews.Console.CodingTracker
├── PresentationLayer
│   ├── CodingController.cs
│   ├── UserInput.cs
│   ├── Validation.cs
│   └── appsettings.json
├── BusinessLogicLayer
│   ├── BLLClass.cs
│   ├── ComunicationClasses
│   │   └── OperationResult.cs
│   ├── Configuration
│   │   └── ConfigurationManager.cs
│   ├── DataClasses
│   │   └── CodingSession.cs
│   └── Interfaces
│       └── ICodingSessionRepository.cs
├── DataAccessLayer
│   └── CodingSessionRepository.cs
```

## Technologies

- **.NET 8.0**: Modern .NET framework
- **SQLite**: Lightweight database for local storage
- **Dapper**: Simple ORM for data access
- **Spectre.Console**: Rich console interface with tables and colors

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 or VS Code with C# extension

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/Gincaza/CodeReviews.Console.CodingTracker.Gincaza.git
   ```

2. Navigate to the project directory:
   ```
   cd CodeReviews.Console.CodingTracker
   ```

3. Build the solution:
   ```
   dotnet build
   ```

4. Run the application:
   ```
   dotnet run
   ```

## Usage

After launching the application, you will see a menu with the following options:

1. Add New Coding Session
2. View All Coding Sessions
3. Delete Coding Session
4. Update Coding Session
5. Exit

Use the arrow keys to navigate through the menu and press Enter to select an option.

### Adding a New Coding Session

When adding a new session, you'll be prompted to enter:
- Start date and time
- End date and time

The application will automatically calculate the duration of your session.

### Viewing Sessions

The application displays all your coding sessions in a formatted table showing:
- Session ID
- Start date and time
- End date and time
- Duration

## Acknowledgments

- This project was developed as part of the C# Academy coding exercises
