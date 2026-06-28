# Task Management System API

A scalable Task Management REST API built with **ASP.NET Core 9**, following **Clean Architecture** principles.

---

# Features

## Authentication

- Register
- Login
- JWT Authentication

---

## Projects

- Create Project
- Get All Projects
- Get Project By Id
- Update Project
- Delete Project

---

## Tasks

- Create Task
- Get Tasks By Project
- Get Task By Id
- Update Task
- Delete Task

---

# Tech Stack

- ASP.NET Core 9 Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- FluentValidation
- Swagger / OpenAPI

---

# Architecture

The solution follows Clean Architecture.

```
TaskManagementSystem.API
│
├── Controllers
├── Middlewares
│
TaskManagementSystem.Application
│
├── DTOs
├── Interfaces
├── Validators
├── Exceptions
│
TaskManagementSystem.Domain
│
├── Entities
├── Enums
├── Common
│
TaskManagementSystem.Infrastructure
│
├── Persistence
├── Identity
├── Services
├── Configurations
├── Migrations
```

---

# Project Structure

- API Layer
- Application Layer
- Domain Layer
- Infrastructure Layer

Dependency direction:

```
API
 ↓
Application
 ↓
Domain

Infrastructure implements Application interfaces
```

---

# Database

SQL Server

Connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TaskManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

# Run the Project

## 1. Clone Repository

```bash
git clone https://github.com/yourusername/TaskManagementSystem.git
```

---

## 2. Update Database

```bash
Update-Database
```

or

```bash
dotnet ef database update
```

---

## 3. Run

```bash
dotnet run
```

Swagger

```
http://localhost:5266/swagger
```

---

# Authentication

Register

```
POST /api/Auth/register
```

Login

```
POST /api/Auth/login
```

Copy the returned JWT token.

Click **Authorize** in Swagger and enter:

```
Bearer YOUR_TOKEN
```

---

# API Endpoints

## Authentication

| Method | Endpoint |
|---------|----------|
| POST | /api/Auth/register |
| POST | /api/Auth/login |

---

## Projects

| Method | Endpoint |
|---------|----------|
| POST | /api/Projects |
| GET | /api/Projects |
| GET | /api/Projects/{id} |
| PUT | /api/Projects/{id} |
| DELETE | /api/Projects/{id} |

---

## Tasks

| Method | Endpoint |
|---------|----------|
| POST | /api/Tasks |
| GET | /api/Tasks/project/{projectId} |
| GET | /api/Tasks/{id} |
| PUT | /api/Tasks/{id} |
| DELETE | /api/Tasks/{id} |

---

# Validation

Request validation is implemented using **FluentValidation**.

---

# Global Exception Handling

A custom middleware handles application exceptions and returns consistent HTTP responses.

---

# Security

- ASP.NET Identity
- JWT Authentication
- User-based data isolation
- Authorization using `[Authorize]`

---

# Migrations

EF Core migrations are included.

To create a new migration:

```bash
Add-Migration MigrationName
```

Apply migrations:

```bash
Update-Database
```

---

# Author

Ahmed Shawky
Senior .NET Developer
