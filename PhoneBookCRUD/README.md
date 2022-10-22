# Phonebook
___
CRUD operations with DB PostgreSQL
## How to run
You will need to install:
1. [PostgreSQL 14](https://www.postgresql.org)
2. [.Net 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

Now you should clone this project:
```
git clone https://github.com/sotiredofyours/Csharp-courses
```
Open the project root directory and install all NuGet dependencies:
```
dotnet restore
dotnet tool restore
```
Override options in DBContext.cs
Then migrate database and run app
```
dotnet ef database update --project ./PhoneBookCRUD
dotnet run --project ./PhoneBookCRUD
```