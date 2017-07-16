
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2017 13:43:50
-- Generated from EDMX file: C:\source\motor\motor.web\motor.logic\model\motordb.edmx
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

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AuthenticationTokens]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AuthenticationTokens];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------