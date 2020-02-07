
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/19/2020 00:26:49
-- Generated from EDMX file: C:\Users\Pedro De La Cruz\source\repos\TrabajosOnline\TrabajosOnline\Models\dbTrabajos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrabajosOnline];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Aplicar_Trabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Aplicar_Trabajo];
GO
IF OBJECT_ID(N'[dbo].[Categoria_Trabajos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categoria_Trabajos];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Trabajos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trabajos];
GO
IF OBJECT_ID(N'[dbo].[Trabajos_habilidades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trabajos_habilidades];
GO
IF OBJECT_ID(N'[dbo].[Usuario]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuario];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Aplicar_Trabajo'
CREATE TABLE [dbo].[Aplicar_Trabajo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_Usuario] int  NULL,
    [Fecha_Aplicacion] datetime  NULL,
    [id_Trabajo] int  NULL
);
GO

-- Creating table 'Categoria_Trabajos'
CREATE TABLE [dbo].[Categoria_Trabajos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [descripcion] varchar(50)  NULL,
    [Estado] varchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Trabajos'
CREATE TABLE [dbo].[Trabajos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_Habilidades] int  NULL,
    [Descripcion] varchar(max)  NULL,
    [sueldo] decimal(18,0)  NULL,
    [Direccion] varchar(50)  NULL,
    [fecha_Publicacion] datetime  NULL,
    [condiciones] varchar(max)  NULL,
    [Estado] varchar(50)  NULL,
    [id_categoria] int  NULL
);
GO

-- Creating table 'Trabajos_habilidades'
CREATE TABLE [dbo].[Trabajos_habilidades] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Descripcion] varchar(max)  NULL,
    [Estado] varchar(50)  NULL
);
GO

-- Creating table 'Usuario'
CREATE TABLE [dbo].[Usuario] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [Apellido] varchar(50)  NULL,
    [Correo] varchar(50)  NULL,
    [Foto] varbinary(max)  NULL,
    [Contraseña] varchar(50)  NULL,
    [Rol] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Aplicar_Trabajo'
ALTER TABLE [dbo].[Aplicar_Trabajo]
ADD CONSTRAINT [PK_Aplicar_Trabajo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Categoria_Trabajos'
ALTER TABLE [dbo].[Categoria_Trabajos]
ADD CONSTRAINT [PK_Categoria_Trabajos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Trabajos'
ALTER TABLE [dbo].[Trabajos]
ADD CONSTRAINT [PK_Trabajos]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Trabajos_habilidades'
ALTER TABLE [dbo].[Trabajos_habilidades]
ADD CONSTRAINT [PK_Trabajos_habilidades]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Usuario'
ALTER TABLE [dbo].[Usuario]
ADD CONSTRAINT [PK_Usuario]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------