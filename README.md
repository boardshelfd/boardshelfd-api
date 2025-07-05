[![.NET](https://github.com/boardshelfd/boardshelfd-api/actions/workflows/dotnet.yml/badge.svg)](https://github.com/boardshelfd/boardshelfd-api/actions/workflows/dotnet.yml)

### built with

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white) ![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

# boardshelfd-api

This is the source code of the boardshelfd API. 

Two goals of this API : User management / Parse [BGG XML API](https://boardgamegeek.com/wiki/page/BGG_XML_API2), to transform it into JSON.

**Prerequisites:**

- _MariaDB / MySQL database_

- _EntityFrameworkCore_

## Getting started

Clone repo:

```shell
git clone https://github.com/boardshelfd/boardshelfd-api.git
```

Edit config to fit with your SQL Server database: 

> Sources/boardshelfd-api/WebAPI/appsettings.json
```json
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=empty;Username=empty;Password=empty"
},
```

Restore & Build:

```shell
cd Sources/boardshelfd-api/

dotnet restore

dotnet build
```

Run the project using `https` or `IIS`. The Swagger doc should automatically open. 

## See also

Front-end part of this project : [boardshelfd/boardshelfd](https://github.com/boardshelfd/boardshelfd)
