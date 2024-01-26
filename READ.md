#instaling packages with proper version

dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.1.26
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.1.26
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.1.26

#migrations
dotnet ef migrations add Initial
#remove migratino
dotnet ef migrations remove

#update database
dotnet ef migrations add Seeding
dotnet ef database update

#dotnet
dotnet clean
dotnet build

#JWT
dotnet add package System.IdentityModel.Tokens.Jwt --version 6.14.1
