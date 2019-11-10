use master

create database Fusalmo
GO
use Fusalmo
GO

create table Transaccional(
PagoEfectuado money NOT NULL,
FechaDerealizacion datetime NOT NULL,
DUI Varchar (10) NOT NULL
)
GO
create table Entidad(
DUI Varchar (10) PRIMARY key NOT NULL,
Nombre Varchar (30) NOT NULL,
Apellido Varchar (30) NOT NULL,
Direccion Varchar (30) NOT NULL,
check (DUI Like'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][-][0-9]'))
GO
create table Vehiculos(
Tipoautomovil Varchar (30) NOT NULL,
Placas varchar (8) NOT NULL,
Color  Varchar (30) NOT NULL,
Modelo Varchar (30) NOT NULL,
Año char (4) NOT NULL,
DUI Varchar (10) NOT NULL,
check (Placas Like'[a-z][0-9][0-9][0-9][-][0-9][0-9][0-9]'))
GO
create table Deudores(
DUI Varchar (10) NOT NULL,
CantidadDeuda money NOT NULL,

)
GO

alter table  Transaccional
add constraint FK_dui1
foreign key (DUI) references Entidad(DUI)
on update cascade
on delete cascade
GO


alter table  Vehiculos
add constraint FK_dui2
foreign key (DUI) references Entidad(DUI)
on update cascade
on delete cascade
GO
alter table  Deudores
add constraint FK_dui3
foreign key (DUI) references Entidad(DUI)
on update cascade
on delete cascade
GO

insert into Entidad values
('05491832-8','Gerson','Lopez','San Salvador')


insert into Vehiculos values
('Sedan','P742561','Azul','Yaris','2008','05491832-8')

select*from Entidad
select*from Vehiculos

