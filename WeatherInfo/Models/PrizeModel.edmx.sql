
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/09/2014 17:14:56
-- Generated from EDMX file: C:\Users\Sankari\documents\visual studio 2013\Projects\WeatherInfo\WeatherInfo\Models\PrizeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[masterModelStoreContainer].[MSreplication_options]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[MSreplication_options];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_db]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_db];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_dev]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_dev];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_fallback_usg]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_fallback_usg];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_monitor]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_monitor];
GO
IF OBJECT_ID(N'[masterModelStoreContainer].[spt_values]', 'U') IS NOT NULL
    DROP TABLE [masterModelStoreContainer].[spt_values];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MSreplication_options'
CREATE TABLE [dbo].[MSreplication_options] (
    [optname] nvarchar(128)  NOT NULL,
    [value] bit  NOT NULL,
    [major_version] int  NOT NULL,
    [minor_version] int  NOT NULL,
    [revision] int  NOT NULL,
    [install_failures] int  NOT NULL
);
GO

-- Creating table 'spt_fallback_db'
CREATE TABLE [dbo].[spt_fallback_db] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_dbid] smallint  NULL,
    [name] varchar(30)  NOT NULL,
    [dbid] smallint  NOT NULL,
    [status] smallint  NOT NULL,
    [version] smallint  NOT NULL
);
GO

-- Creating table 'spt_fallback_dev'
CREATE TABLE [dbo].[spt_fallback_dev] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_low] int  NULL,
    [xfallback_drive] char(2)  NULL,
    [low] int  NOT NULL,
    [high] int  NOT NULL,
    [status] smallint  NOT NULL,
    [name] varchar(30)  NOT NULL,
    [phyname] varchar(127)  NOT NULL
);
GO

-- Creating table 'spt_fallback_usg'
CREATE TABLE [dbo].[spt_fallback_usg] (
    [xserver_name] varchar(30)  NOT NULL,
    [xdttm_ins] datetime  NOT NULL,
    [xdttm_last_ins_upd] datetime  NOT NULL,
    [xfallback_vstart] int  NULL,
    [dbid] smallint  NOT NULL,
    [segmap] int  NOT NULL,
    [lstart] int  NOT NULL,
    [sizepg] int  NOT NULL,
    [vstart] int  NOT NULL
);
GO

-- Creating table 'spt_monitor'
CREATE TABLE [dbo].[spt_monitor] (
    [lastrun] datetime  NOT NULL,
    [cpu_busy] int  NOT NULL,
    [io_busy] int  NOT NULL,
    [idle] int  NOT NULL,
    [pack_received] int  NOT NULL,
    [pack_sent] int  NOT NULL,
    [connections] int  NOT NULL,
    [pack_errors] int  NOT NULL,
    [total_read] int  NOT NULL,
    [total_write] int  NOT NULL,
    [total_errors] int  NOT NULL
);
GO

-- Creating table 'spt_values'
CREATE TABLE [dbo].[spt_values] (
    [name] nvarchar(35)  NULL,
    [number] int  NOT NULL,
    [type] nchar(3)  NOT NULL,
    [low] int  NULL,
    [high] int  NULL,
    [status] int  NULL
);
GO

-- Creating table 'Prizes'
CREATE TABLE [dbo].[Prizes] (
    [Name] nvarchar(35)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [optname], [value], [major_version], [minor_version], [revision], [install_failures] in table 'MSreplication_options'
ALTER TABLE [dbo].[MSreplication_options]
ADD CONSTRAINT [PK_MSreplication_options]
    PRIMARY KEY CLUSTERED ([optname], [value], [major_version], [minor_version], [revision], [install_failures] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] in table 'spt_fallback_db'
ALTER TABLE [dbo].[spt_fallback_db]
ADD CONSTRAINT [PK_spt_fallback_db]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [name], [dbid], [status], [version] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] in table 'spt_fallback_dev'
ALTER TABLE [dbo].[spt_fallback_dev]
ADD CONSTRAINT [PK_spt_fallback_dev]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [low], [high], [status], [name], [phyname] ASC);
GO

-- Creating primary key on [xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] in table 'spt_fallback_usg'
ALTER TABLE [dbo].[spt_fallback_usg]
ADD CONSTRAINT [PK_spt_fallback_usg]
    PRIMARY KEY CLUSTERED ([xserver_name], [xdttm_ins], [xdttm_last_ins_upd], [dbid], [segmap], [lstart], [sizepg], [vstart] ASC);
GO

-- Creating primary key on [lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] in table 'spt_monitor'
ALTER TABLE [dbo].[spt_monitor]
ADD CONSTRAINT [PK_spt_monitor]
    PRIMARY KEY CLUSTERED ([lastrun], [cpu_busy], [io_busy], [idle], [pack_received], [pack_sent], [connections], [pack_errors], [total_read], [total_write], [total_errors] ASC);
GO

-- Creating primary key on [number], [type] in table 'spt_values'
ALTER TABLE [dbo].[spt_values]
ADD CONSTRAINT [PK_spt_values]
    PRIMARY KEY CLUSTERED ([number], [type] ASC);
GO

-- Creating primary key on [Name] in table 'Prizes'
ALTER TABLE [dbo].[Prizes]
ADD CONSTRAINT [PK_Prizes]
    PRIMARY KEY CLUSTERED ([Name] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------