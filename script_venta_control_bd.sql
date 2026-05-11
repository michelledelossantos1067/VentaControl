IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE TABLE [Clientes] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Telefono] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE TABLE [Productos] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        [Precio] decimal(18,2) NOT NULL,
        [Stock] int NOT NULL,
        [ImagenUrl] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Productos] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE TABLE [Usuarios] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NOT NULL,
        [PasswordHash] nvarchar(max) NOT NULL,
        [Rol] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE TABLE [Ventas] (
        [Id] int NOT NULL IDENTITY,
        [Fecha] datetime2 NOT NULL,
        [Total] decimal(18,2) NOT NULL,
        [ClienteId] int NOT NULL,
        CONSTRAINT [PK_Ventas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Ventas_Clientes_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Clientes] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE TABLE [DetalleVentas] (
        [Id] int NOT NULL IDENTITY,
        [Cantidad] int NOT NULL,
        [Precio] decimal(18,2) NOT NULL,
        [VentaId] int NOT NULL,
        [ProductoId] int NOT NULL,
        CONSTRAINT [PK_DetalleVentas] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DetalleVentas_Productos_ProductoId] FOREIGN KEY ([ProductoId]) REFERENCES [Productos] ([Id]),
        CONSTRAINT [FK_DetalleVentas_Ventas_VentaId] FOREIGN KEY ([VentaId]) REFERENCES [Ventas] ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_DetalleVentas_ProductoId] ON [DetalleVentas] ([ProductoId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_DetalleVentas_VentaId] ON [DetalleVentas] ([VentaId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    CREATE INDEX [IX_Ventas_ClienteId] ON [Ventas] ([ClienteId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260511180052_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260511180052_InitialCreate', N'9.0.0');
END;

COMMIT;
GO

