-------- CREATE DATABASE -------

USE master;
GO

CREATE DATABASE WalletKataDb;
commit;

GO

---------------------------------

 -------- CREATE TABLES ---------- 

-- 1 - Tabla 
CREATE TABLE tipos_monedas(
	id int identity(1,1) NOT NULL,
	modena varchar (10) NOT NULL,
	descripcion varchar(50),
	activo char NOT NULL
);
go

--PK
alter table tipos_monedas
add constraint PK_tipos_monedas_id
primary key(id);
go

----------------------------------------

-- 2 - Tabla
CREATE TABLE saldos(
id int identity(1,1) NOT NULL,
id_tipo_modena int NOT NULL,
importe int NOT NULL
);
go

-- PK
alter table saldos
add constraint PK_saldos_id
primary key(id);

-- FK
ALTER TABLE saldos 
ADD  CONSTRAINT [FK_Tipos_Monedas_id_tipo_modena] 
FOREIGN KEY(id_tipo_modena)
REFERENCES [dbo].[tipos_monedas] ([Id])
GO

-------------------------------------------

----- INSERT'S TABLAS ---------------------

-- 1 - INSERTS
insert into tipos_monedas values ('ARS', 'Peso moneda de Argentina','A');
insert into tipos_monedas values ('USD', 'Dolar moneda estadounidense','A');
insert into tipos_monedas values ('EUR', 'Euro moneda europea','A');
insert into tipos_monedas values ('R$', 'Real moneda de Brasil','N');


-- 2 - INSERTS

insert into saldos values (3, 5000.00);
insert into saldos values (4, 8000.00);
insert into saldos values (1, 2000.00);
insert into saldos values (2, 3000.00);


--------------------------------------------------