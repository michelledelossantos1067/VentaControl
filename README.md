# VentaControl

## Descripción

Aplicación full-stack para la gestión de productos, clientes y ventas. Desarrollada como prueba técnica, implementa una API REST con autenticación JWT y un panel administrativo responsivo.

## Tecnologías utilizadas

### Backend
- .NET 9
- C#
- Entity Framework Core 9
- SQL Server
- JWT
- xUnit

### Frontend
- Vue.js 3
- Bootstrap 5
- Axios
- Vue Router
- Pinia

## Arquitectura

El backend sigue una arquitectura en capas:

- **VentaControl.API** - Controllers y configuración
- **VentaControl.Services** - Lógica de negocio
- **VentaControl.Repositories** - Acceso a datos y DbContext
- **VentaControl.Models** - Entidades y DTOs

## Instrucciones para correr la aplicación

### Requisitos previos

- .NET 9 SDK
- SQL Server
- Node.js 18
- npm

### Backend

1. Clona el repositorio:

```bash
git clone 
```

2. Configura la cadena de conexión en `VentaControl.API/appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=VentaControlDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

3. Ejecuta las migraciones para crear la base de datos:

```bash
cd VentaControl.Repositories
dotnet ef database update --startup-project ../VentaControl.API
```

4. Corre el backend:

```bash
cd VentaControl.API
dotnet run
```

La API estará disponible en `http://localhost:5000`

### Frontend

1. Instala las dependencias:

```bash
cd VentaControlFE
npm install
```

2. Corre el frontend:

```bash
npm run dev
```

3. Abre `http://localhost:5173`

### Base de datos

También se incluye el script SQL en la raíz del repositorio (`script_venta_control_bd.sql`) como alternativa a las migraciones:

```bash
sqlcmd -S localhost -i script_venta_control_bd.sql
```

## Credenciales de prueba

- **Admin:** admin / admin
- **Cliente:** regístrate desde /registro

## Funcionalidades

### Cliente
- Registro e inicio de sesión
- Ver catálogo de productos
- Comprar productos

### Administrador
- Gestión de productos (CRUD)
- Gestión de usuarios
- Gestión de clientes
- Registro y historial de ventas con detalle de productos

## Pruebas unitarias

Las pruebas se encuentran en el proyecto `VentaControl.Tests`. Para ejecutarlas:

```bash
dotnet test
```

## Principios aplicados

- Arquitectura en capas (Controllers, Services, Repositories)
- Principios SOLID
- Inyección de dependencias
- Manejo centralizado de errores con respuestas HTTP clarasSonnet 4.6AdaptativoClaude es IA y puede cometer errores. Por favor, verifica nuevamente las respuestas.


<img width="1439" height="756" alt="Captura de pantalla 2026-05-11 a la(s) 2 07 20 p  m" src="https://github.com/user-attachments/assets/648cd254-b319-4727-a846-b07f01e0b8fe" />

<img width="492" height="749" alt="Captura de pantalla 2026-05-11 a la(s) 2 07 40 p  m" src="https://github.com/user-attachments/assets/7f9aae8d-b4db-47e8-9aca-9555fd36f63e" />

<img width="1434" height="760" alt="Captura de pantalla 2026-05-11 a la(s) 2 08 13 p  m" src="https://github.com/user-attachments/assets/c26fe973-a92a-458d-928e-9bc9486a5f96" />
<img width="1440" height="763" alt="Captura de pantalla 2026-05-11 a la(s) 2 08 03 p  m" src="https://github.com/user-attachments/assets/04c38d85-9f47-4ce5-a48f-6f9f98a26cb6" />


