/* create database TrabajadoresPrueba*/

select * from dbo.Departamento
select * from dbo.Provincia where IdDepartamento = 15
select * from dbo.Distrito
select * from dbo.Trabajadores

Alter TABLE [dbo].[Trabajadores] ADD [NroDocumento] [varchar](500) NULL


alter proc PR_TRABA
as
begin
select A.Id, A.TipoDocumento, A.NroDocumento,A.Nombres, A.Sexo, B.NombreDepartamento, C.NombreProvincia, D.NombreDistrito
from dbo.Trabajadores A 
inner join Departamento B
on B.Id = A.IdDepartamento
inner join dbo.Provincia C
on C.Id = A.IdProvincia
inner join dbo.Distrito D
on D.Id = A.IdDistrito
end

exec PR_TRABA