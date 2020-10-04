# Strategy game backend

## Development

Create a local database

```ps
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password2020' -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

Run the migrations

```ps
dotnet ef database update
```

Start the server

```ps
dotnet run
```

## Run locally

Build docker image

```ps
docker build --rm -t strategygame-backend:latest .
```

Run it

```ps
docker run --rm -d -p 8080:80 strategygame-backend
```

## Endpoints

API endpoints are documented at the `/swagger` location.
