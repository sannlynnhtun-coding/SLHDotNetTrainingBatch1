# SLH DotNetTraining

- [x] C# Basic
- [x] SQL Basic
- [x] Console App
- [x] Console App + Db (Memory Database)
- [x] Console App + Db (SQL Server) 
	- [x] ADO.NET (CRUD) - Old School
	- [x] Dapper (CRUD) ORM - Micro ORM (query)
	- [x] EFCore (CRUD) ORM - Full ORM (no query)
- [x] Windows Forms
- Postman
- ASP.NET Core Web API
- Logic
- HttpClient
- RestSharp
- Refit
- Console App + API

Login Form
Username
Password
Login
	- Get From Textbox (trim)
	- Read From Database
	- ADO.NET (CRUD)
Cancel

Database
- Table
- User
- Username, Password
- Data Fill

https://gist.github.com/sannlynnhtun-coding

dotnet ef dbcontext scaffold "Server=.;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f
dotnet ef dbcontext scaffold "Server=.;Database=Northwind;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o NorthwindModels -c NorthwindAppDbContext -f


dotnet tool install --global dotnet-ef

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f
dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch1;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -t Tbl_BlogDetail,Tbl_BlogHeader -f


https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql

- Database > Table
- Class Libary > EFCore Install > Cmd
- API Project > Add Class Libary > EFCore (DI)
- API Project > Create Controller > CRUD using AppContext
- Class Libary > Domain > BlogService > API Project > Add > Register (builder.Servcices.AddScoped<BlogService>();))


> Database > Domain > API Project (DI)

dotnet ef dbcontext scaffold "Server=.;Database=MiniWallet;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f

dotnet ef dbcontext scaffold "Server=.;Database=SnakeLadder;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f