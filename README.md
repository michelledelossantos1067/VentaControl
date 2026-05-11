## Instrucciones para correr la aplicación

### Backend
1. Clona el repositorio
2. Configura la cadena de conexión en `appsettings.json`
3. Ejecuta las migraciones:
```bash
cd VentaControl.Repositories
dotnet ef database update --startup-project ../VentaControl.API
```
4. Corre el backend:
```bash
cd VentaControl.API
dotnet run
```

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

## Credenciales de prueba
- **Admin:** admin / admin
- **Cliente:** registrate desde /registro

## Funcionalidades
### Cliente
- Registro e inicio de sesión
- Ver catálogo de productos
- Comprar productos

### Administrador
- Gestión de productos (CRUD)
- Gestión de clientes
- Historial de ventas y detalles