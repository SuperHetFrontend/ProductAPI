# 📦 Product API (Clean Architecture) - .NET 8

🚀 A clean-architecture-based Web API for managing products, built with **.NET 8**, **EF Core**, **SQL Server**, and **Dependency Injection**.

---

## 🌟 Features

- ✅ **CRUD Operations**: Manage products with RESTful API endpoints.
- ✅ **Clean Architecture**: Follows a layered approach (`Domain`, `Application`, `Infrastructure`, `Presentation`).
- ✅ **EF Core with Migrations**: Uses SQL Server with database migrations.
- ✅ **Seeding Data**: Ensures the database is initialized with sample products.
- ✅ **Swagger UI**: Easily test endpoints via Swagger.
- ✅ **Logging & Error Handling**: Logs errors and handles exceptions gracefully.

---

## 🏗️ Solution Structure

```
📦 ProductAPISolution
 ┣ 📂 API (Presentation Layer)
 ┃ ┣ 📜 Program.cs
 ┃ ┣ 📂 Controllers
 ┃ ┃ ┣ 📜 ProductsController.cs
 ┃ ┣ 📂 Filters
 ┃ ┃ ┣ 📜 RequestLoggingMiddleware.cs
 ┃ ┣ 📜 appsettings.json 
 ┣ 📂 Application (Business Logic Layer)
 ┃ ┣ 📂 Products
 ┃ ┃ ┣ 📜 IProductRepository.cs
 ┃ ┃ ┣ 📜 IProductService.cs
 ┃ ┃ ┣ 📜 ProductService.cs
 ┣ 📂 Domain (Core Business Entities)
 ┃ ┣ 📂 Products
 ┃ ┃ ┣ 📜 Product.cs
 ┣ 📂 Infrastructure (Data Persistence)
 ┃ ┣ 📂 DbContexts
 ┃ ┃ ┣ 📜 AppDbContext.cs
 ┃ ┃ ┣ 📜 AppDbContextFactory.cs
 ┃ ┣ 📂 Products
 ┃ ┃ ┣ 📜 ProductRepository.cs
 ┣ 📜 README.md
 ┣ 📜 .gitignore
 ┣ 📜 ProductAPISolution.sln
```
 
--- 

## ⚡ Getting Started

### **🔧 Prerequisites**
- Install **.NET 8 SDK**: [Download](https://dotnet.microsoft.com/en-us/download)
- Install **SQL Server** or use **LocalDB**.
- Install **Entity Framework Core CLI** (if not installed):

---

## 🚀 Installation & Setup

### 1️⃣  Clone Repository
- git clone https://github.com/SuperHetFrontend/ProductAPI.git


### 2️⃣  Configure Database Connection if not using LocalDb
- Modify appsettings.Development.json inside the API project:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=MyProductDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

For sql server update similar to...

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=MyProductDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
  }
}
```

---

## 🔄 Database Setup
✅ Successfully running the application will create the database and seed it using the existing migrations!
✅ Alternatively delete the migrations folder and start afresh using the ef commands
- dotnet ef migrations add InitialCreate
- dotnet ef database update

---

## ⚡ Running the Application
### ▶️ Run locally
- dotnet build
- dotnet run --project API

### ▶️ Calling the endpoints
- Run the application and use the API.http file

---

## 📡 API Endpoints
- GET		/api/products		Get all products
- GET		/api/products/{id}	Get product by ID
- POST		/api/products		Create a new product
- PUT		/api/products/{id}	Update a product
- DELETE	/api/products/{id}	Delete a product