/************************************************************************/
/*   Nombre fisico: sp_consulta_persona.sql								*/
/*   Nombre logico: sp_consulta_persona									*/
/*   DESCRIPCON: store procedure para consultar las personas creadas	*/
/************************************************************************/
/*   Fecha creacion: 13-Dic-2024										*/
/*   Autor: Rene Gualotuna												*/
/************************************************************************/
/*                              MODIFICACIONES                          */
/*    FECHA     AUTOR           	CAUSA								*/
/*							      										*/
/*							      										*/
/************************************************************************/
use PrBancoGuayaquil
go
 
if exists (select * from sysobjects where name = 'sp_consulta_persona')
	drop proc sp_consulta_persona
go

CREATE PROCEDURE sp_consulta_persona (
					@i_CodicionBusqueda		varchar(24) = null,	--Condicion de Busqueda
					@i_DatoBusqueda			nvarchar(64) = null	--Dato de Busqueda
					)

AS
---------------------------------------------------
---	DECLARACION DE VARIABLES DE TRABAJO	---
---------------------------------------------------
DECLARE
	@w_mensaje		varchar(128),
	@w_codreturn		int,
	@w_oficna		varchar(36)


BEGIN

	---  Aplico COndiciones de busqueda
	if @i_CodicionBusqueda = 'Completa'
	BEGIN
		select * from Pbg_Persona
	END
	if @i_CodicionBusqueda = 'NumeroIdentificacion'
	BEGIN
		select * from Pbg_Persona where NumeroIdentificacion=@i_DatoBusqueda
	END
	if @i_CodicionBusqueda = 'Email'
	BEGIN
		select * from Pbg_Persona where Email=@i_DatoBusqueda
	END
	if @i_CodicionBusqueda = 'Nombre'
	BEGIN
		select * from Pbg_Persona where Nombre like '%'+@i_DatoBusqueda+'%'
	END

	if @i_CodicionBusqueda = 'Apellido'
	BEGIN
		select * from Pbg_Persona where Apellido like '%'+@i_DatoBusqueda+'%'
	END

--return 0

END                                                
go

--exec PrBancoGuayaquil..sp_consulta_persona 'Apellido','SUA'
