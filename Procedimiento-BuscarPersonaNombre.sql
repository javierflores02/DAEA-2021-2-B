create proc BuscarPersonaNombre  
 @FirstName nvarchar(50)  
as  
 select * from Person where FirstName like '%'+@FirstName+'%'