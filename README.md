# Task Management System API

A scalable Task Management REST API built with ASP.NET Core 9 following Clean Architecture principles.

---

## Tech Stack

- ASP.NET Core 9 Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- FluentValidation
- Swagger / OpenAPI

---

## Architecture

The solution follows Clean Architecture and is divided into four projects:

```
TaskManagementSystem.API
TaskManagementSystem.Application
TaskManagementSystem.Domain
TaskManagementSystem.Infrastructure
```

### Layers

- API
- Application
- Domain
- Infrastructure

---

## Features

### Authentication

- Register
- Login (JWT)

### Projects

- Create Project
- Get All Projects
- Get Project By Id
- Update Project
- Delete Project

### Tasks

- Create Task
- Get Tasks By Project
- Get Task By Id
- Update Task
- Delete Task

---

## Validation

Implemented using FluentValidation.

---

## Exception Handling

Global Exception Handling Middleware is used to provide consistent error responses.

---

## Authentication

JWT Bearer Authentication is used to secure the API.

---

## Database

SQL Server with Entity Framework Core Code First.

Run the following commands:

```bash
dotnet ef database update
```

---

## Run

```bash
dotnet restore

dotnet build

dotnet run
```

Swagger:

```
http://localhost:5266/swagger
```

---

## Project Structure

```
TaskManagementSystem.API
TaskManagementSystem.Application
TaskManagementSystem.Domain
TaskManagementSystem.Infrastructure
```

---

## Author

Ahmed Shawky
