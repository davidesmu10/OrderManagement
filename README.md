# OrderManagement

Sistema de gestión de pedidos desarrollado en .NET 9 con arquitectura limpia.

## Descripción

OrderManagement implementa un sistema completo de CRUD para pedidos, usando:

- .NET 9
- Entity Framework Core 8
- SQL Server
- Arquitectura por capas: Domain, Application, Infrastructure, API
- Swagger para documentación de la API
- Manejo global de errores
- Inyección de dependencias

## Estructura del proyecto


OrderManagement
├── Domain
│ └── Entities
├── Application
│ ├── DTOs
│ ├── Interfaces
│ └── Services
├── Infrastructure
│ ├── Data
│ └── Repositories
├── API
│ ├── Controllers
│ └── Middleware


## Instalación

1. Clonar el repositorio:
```bash
git clone https://github.com/davidesmu10/OrderManagement.git
Restaurar paquetes:
dotnet restore
Ejecutar el proyecto API:
dotnet run --project OrderManagement.API
Acceder a Swagger:
http://localhost:5000/swagger/index.html
Funcionalidades
Listar todos los pedidos
Crear nuevos pedidos
Obtener pedido por ID
Eliminar pedidos
