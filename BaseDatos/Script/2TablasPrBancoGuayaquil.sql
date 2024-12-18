USE PrBancoGuayaquil
GO

IF OBJECT_ID('Pbg_Persona', 'U') IS NOT NULL
	Drop table Pbg_Persona
GO

IF OBJECT_ID('Pbg_Usuario', 'U') IS NOT NULL
	Drop table Pbg_Usuario
GO



SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


CREATE TABLE Pbg_Persona
(
	Identificador					INT IDENTITY(1,1),
	Nombre							NVARCHAR(120),
	Apellido						NVARCHAR(120),
	TipoIdentificacion				VARCHAR(3),
	NumeroIdentificacion			VARCHAR(13),
	Email							VARCHAR(120),	
	FechaCreacion					DATETIME DEFAULT GETDATE(),  -- Valor predeterminado con GETDATE()
	ConcatenaNombresApellidos		AS (Nombre + ' ' + Apellido) PERSISTED, -- Columna calculada
    ConcatenaIdentificacionTipo		AS (TipoIdentificacion + '-' + NumeroIdentificacion) PERSISTED, -- Columna calculada
	constraint Pk_Pbg_Persona primary key nonclustered(Identificador)
)
go


CREATE TABLE Pbg_Usuario
(
	Identificador					INT IDENTITY(1,1),
	Usuario							NVARCHAR(120),
	Pass							NVARCHAR(120),	
	FechaCreacion					DATETIME DEFAULT GETDATE(),  -- Valor predeterminado con GETDATE()
	constraint Pk_Pbg_Usuario primary key nonclustered(Identificador)
)
go





--Inserto datos de pruebas
INSERT INTO Pbg_Persona 
(Nombre, Apellido, TipoIdentificacion, NumeroIdentificacion, Email)
VALUES ('LUIS RENE','GUALOTUNA GUALOTUNA', 'CED','1716194046','simarene@hotmail.com');

INSERT INTO Pbg_Persona 
(Nombre, Apellido, TipoIdentificacion, NumeroIdentificacion, Email)
VALUES ('BERNARDO AGUSTIN','GUALOTUNA CHIGUANO', 'CED','1754062436','agustingch@hotmail.com');

INSERT INTO Pbg_Persona 
(Nombre, Apellido, TipoIdentificacion, NumeroIdentificacion, Email)
VALUES ('CARLOS ROBERTO','GARCIA SUAREZ', 'CED','1754024536','carlos@hotmail.com');


--select * from Pbg_Persona
/*
INSERT INTO Pbg_Usuario 
(Usuario, Pass)
VALUES ('renegualotuna','rene2024*');
*/
--select * from Pbg_Usuario

