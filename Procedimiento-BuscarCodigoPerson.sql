create proc BuscarCodigoPerson
	@PersonID nvarchar(50)
as
select * from Person where PersonID like '%'+@PersonID+'%'