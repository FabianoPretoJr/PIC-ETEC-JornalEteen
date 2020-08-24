CREATE DATABASE JNETEEN;

GO

USE JNETEEN;

CREATE TABLE Noticia(
	Id_Noticia		INT IDENTITY,
	Nome			VARCHAR(50)		NOT NULL,
	Autor			VARCHAR(50)		NOT NULL,
	Categoria		VARCHAR(15)		NOT NULL,
	Data			DATETIME		NOT NULL,
	Imagem			VARCHAR(50)		NOT NULL,	
	Materia			VARCHAR(1000)	NOT NULL,
	Visibilidade	INT				NOT NULL, -- 1 == OCULTO || 2 == VISIVEL
	CONSTRAINT PK_Noticia_Id_Noticia PRIMARY KEY(Id_Noticia)
);

select * from Noticia;

CREATE TABLE Comentario(
	Id_Comentario	INT IDENTITY,
	Nome			VARCHAR(50)		NOT NULL,
	Email			VARCHAR(30)		NOT NULL,
	Mensagem		VARCHAR(300)	NOT NULL,
	Data			DATETIME		NOT NULL,
	Visibilidade	INT				NOT NULL, -- 1 == OCULTO || 2 == VISIVEL
	Id_Noticia		INT,
	CONSTRAINT PK_Comentario_Id_Comentario PRIMARY KEY(Id_Comentario),
	CONSTRAINT FK_Comentario_Noticia FOREIGN KEY(Id_Noticia) REFERENCES Noticia(Id_Noticia)
);

select * from Comentario;

CREATE TABLE Administrador(
	Id_Adm			INT IDENTITY,
	Usuario			VARCHAR(20)		NOT NULL,
	Senha			VARCHAR(40)		NOT NULL,
	CONSTRAINT PK_Administrador_Id_Adm PRIMARY KEY(Id_Adm)
);

insert into Administrador(Usuario, Senha)values ('Admin', '123456');

select * from Administrador;

CREATE TABLE Banner(
	Id_Banner		INT IDENTITY,
	Imagem			VARCHAR(50)		NOT NULL,
	Categoria		VARCHAR(15)		NOT NULL,
	CONSTRAINT PK_Banner_Id_Banner PRIMARY KEY(Id_Banner)
);

select * from Banner;

CREATE TABLE Contato(
	Id_Contato		INT IDENTITY,
	Nome			VARCHAR(50)		NOT NULL,
	Email			VARCHAR(30)		NOT NULL,
	Mensagem		VARCHAR(300)	NOT NULL,
	CONSTRAINT PK_Contato_Id_Contato PRIMARY KEY(Id_Contato)
);

select * from Contato;