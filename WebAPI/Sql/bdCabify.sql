USE master
GO

CREATE DATABASE bdCabify
GO

USE bdCabify
GO

CREATE TABLE [dbo].[TipoPago](
	[IdTipoPago] [int] IDENTITY(1,1)PRIMARY KEY NOT NULL,
	[NomTipo] [varchar](40) NOT NULL
)
GO


CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Correo]  [varchar](80) NULL,
	[Contrasennia]  [varchar](90) NULL
)
GO

CREATE TABLE [dbo].[Tarjeta](
    [IdTarjeta] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdUsuario] [int]  NOT NULL,
	[NumeroTarjeta] VARCHAR(30) NULL,
	[FechaCaducidad] [datetime] NULL,
	[CVV] [INT] NULL,
	FOREIGN KEY(IdUsuario) REFERENCES USUARIOS(IdUsuario)
)
GO


CREATE TABLE [dbo].[Pago](
	[IdPago] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Monto] [numeric](18, 2) NULL,
	[IdTipoPago] [int] NULL,
	[Descripcion] VARCHAR(500) NULL,
	[FechaPago] [datetime] NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTarjeta] [int] NOT NULL,
	FOREIGN KEY(IdTarjeta) REFERENCES TARJETA(IdTarjeta),
	FOREIGN KEY(IdTipoPago) REFERENCES TipoPago(IdTipoPago),
	FOREIGN KEY(IdUsuario) REFERENCES USUARIOS(IdUsuario)
)
GO

CREATE TABLE DetallePago(
	IdDetPago int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	IdPago int,
	NomChofer varchar(100),
	Placa varchar(50),
	NumeroTarjeta  VARCHAR(30),
	FOREIGN KEY(IdPago) REFERENCES Pago(IdPago)
)
GO



insert into [Usuarios] values('Juan','Campos','1624643@utp.edu.pe' , '123456')

insert into TipoPago values ('Tarjeta de Credito/Debito')
insert into TipoPago values ('Efectivo')
insert into TipoPago values ('Yape')

select * from TipoPago
select * from Usuarios
select * from Tarjeta
select * from PAGO
select * from DetallePago

