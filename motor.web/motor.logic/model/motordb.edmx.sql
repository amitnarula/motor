
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2017 17:21:03
-- Generated from EDMX file: D:\old\Proyectos\motor\motor.web\motor.logic\model\motordb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [motor];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AuthenticationToken_AuthenticationToken]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AuthenticationTokens] DROP CONSTRAINT [FK_AuthenticationToken_AuthenticationToken];
GO
IF OBJECT_ID(N'[motorModelStoreContainer].[FK_DriverDocuments_Users]', 'F') IS NOT NULL
    ALTER TABLE [motorModelStoreContainer].[DriverDocuments] DROP CONSTRAINT [FK_DriverDocuments_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_PaymentCards_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PaymentCards] DROP CONSTRAINT [FK_PaymentCards_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AuthenticationTokens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthenticationTokens];
GO
IF OBJECT_ID(N'[dbo].[PaymentCards]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentCards];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[motorModelStoreContainer].[DriverDocuments]', 'U') IS NOT NULL
    DROP TABLE [motorModelStoreContainer].[DriverDocuments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AuthenticationTokens'
CREATE TABLE [dbo].[AuthenticationTokens] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Token] nvarchar(max)  NOT NULL,
    [UserId] bigint  NOT NULL,
    [Expires] datetime  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Firstname] nvarchar(50)  NOT NULL,
    [Middlename] nvarchar(50)  NULL,
    [Lastname] nvarchar(50)  NOT NULL,
    [Password] nvarchar(100)  NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Phone] nvarchar(20)  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Source] nvarchar(100)  NOT NULL,
    [UserType] smallint  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [IsEmailVerified] bit  NOT NULL
);
GO

-- Creating table 'DriverDocuments'
CREATE TABLE [dbo].[DriverDocuments] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL,
    [SSN] nvarchar(12)  NOT NULL,
    [LicenseNumber] nvarchar(10)  NOT NULL,
    [VehiclePicture1] varbinary(max)  NULL,
    [VehiclePicture2] varbinary(max)  NULL,
    [LicensePicture] varbinary(max)  NULL,
    [Status] smallint  NOT NULL
);
GO

-- Creating table 'PaymentCards'
CREATE TABLE [dbo].[PaymentCards] (
    [Id] bigint  NOT NULL,
    [UserId] bigint  NOT NULL,
    [CardNumber] nvarchar(16)  NOT NULL,
    [CardName] nvarchar(100)  NOT NULL,
    [Expiry] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AuthenticationTokens'
ALTER TABLE [dbo].[AuthenticationTokens]
ADD CONSTRAINT [PK_AuthenticationTokens]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DriverDocuments'
ALTER TABLE [dbo].[DriverDocuments]
ADD CONSTRAINT [PK_DriverDocuments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PaymentCards'
ALTER TABLE [dbo].[PaymentCards]
ADD CONSTRAINT [PK_PaymentCards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AuthenticationTokens'
ALTER TABLE [dbo].[AuthenticationTokens]
ADD CONSTRAINT [FK_AuthenticationToken_AuthenticationToken]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AuthenticationToken_AuthenticationToken'
CREATE INDEX [IX_FK_AuthenticationToken_AuthenticationToken]
ON [dbo].[AuthenticationTokens]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'DriverDocuments'
ALTER TABLE [dbo].[DriverDocuments]
ADD CONSTRAINT [FK_DriverDocuments_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DriverDocuments_Users'
CREATE INDEX [IX_FK_DriverDocuments_Users]
ON [dbo].[DriverDocuments]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'PaymentCards'
ALTER TABLE [dbo].[PaymentCards]
ADD CONSTRAINT [FK_PaymentCards_Users]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PaymentCards_Users'
CREATE INDEX [IX_FK_PaymentCards_Users]
ON [dbo].[PaymentCards]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------