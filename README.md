# OrderAPI

This repository contains a solution for [this](https://github.com/albumprinter/dotnet-engineer-assignment) technical asigment 

## Prerequisites
Download and install the [.NET Core SDK 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) on your computer.

## Execution

* To build. Execute from the solution folder
```bash
dotnet build
```
* To Execute. Execute from the OrderAPI folder inside the solution folder
```bash
dotnet run
```
and open [swagger help](https://localhost:7121/swagger/index.html)

you can create orders
```bash
curl --location --request POST 'https://localhost:7121/Order' \
--header 'accept: text/plain' \
--header 'Content-Type: application/json' \
--data-raw '{
  "orderId": 0,
  "orderLines": [
    {
      "productType": {
        "id": 1,
        "name": "string",
        "width": 0
      },
      "quantity": 3
    }
  ]
}'
```

and get the order
```bash
curl -X 'GET' \
  'https://localhost:7121/Order?orderId=1' \
  -H 'accept: text/plain'
```

* To run test, from the OrderAPITest folder inside the solution folder
```bash
dotnet test
```