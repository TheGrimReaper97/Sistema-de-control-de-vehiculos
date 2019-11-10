use master
create database Fusalmo

use Fusalmo

create table Transaccional(
PagoEfectuado money NOT NULL,
FechaDerealizacion date NOT NULL,
DUI Varchar (30) NOT NULL,
)

create table Entidad(
DUI Varchar (30) PRIMARY key NOT NULL,
Nombre Varchar (30) NOT NULL,
Apellido Varchar (30) NOT NULL,
Direccion Varchar (30) NOT NULL,
)


create table Vehiculos(
Tipoautomovil Varchar (30) NOT NULL,
Placas char (7) PRIMARY key NOT NULL,
Color  Varchar (30) NOT NULL,
Modelo Varchar (30) NOT NULL,
Año char (4) NOT NULL,
DUI Varchar (30) NOT NULL,
)
create table Deudores(
DUI Varchar (30) NOT NULL,
CantidadDeuda money NOT NULL,
Placa char (7) NOT NULL
)


alter table  Transaccional
add constraint FK_dui1
foreign key (DUI) references Entidad(DUI)



alter table  Vehiculos
add constraint FK_dui2
foreign key (DUI) references Entidad(DUI)

alter table  Deudores
add constraint FK_Placa1
foreign key (Placa) references Vehiculos(Placas)




insert into Entidad values
('05491832-8','Gerson','Lopez','San Salvador')


insert into Vehiculos values
('Sedan','P742561','Azul','Yaris','2008','05491832-8')

select * from Vehiculos

 
