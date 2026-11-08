# SimpleMDB – Movie Database Web App

A full-stack movie database web application built in **C# on .NET 8** with a **vanilla HTML/CSS/JavaScript** front end. Users can browse, view, add, edit and delete movies through a web interface that talks to a REST API.

Individual final project for a **Full-Stack Web Development** course at Inter American University of Puerto Rico, Bayamón Campus.

## Features

- **Full CRUD for movies:** list, view, create, update and delete movies.
- **REST API (v1):** JSON endpoints under `/api/v1/movies`.
- **Custom HTTP server and router:** built on top of .NET's HTTP primitives, with route parameters (`/:id`) and nested routers.
- **Middleware pipeline:** structured logging, centralized error handling, CORS headers, query-string and JSON body parsing, and static file serving.
- **Client-side rendered front end:** separate pages for the movie list, movie details, and add/edit forms, using plain HTML, CSS and JavaScript (no frameworks).
- **Layered architecture:** domain logic, API and front end are separate projects, with the repository pattern for data access.

## Architecture

```
Browser (HTML/CSS/JS)  ──HTTP/JSON──▶  Smdb.Api (REST API)  ──▶  Smdb.Core (services + repositories)  ──▶  In-memory database
   served by Smdb.Csr
```

| Project | Role |
|---|---|
| `src/Smdb.Core` | Domain layer: `Movie` and `User` models, services, repository interfaces and in-memory implementations |
| `src/Smdb.Api` | REST API: routers, controllers and middleware configuration |
| `src/Smdb.Csr` | Web server for the client-side rendered front end |
| `SharedLibrary` | Shared HTTP server, router, middleware utilities and result types |
| `wwwroot` | Front-end pages, scripts and styles |

## API endpoints

Base URL: `http://127.0.0.1:5000/api/v1`

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/movies` | List all movies |
| `GET` | `/movies/:id` | Get one movie by ID |
| `POST` | `/movies` | Create a movie |
| `PUT` | `/movies/:id` | Update a movie |
| `DELETE` | `/movies/:id` | Delete a movie |

## Getting started

**Requirements:** [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

```bash
git clone https://github.com/Galito1014/SimpleMDB1.git
cd SimpleMDB1
dotnet run
```

The launcher starts both servers:

- **API:** http://127.0.0.1:5000
- **Web app:** http://127.0.0.1:5001

Press `Ctrl+C` to stop them.

## Tech stack

C# · .NET 8 · REST · JSON · HTML · CSS · JavaScript

## Limitations and next steps

- Data is stored in memory, so it resets every time the server restarts. A next step is a persistent database such as SQLite.
- The project includes a basic authentication service. For production use, passwords should be hashed with a salted, slow algorithm (for example PBKDF2, bcrypt or Argon2) instead of plain SHA-256.
- Automated tests for the API and services would be a good addition.

## Author

**Andrés Gutiérrez** – Cybersecurity student, Inter American University of Puerto Rico  
[GitHub](https://github.com/Galito1014) · [LinkedIn](https://www.linkedin.com/in/andres-gutierrez-aaa13538a/)
