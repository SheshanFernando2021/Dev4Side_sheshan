
# 📝 Task Board API – Full-Stack Developer Assignment 🚀

Welcome to the **Task Board API**, a simplified task management backend inspired by Trello and Todo apps.  
This project was built as part of a **Full-Stack Developer technical assessment**, demonstrating my skills in API design, JWT authentication, database interaction, and clean architecture.

---

## 🔍 Project Overview

The **Task Board API** enables users to manage personal tasks divided into lists. Each task includes:
- ✅ Title
- 📝 Description
- 📅 Due Date
- 🔄 Status (`To Do`, `In Progress`, `Completed`)

---

## 🛠️ Tech Stack & Tools

### Backend
| Language/Framework | Description |
|--------------------|-------------|
| ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white) | Main programming language |
| ![ASP.NET Core](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) | Framework for REST API |
| ![Entity Framework Core](https://img.shields.io/badge/EF%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white) | ORM for database operations |
| ![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white) | Relational database |
| ![JWT](https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white) | JSON Web Token-based authentication |

---

## 🔒 Authentication

🔑 The API implements **JWT authentication** to protect all endpoints.  
Users must log in to obtain a token and pass it in the `Authorization: Bearer <token>` header for secured requests.

---

## 📡 API Endpoints

### 🗂️ Lists
| Method | Route | Description |
|------|-------------|----------------------------|
| GET   | `/lists`    | Get all lists for the authenticated user |
| POST  | `/lists`    | Create a new list |
| DELETE| `/lists/{id}` | Delete a specific list |

### ✅ Tasks
| Method | Route | Description |
|------|----------------------|-----------------------------------------|
| GET   | `/tasks?listId={}`   | Get all tasks in a list |
| POST  | `/tasks`             | Create a new task |
| PUT   | `/tasks/{id}`        | Update a task (status, description, due date) |
| DELETE| `/tasks/{id}`        | Delete a specific task |

---

## 🧑‍💻 Architecture

```
Controllers → Services → Repos → Data (EF Core) → Database
```

🔹 Follows the **Clean Architecture** principle to maintain separation of concerns.  
🔹 Data access is managed through **Entity Framework Core**.

---

## ⚙️ Setup & Run the API

### 1. 🔃 Clone the Repository
```bash
[git clone https://github.com/your-username/task-board-api.git](https://github.com/SheshanFernando2021/Dev4Side_sheshan.git)
cd Dev4Side_sheshan
```

### 2. 🔧 Configure the Database
- Ensure you have **SQL Server** running (**LocalDB** or **Cloud-hosted**).
- Update the connection string in your local `appsettings.json` if needed.

> ⚠️ **Important:** The `appsettings.json` file in this repository contains a public demo connection string.  
> This was **intentionally exposed for demonstration purposes only**, and the database contains no sensitive data.  
> In a real-world application, **never commit or expose your connection strings publicly.**
Example:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\mssqllocaldb;Database=TaskBoardDb;Trusted_Connection=True;"
}
```

### 3. 🔑 JWT Settings
Update your `appsettings.json` with a secure JWT Secret:
```json
"Jwt": {
  "Key": "YourStrongJwtSecretKey",
  "Issuer": "YourApp",
  "Audience": "YourAppUsers"
}
```

### 4. ▶️ Run the API
```bash
dotnet build
dotnet ef database update
dotnet run
```

The API will be available at:  
`https://localhost:7184/`

---

## 📂 Folder Structure

```
/Controllers    → API route handlers
/Services       → Business logic
/Repositories   → Data access layer (EF Core)
/Entities       → Database models
/DTOs           → Data Transfer Objects
```

## 👨‍💻 Author

Made with ❤️ by **Sheshan Fernando**  
[GitHub Profile](https://github.com/sheshanfernando2021)

---

## ✅ Status

🟢 **Backend complete**  
