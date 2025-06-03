# 📚 SLH DotNetTraining

## ✅ Completed Topics

* [x] **C# Basic**
* [x] **SQL Basic**
* [x] **Console App**
* [x] **Console App + Db (Memory Database)**
* [x] **Console App + Db (SQL Server)**

  * [x] ADO.NET (CRUD) - *Old School*
  * [x] Dapper (CRUD) - *Micro ORM (Query)*
  * [x] EF Core (CRUD) - *Full ORM (No Query)*
* [x] **Windows Forms**

---

## 🚧 Upcoming / In Progress

* [ ] Postman
* [ ] ASP.NET Core Web API
* [ ] Logic
* [ ] HttpClient
* [ ] RestSharp
* [ ] Refit
* [ ] Console App + API

---

## 🔗 Gist Link

[https://gist.github.com/sannlynnhtun-coding](https://gist.github.com/sannlynnhtun-coding)

---

## ⚙️ EF Core Scaffold Commands

```bash
# General Scaffold Template
dotnet ef dbcontext scaffold "Server=.;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f

# DotNetTrainingBatch1 - Scaffold All Tables
dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

# Northwind Database Scaffold
dotnet ef dbcontext scaffold "Server=.;Database=Northwind;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o NorthwindModels -c NorthwindAppDbContext -f

# Scaffold Specific Tables
dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -t Tbl_BlogDetail,Tbl_BlogHeader -f
```

---

## 🛠️ EF Tool Installation

```bash
dotnet tool install --global dotnet-ef
```

---

## 🌐 Northwind Sample DB

📥 Download:
[Northwind Sample SQL Script](https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql)

---

## 🧱 Project Structure Overview

```txt
Database -> Table

Class Library -> EF Core Installed -> Scaffold Models via CMD

API Project:
	- Add Class Library (EF Core)
	- Register in Program.cs
	- Create Controller -> CRUD using AppDbContext

Class Library:
	- Add Domain Layer
	- Add BlogService
	- Register in API Project:
		builder.Services.AddScoped<BlogService>();
```

> **Structure:** `Database` → `Domain` → `API Project (DI)`

---

## 💼 MiniWallet Example Scaffold

```bash
dotnet ef dbcontext scaffold "Server=.;Database=MiniWallet;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f
```
