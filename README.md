# .NET Boilerplate

# Table of Contents
1. [Overview](#overview)
2. [API](#api)
3. [Unit Test](#unit-test)
4. [cURL Example](#curl-example)
5. [Future Developmet](#future-developmet)

## Overview

The codebase on this repository pretends to serve as a codebase for future developments.

The goal is to create a boilerplate where all technologies, frameworks, libraries, and programming languages are specified.
The boilerplate will also specify the design patterns and access patterns. 

## API

The API is developed with .NET 6 and PostgreSQL.

How to run the API? 

```bash
dotnet run
```

Swaggger: https://{url}/swagger/index.html

## Unit Test

The Unit Test are developed using xUnit.

How to run the Unit Tests? 

```bash
dotnet test
```

## cURL Example

### Get All Devices (200 OK)
```bash
curl --location --request GET 'https://{url}/api/device'
```

### Create Device (201 Created)
```bash
curl --location --request POST 'https://{url}/api/device' \
--header 'Content-Type: application/json' \
--data-raw '{
    "name": "14 Pro",
    "brand": "iPhone"
}'
```

### Delete Device

```bash
curl --location --request DELETE 'https://{url}/api/device/{id}'
```

### Get Device by Id

```bash
curl --location --request GET 'https://{url}/api/device/{id}'
```

### Update Device

```bash
curl --location --request PUT 'https://{url}/api/Device/{id}' \
--header 'Content-Type: application/json-patch+json' \
--data-raw '{
    "id": "0d5e7940-fa51-4858-982e-a1aa708a4419",
    "createdAt": "2022-11-14T22:09:49.48654Z",
    "name": "Iphone",
    "brand": "iPhone"
}'
```

### Search By Brand
```bash
curl --location --request GET 'https://localhost:7024/api/device/?brand=iPhone'
```

## Future Considerations

- [CQRS](https://martinfowler.com/bliki/CQRS.html)
- [Dapper](https://dapperlib.github.io/Dapper/)
- [NewRelic](https://newrelic.com/)