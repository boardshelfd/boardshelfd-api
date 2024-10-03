[![.NET](https://github.com/boardshelfd/boardshelfd-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/boardshelfd/boardshelfd-api/actions/workflows/dotnet.yml)

### built with

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white) ![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

# boardshelfd-api

This is the source code of the boardshelfd API. (Mostly used for user management)

**Prerequisites:**

- _Microsoft SQL Server database_

- _EntityFrameworkCore_

## Getting started

Clone repo:

```shell
git clone https://github.com/boardshelfd/boardshelfd-api.git
```

Edit config to fit with your SQL Server database: (`Sources/boardshelfd-api/WebAPI/appsettings.json`)

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost,2300;Database=BSD;Persist Security Info=False;User ID=YourUserID;Password=YourP@ssword;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
},
```

Restore & Build:

```shell
cd Sources/boardsheld-api/

dotnet restore

dotnet build
```

Run the project using `https` or `IIS`. The Swagger doc should automatically open. 

## See also

Front-end part of this project : [boardshelfd/boardshelfd](https://github.com/boardshelfd/boardshelfd)
