create proc BuscarCursoTitulo  
 @Titulo nvarchar(50)  
as  
 select * from Course where Title like '%'+@Titulo+'%'