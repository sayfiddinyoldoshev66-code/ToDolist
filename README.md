# ToDoList API

A RESTful task-management API built with **C#**, **ASP.NET Core Web API**, **Entity Framework Core**, and **SQLite**.

## Features

- Create a task
- Get all tasks
- Get a task by its ID
- Update a task
- Delete a task
- Request validation with Data Annotations
- SQLite persistence through Entity Framework Core
- Asynchronous database operations
- Clear HTTP responses (201, 204, 400, 404)

## Tech stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- C#

## Getting started

### Prerequisites

- .NET 10 SDK

### Run locally

1. Clone the repository:

   ```bash
   git clone https://github.com/sayfiddinyoldoshev66-code/ToDolist.git
   cd ToDolist
   ```

2. Restore packages:

   ```bash
   dotnet restore
   ```

3. Run the API:

   ```bash
   dotnet run --project ToDolist/ToDolist.csproj
   ```

The SQLite database file (`todo.db`) is created automatically on first startup.

In Development, the OpenAPI document is available at `/openapi/v1.json`.

## API endpoints

Base route: `/api/TodoItems`

| Method | Endpoint | Description |
| --- | --- | --- |
| GET | `/api/TodoItems` | Get all tasks |
| GET | `/api/TodoItems/{id}` | Get one task |
| POST | `/api/TodoItems` | Create a task |
| PUT | `/api/TodoItems/{id}` | Update a task |
| DELETE | `/api/TodoItems/{id}` | Delete a task |

### Create task example

```http
POST /api/TodoItems
Content-Type: application/json

{
  "title": "Learn ASP.NET Core",
  "description": "Build a REST API with EF Core"
}
```

### Update task example

```http
PUT /api/TodoItems/1
Content-Type: application/json

{
  "title": "Learn ASP.NET Core",
  "description": "Finish the CRUD API",
  "isCompleted": true
}
```

## Project structure

```text
ToDolist/
├── Controllers/
│   └── TodoItemsController.cs
├── Data/
│   └── AppDbContext.cs
├── DTOs/
│   ├── CreateTodoRequest.cs
│   └── UpdateTodoRequest.cs
├── Models/
│   └── TodoItem.cs
├── Program.cs
└── ToDolist.csproj
```

## Author

**Xumoyun Sayfutdinov**

Aspiring .NET Backend Developer
