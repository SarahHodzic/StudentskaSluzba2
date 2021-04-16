
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/06/2021 02:17:18
-- Generated from EDMX file: C:\Users\Muki\source\repos\StudentskaSluzba2\App_Start\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Studentska_sluzba];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Godina__ID_studi__6442E2C9]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Godina] DROP CONSTRAINT [FK__Godina__ID_studi__6442E2C9];
GO
IF OBJECT_ID(N'[dbo].[FK__Godina_St__ID_St__19DFD96B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Godina_Studij] DROP CONSTRAINT [FK__Godina_St__ID_St__19DFD96B];
GO
IF OBJECT_ID(N'[dbo].[FK__Plan_i_pr__ID_pr__09A971A2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plan_i_program] DROP CONSTRAINT [FK__Plan_i_pr__ID_pr__09A971A2];
GO
IF OBJECT_ID(N'[dbo].[FK__Plan_i_pr__ID_ti__0A9D95DB]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plan_i_program] DROP CONSTRAINT [FK__Plan_i_pr__ID_ti__0A9D95DB];
GO
IF OBJECT_ID(N'[dbo].[FK__Pohadjanj__ID_pl__498EEC8D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pohadjanje] DROP CONSTRAINT [FK__Pohadjanj__ID_pl__498EEC8D];
GO
IF OBJECT_ID(N'[dbo].[FK__Pohadjanj__ID_pr__489AC854]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pohadjanje] DROP CONSTRAINT [FK__Pohadjanj__ID_pr__489AC854];
GO
IF OBJECT_ID(N'[dbo].[FK__Pohadjanj__ID_St__47A6A41B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pohadjanje] DROP CONSTRAINT [FK__Pohadjanj__ID_St__47A6A41B];
GO
IF OBJECT_ID(N'[dbo].[FK__Predmet_H__ID_Pr__3C34F16F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Predmet_Hijerarhija] DROP CONSTRAINT [FK__Predmet_H__ID_Pr__3C34F16F];
GO
IF OBJECT_ID(N'[dbo].[FK__Predmet_H__ID_Pr__3D2915A8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Predmet_Hijerarhija] DROP CONSTRAINT [FK__Predmet_H__ID_Pr__3D2915A8];
GO
IF OBJECT_ID(N'[dbo].[FK__Studij__ID_smjer__03F0984C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Studij] DROP CONSTRAINT [FK__Studij__ID_smjer__03F0984C];
GO
IF OBJECT_ID(N'[dbo].[FK__Tipovi_st__ID_st__41EDCAC5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tipovi_studenata] DROP CONSTRAINT [FK__Tipovi_st__ID_st__41EDCAC5];
GO
IF OBJECT_ID(N'[dbo].[FK__Tipovi_st__ID_St__42E1EEFE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tipovi_studenata] DROP CONSTRAINT [FK__Tipovi_st__ID_St__42E1EEFE];
GO
IF OBJECT_ID(N'[dbo].[fk_Godina_id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Godina_Studij] DROP CONSTRAINT [fk_Godina_id];
GO
IF OBJECT_ID(N'[dbo].[FK_Godina_Studij_Godina_Studij]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Godina_Studij] DROP CONSTRAINT [FK_Godina_Studij_Godina_Studij];
GO
IF OBJECT_ID(N'[dbo].[fk_Godina_studij_ID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plan_i_program] DROP CONSTRAINT [fk_Godina_studij_ID];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Godina]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Godina];
GO
IF OBJECT_ID(N'[dbo].[Godina_Studij]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Godina_Studij];
GO
IF OBJECT_ID(N'[dbo].[Plan_i_program]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Plan_i_program];
GO
IF OBJECT_ID(N'[dbo].[Pohadjanje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pohadjanje];
GO
IF OBJECT_ID(N'[dbo].[Predmet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Predmet];
GO
IF OBJECT_ID(N'[dbo].[Predmet_Hijerarhija]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Predmet_Hijerarhija];
GO
IF OBJECT_ID(N'[dbo].[Prijava]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prijava];
GO
IF OBJECT_ID(N'[dbo].[Profesor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profesor];
GO
IF OBJECT_ID(N'[dbo].[Smjer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Smjer];
GO
IF OBJECT_ID(N'[dbo].[Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student];
GO
IF OBJECT_ID(N'[dbo].[Student_tip]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Student_tip];
GO
IF OBJECT_ID(N'[dbo].[Studij]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Studij];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Tip_Nastave]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tip_Nastave];
GO
IF OBJECT_ID(N'[dbo].[Tipovi_studenata]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipovi_studenata];
GO
IF OBJECT_ID(N'[Studentska_sluzbaModelStoreContainer].[Potvrda_pripadnosti]', 'U') IS NOT NULL
    DROP TABLE [Studentska_sluzbaModelStoreContainer].[Potvrda_pripadnosti];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Godinas'
CREATE TABLE [dbo].[Godinas] (
    [ID_godina] int IDENTITY(1,1) NOT NULL,
    [ID_studij] int  NULL
);
GO

-- Creating table 'Godina_Studij'
CREATE TABLE [dbo].[Godina_Studij] (
    [ID_Godina_Studij] int IDENTITY(1,1) NOT NULL,
    [ID_Godina] int  NOT NULL,
    [ID_Studij] int  NOT NULL
);
GO

-- Creating table 'Plan_i_program'
CREATE TABLE [dbo].[Plan_i_program] (
    [ID_plan_i_program] int IDENTITY(1,1) NOT NULL,
    [ID_predmet] int  NULL,
    [ID_tipn] int  NULL,
    [ID_Godina_Studij] int  NULL
);
GO

-- Creating table 'Pohadjanjes'
CREATE TABLE [dbo].[Pohadjanje] (
    [ID_Pohadjanje] int IDENTITY(1,1) NOT NULL,
    [ID_Student] int  NULL,
    [ID_profesor] int  NULL,
    [ID_plan_i_program] int  NULL,
    [Datum] datetime  NOT NULL
);
GO

-- Creating table 'Predmets'
CREATE TABLE [dbo].[Predmet] (
    [ID_Predmet] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Predmet_Hijerarhija'
CREATE TABLE [dbo].[Predmet_Hijerarhija] (
    [ID_Predmet_Hijerarhija] int IDENTITY(1,1) NOT NULL,
    [ID_Predmet] int  NOT NULL,
    [ID_Predmet_Uslov] int  NOT NULL
);
GO

-- Creating table 'Prijavas'
CREATE TABLE [dbo].[Prijava] (
    [ID_Prijava] int IDENTITY(1,1) NOT NULL,
    [Korisnicko_ime] nvarchar(50)  NOT NULL,
    [Lozinka] nvarchar(50)  NOT NULL,
    [Tip_Korisnika] nvarchar(50)  NOT NULL,
    [Email] nvarchar(100)  NULL
);
GO

-- Creating table 'Profesors'
CREATE TABLE [dbo].[Profesor] (
    [ID_Prof] int IDENTITY(1,1) NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Smjers'
CREATE TABLE [dbo].[Smjer] (
    [ID_smjer] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Student] (
    [ID_student] int IDENTITY(1,1) NOT NULL,
    [JMBG] nvarchar(50)  NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Student_tip'
CREATE TABLE [dbo].[Student_tip] (
    [ID_Student_tip] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Studijs'
CREATE TABLE [dbo].[Studij] (
    [ID_studij] int IDENTITY(1,1) NOT NULL,
    [Naziv] nvarchar(50)  NOT NULL,
    [ID_smjer] int  NULL
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

-- Creating table 'Tip_Nastave'
CREATE TABLE [dbo].[Tip_Nastave] (
    [ID_tip] int IDENTITY(1,1) NOT NULL,
    [Tip] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Tipovi_studenata'
CREATE TABLE [dbo].[Tipovi_studenata] (
    [ID_Tipovi_studenata] int IDENTITY(1,1) NOT NULL,
    [ID_student] int  NULL,
    [ID_Student_tip] int  NULL
);
GO

-- Creating table 'Potvrda_pripadnosti'
CREATE TABLE [dbo].[Potvrda_pripadnosti] (
    [JMBG] nvarchar(50)  NOT NULL,
    [Ime] nvarchar(50)  NOT NULL,
    [Prezime] nvarchar(50)  NOT NULL,
    [tip_studenta] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID_godina] in table 'Godinas'
ALTER TABLE [dbo].[Godina]
ADD CONSTRAINT [PK_Godina]
    PRIMARY KEY CLUSTERED ([ID_godina] ASC);
GO

-- Creating primary key on [ID_Godina_Studij] in table 'Godina_Studij'
ALTER TABLE [dbo].[Godina_Studij]
ADD CONSTRAINT [PK_Godina_Studij]
    PRIMARY KEY CLUSTERED ([ID_Godina_Studij] ASC);
GO

-- Creating primary key on [ID_plan_i_program] in table 'Plan_i_program'
ALTER TABLE [dbo].[Plan_i_program]
ADD CONSTRAINT [PK_Plan_i_program]
    PRIMARY KEY CLUSTERED ([ID_plan_i_program] ASC);
GO

-- Creating primary key on [ID_Pohadjanje] in table 'Pohadjanjes'
ALTER TABLE [dbo].[Pohadjanje]
ADD CONSTRAINT [PK_Pohadjanje]
    PRIMARY KEY CLUSTERED ([ID_Pohadjanj] ASC);
GO

-- Creating primary key on [ID_Predmet] in table 'Predmets'
ALTER TABLE [dbo].[Predmet]
ADD CONSTRAINT [PK_Predmet]
    PRIMARY KEY CLUSTERED ([ID_Predmet] ASC);
GO

-- Creating primary key on [ID_Predmet_Hijerarhija] in table 'Predmet_Hijerarhija'
ALTER TABLE [dbo].[Predmet_Hijerarhija]
ADD CONSTRAINT [PK_Predmet_Hijerarhija]
    PRIMARY KEY CLUSTERED ([ID_Predmet_Hijerarhija] ASC);
GO

-- Creating primary key on [ID_Prijava] in table 'Prijavas'
ALTER TABLE [dbo].[Prijava]
ADD CONSTRAINT [PK_Prijava]
    PRIMARY KEY CLUSTERED ([ID_Prijava] ASC);
GO

-- Creating primary key on [ID_Prof] in table 'Profesors'
ALTER TABLE [dbo].[Profesor]
ADD CONSTRAINT [PK_Profesor]
    PRIMARY KEY CLUSTERED ([ID_Prof] ASC);
GO

-- Creating primary key on [ID_smjer] in table 'Smjers'
ALTER TABLE [dbo].[Smjer]
ADD CONSTRAINT [PK_Smjer]
    PRIMARY KEY CLUSTERED ([ID_smjer] ASC);
GO

-- Creating primary key on [ID_student] in table 'Students'
ALTER TABLE [dbo].[Student]
ADD CONSTRAINT [PK_Student]
    PRIMARY KEY CLUSTERED ([ID_student] ASC);
GO

-- Creating primary key on [ID_Student_tip] in table 'Student_tip'
ALTER TABLE [dbo].[Student_tip]
ADD CONSTRAINT [PK_Student_tip]
    PRIMARY KEY CLUSTERED ([ID_Student_tip] ASC);
GO

-- Creating primary key on [ID_studij] in table 'Studijs'
ALTER TABLE [dbo].[Studij]
ADD CONSTRAINT [PK_Studij]
    PRIMARY KEY CLUSTERED ([ID_studij] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID_tip] in table 'Tip_Nastave'
ALTER TABLE [dbo].[Tip_Nastave]
ADD CONSTRAINT [PK_Tip_Nastave]
    PRIMARY KEY CLUSTERED ([ID_tip] ASC);
GO

-- Creating primary key on [ID_Tipovi_studenata] in table 'Tipovi_studenata'
ALTER TABLE [dbo].[Tipovi_studenata]
ADD CONSTRAINT [PK_Tipovi_studenata]
    PRIMARY KEY CLUSTERED ([ID_Tipovi_studenata] ASC);
GO

-- Creating primary key on [JMBG], [Ime], [Prezime], [tip_studenta] in table 'Potvrda_pripadnosti'
ALTER TABLE [dbo].[Potvrda_pripadnosti]
ADD CONSTRAINT [PK_Potvrda_pripadnosti]
    PRIMARY KEY CLUSTERED ([JMBG], [Ime], [Prezime], [tip_studenta] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ID_studij] in table 'Godinas'
ALTER TABLE [dbo].[Godina]
ADD CONSTRAINT [FK__Godina__ID_studi__6442E2C9]
    FOREIGN KEY ([ID_studij])
    REFERENCES [dbo].[Studij]
        ([ID_studij])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Godina__ID_studi__6442E2C9'
CREATE INDEX [IX_FK__Godina__ID_studi__6442E2C9]
ON [dbo].[Godina]
    ([ID_studij]);
GO

-- Creating foreign key on [ID_Godina] in table 'Godina_Studij'
ALTER TABLE [dbo].[Godina_Studij]
ADD CONSTRAINT [fk_Godina_id]
    FOREIGN KEY ([ID_Godina])
    REFERENCES [dbo].[Godina]
        ([ID_godina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Godina_id'
CREATE INDEX [IX_fk_Godina_id]
ON [dbo].[Godina_Studij]
    ([ID_Godina]);
GO

-- Creating foreign key on [ID_Studij] in table 'Godina_Studij'
ALTER TABLE [dbo].[Godina_Studij]
ADD CONSTRAINT [FK__Godina_St__ID_St__19DFD96B]
    FOREIGN KEY ([ID_Studij])
    REFERENCES [dbo].[Studij]
        ([ID_studij])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Godina_St__ID_St__19DFD96B'
CREATE INDEX [IX_FK__Godina_St__ID_St__19DFD96B]
ON [dbo].[Godina_Studij]
    ([ID_Studij]);
GO

-- Creating foreign key on [ID_Godina_Studij] in table 'Godina_Studij'
ALTER TABLE [dbo].[Godina_Studij]
ADD CONSTRAINT [FK_Godina_Studij_Godina_Studij]
    FOREIGN KEY ([ID_Godina_Studij])
    REFERENCES [dbo].[Godina_Studij]
        ([ID_Godina_Studij])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ID_Godina_Studij] in table 'Plan_i_program'
ALTER TABLE [dbo].[Plan_i_program]
ADD CONSTRAINT [fk_Godina_studij_ID]
    FOREIGN KEY ([ID_Godina_Studij])
    REFERENCES [dbo].[Godina_Studij]
        ([ID_Godina_Studij])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Godina_studij_ID'
CREATE INDEX [IX_fk_Godina_studij_ID]
ON [dbo].[Plan_i_program]
    ([ID_Godina_Studij]);
GO

-- Creating foreign key on [ID_predmet] in table 'Plan_i_program'
ALTER TABLE [dbo].[Plan_i_program]
ADD CONSTRAINT [FK__Plan_i_pr__ID_pr__09A971A2]
    FOREIGN KEY ([ID_predmet])
    REFERENCES [dbo].[Predmet]
        ([ID_Predmet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Plan_i_pr__ID_pr__09A971A2'
CREATE INDEX [IX_FK__Plan_i_pr__ID_pr__09A971A2]
ON [dbo].[Plan_i_program]
    ([ID_predmet]);
GO

-- Creating foreign key on [ID_tipn] in table 'Plan_i_program'
ALTER TABLE [dbo].[Plan_i_program]
ADD CONSTRAINT [FK__Plan_i_pr__ID_ti__0A9D95DB]
    FOREIGN KEY ([ID_tipn])
    REFERENCES [dbo].[Tip_Nastave]
        ([ID_tip])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Plan_i_pr__ID_ti__0A9D95DB'
CREATE INDEX [IX_FK__Plan_i_pr__ID_ti__0A9D95DB]
ON [dbo].[Plan_i_program]
    ([ID_tipn]);
GO

-- Creating foreign key on [ID_plan_i_program] in table 'Pohadjanjes'
ALTER TABLE [dbo].[Pohadjanje]
ADD CONSTRAINT [FK__Pohadjanj__ID_pl__498EEC8D]
    FOREIGN KEY ([ID_plan_i_program])
    REFERENCES [dbo].[Plan_i_program]
        ([ID_plan_i_program])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pohadjanj__ID_pl__498EEC8D'
CREATE INDEX [IX_FK__Pohadjanj__ID_pl__498EEC8D]
ON [dbo].[Pohadjanje]
    ([ID_plan_i_program]);
GO

-- Creating foreign key on [ID_profesor] in table 'Pohadjanjes'
ALTER TABLE [dbo].[Pohadjanje]
ADD CONSTRAINT [FK__Pohadjanj__ID_pr__489AC854]
    FOREIGN KEY ([ID_profesor])
    REFERENCES [dbo].[Profesor]
        ([ID_Prof])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pohadjanj__ID_pr__489AC854'
CREATE INDEX [IX_FK__Pohadjanj__ID_pr__489AC854]
ON [dbo].[Pohadjanje]
    ([ID_profesor]);
GO

-- Creating foreign key on [ID_Student] in table 'Pohadjanjes'
ALTER TABLE [dbo].[Pohadjanje]
ADD CONSTRAINT [FK__Pohadjanj__ID_St__47A6A41B]
    FOREIGN KEY ([ID_Student])
    REFERENCES [dbo].[Students]
        ([ID_student])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Pohadjanj__ID_St__47A6A41B'
CREATE INDEX [IX_FK__Pohadjanj__ID_St__47A6A41B]
ON [dbo].[Pohadjanje]
    ([ID_Student]);
GO

-- Creating foreign key on [ID_Predmet] in table 'Predmet_Hijerarhija'
ALTER TABLE [dbo].[Predmet_Hijerarhija]
ADD CONSTRAINT [FK__Predmet_H__ID_Pr__3C34F16F]
    FOREIGN KEY ([ID_Predmet])
    REFERENCES [dbo].[Predmet]
        ([ID_Predmet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Predmet_H__ID_Pr__3C34F16F'
CREATE INDEX [IX_FK__Predmet_H__ID_Pr__3C34F16F]
ON [dbo].[Predmet_Hijerarhija]
    ([ID_Predmet]);
GO

-- Creating foreign key on [ID_Predmet_Uslov] in table 'Predmet_Hijerarhija'
ALTER TABLE [dbo].[Predmet_Hijerarhija]
ADD CONSTRAINT [FK__Predmet_H__ID_Pr__3D2915A8]
    FOREIGN KEY ([ID_Predmet_Uslov])
    REFERENCES [dbo].[Predmet]
        ([ID_Predmet])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Predmet_H__ID_Pr__3D2915A8'
CREATE INDEX [IX_FK__Predmet_H__ID_Pr__3D2915A8]
ON [dbo].[Predmet_Hijerarhija]
    ([ID_Predmet_Uslov]);
GO

-- Creating foreign key on [ID_smjer] in table 'Studijs'
ALTER TABLE [dbo].[Studij]
ADD CONSTRAINT [FK__Studij__ID_smjer__03F0984C]
    FOREIGN KEY ([ID_smjer])
    REFERENCES [dbo].[Smjer]
        ([ID_smjer])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Studij__ID_smjer__03F0984C'
CREATE INDEX [IX_FK__Studij__ID_smjer__03F0984C]
ON [dbo].[Studij]
    ([ID_smjer]);
GO

-- Creating foreign key on [ID_student] in table 'Tipovi_studenata'
ALTER TABLE [dbo].[Tipovi_studenata]
ADD CONSTRAINT [FK__Tipovi_st__ID_st__41EDCAC5]
    FOREIGN KEY ([ID_student])
    REFERENCES [dbo].[Students]
        ([ID_student])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tipovi_st__ID_st__41EDCAC5'
CREATE INDEX [IX_FK__Tipovi_st__ID_st__41EDCAC5]
ON [dbo].[Tipovi_studenata]
    ([ID_student]);
GO

-- Creating foreign key on [ID_Student_tip] in table 'Tipovi_studenata'
ALTER TABLE [dbo].[Tipovi_studenata]
ADD CONSTRAINT [FK__Tipovi_st__ID_St__42E1EEFE]
    FOREIGN KEY ([ID_Student_tip])
    REFERENCES [dbo].[Student_tip]
        ([ID_Student_tip])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Tipovi_st__ID_St__42E1EEFE'
CREATE INDEX [IX_FK__Tipovi_st__ID_St__42E1EEFE]
ON [dbo].[Tipovi_studenata]
    ([ID_Student_tip]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------