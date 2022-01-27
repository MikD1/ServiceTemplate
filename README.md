# .NET Service Template

dotnet new template for create web service

https://www.nuget.org/packages/mikd1.service.template/

## Features

- Solution structure
- StyleCop.Analyzers support
- Docker support
- Postgres support

## Install

```
dotnet new --install mikd1.service.template
```

## Usage

```
dotnet new webservice SomeName
```

## Build and run

```
cd templates
docker build -t webservice .
docker run -p 127.0.0.1:5001:80 webservice
```

## Uninstall

```
dotnet new -u mikd1.service.template
```