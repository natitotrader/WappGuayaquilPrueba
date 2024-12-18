USE master;
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'PrBancoGuayaquil')
BEGIN

	ALTER DATABASE PrBancoGuayaquil
	SET SINGLE_USER WITH ROLLBACK IMMEDIATE

	-- Elimino la base de datos
	DROP DATABASE PrBancoGuayaquil

END

CREATE DATABASE PrBancoGuayaquil ON
(NAME = PrBancoGuayaquil_dat,
    FILENAME = 'C:\WappGuayaquilPrueba\BaseDatos\DATA\PrBancoGuayaquil.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5)
LOG ON
(NAME = PrBancoGuayaquil_log,
    FILENAME = 'C:\WappGuayaquilPrueba\BaseDatos\DATA\PrBancoGuayaquil.ldf',
    SIZE = 5 MB,
    MAXSIZE = 25 MB,
    FILEGROWTH = 5 MB);
GO