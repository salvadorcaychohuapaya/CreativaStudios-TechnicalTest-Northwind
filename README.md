# CreativaStudios-TechnicalTest-Northwind

Prueba técnica para Creativa Studios, desarrollando una aplicación web ASP.NET MVC para consulta de clientes y pedidos de la base de datos Northwind con WCF Services y Kendo UI.

## Tecnologías

- ASP.NET MVC 5 (.NET Framework 4.7.2)
- WCF Services (REST/JSON)
- Kendo UI 2025.4.1111
- Bootstrap 4.5.2
- Dapper
- SQL Server 2022
- Docker

## Requisitos

- Visual Studio 2019/2022
- .NET Framework 4.7.2+
- Docker Desktop

## Instalación

1. Clonar el repositorio

```bash
git clone https://github.com/salvadorcaychohuapaya/CreativaStudios-TechnicalTest-Northwind.git
cd CreativaStudios-TechnicalTest-Northwind
```

2. Levantar la base de datos

```bash
docker-compose up -d
```

3. Abrir el proyecto

```bash
backend/NorthwindWeb.sln
```

4. Ejecutar la aplicación (F5)

```bash
https://localhost:44374/Customer/CustomersByCountry
```

## Uso

### Buscar clientes por país

1. Ingresar país (USA, Germany, UK)
2. Click en "Buscar"
3. Click en Customer ID para ver pedidos

### Acceso a base de datos (Adminer)

```bash
URL: http://localhost:8080
Sistema: MS SQL (beta)
Servidor: sqlserver
Usuario: sa
Contraseña: Northwind2025!
```

## Endpoints

| Método | Endpoint | Parámetros |
|--------|----------|------------|
| GET | /Services/CustomerService.svc/GetCustomersByCountry | country, pageNumber, pageSize |
| GET | /Services/OrderService.svc/GetOrdersByCustomerId | customerId, pageNumber, pageSize |

## Estructura

```bash
CreativaStudios-TechnicalTest-Northwind/
├── docker-compose.yml
├── database/
│   ├── backups/Northwind.bak
│   └── scripts/
└── backend/NorthwindWeb/
    ├── Controllers/
    ├── Data/
    ├── Models/
    ├── Services/
    └── Views/
```

## Base de datos

### Stored Procedures

- `sp_GetCustomersByCountry` - Clientes por país con paginación
- `sp_GetOrdersByCustomerId` - Pedidos por cliente
- `sp_InsertWebTracker` - Auditoría de requests

### Tabla WebTracker

| Campo | Tipo | Descripción |
|-------|------|-------------|
| Id | INT | Identificador |
| URLRequest | NVARCHAR(500) | URL solicitada |
| SourceIp | NVARCHAR(50) | IP del cliente |
| TimeOfAction | DATETIME | Timestamp |

## Comandos útiles

### Docker

```bash
# Iniciar
docker-compose up -d

# Detener
docker-compose down

# Ver logs
docker logs northwind-sqlserver
```

### Verificar datos

```bash
# Ver clientes
docker exec -it northwind-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "Northwind2025!" -C -d Northwind -Q "SELECT TOP 5 CustomerID, CompanyName FROM Customers;"

# Ver auditoría
docker exec -it northwind-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P "Northwind2025!" -C -d Northwind -Q "SELECT TOP 10 * FROM WebTracker ORDER BY TimeOfAction DESC;"
```

## Características

- WCF Services (CustomerService, OrderService)
- Kendo Grid con paginación server-side
- Stored Procedures para consultas
- Tabla WebTracker para auditoría
- Paginación configurable (10, 20, 50)
- Bootstrap UI + Font Awesome
- Docker para SQL Server

## Autor

Salvador Martín Caycho Huapaya
