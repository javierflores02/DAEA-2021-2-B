create proc BuscarPersonaApellido
	@LastName nvarchar(50)
as
select * from Person where LastName like '%'+@LastName+'%'