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
GO

IF SCHEMA_ID(N'jacaranda') IS NULL EXEC(N'CREATE SCHEMA [jacaranda];');
GO

CREATE TABLE [jacaranda].[Guardians] (
    [Id] uniqueidentifier NOT NULL,
    [Cpf] varchar(14) NOT NULL,
    [Rg] varchar(12) NOT NULL,
    [Kinship] varchar(50) NOT NULL,
    [Occupation] varchar(150) NULL,
    [CompanyName] varchar(250) NULL,
    [Name] varchar(250) NOT NULL,
    [BirthDay] datetime2 NOT NULL,
    CONSTRAINT [PK_Guardians] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210116143614_Initial', N'5.0.2');
GO

COMMIT;
GO

