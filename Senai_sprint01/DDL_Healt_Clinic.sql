-- DDL'

CREATE DATABASE Health_Clinic_Matheus;

USE Health_Clinic_Matheus;

------------------------------------------------------
/* Sem chave estrangeira */
CREATE TABLE TipoUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(20) NOT NULL UNIQUE
)
 
CREATE TABLE Situacao
(
	IdSituacao INT PRIMARY KEY IDENTITY,
	Titulo VARCHAR(50) NOT NULL
)

CREATE TABLE Especialidade
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	Tipo VARCHAR(50) NOT NULL
)

CREATE TABLE Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	Endereco VARCHAR(100) NOT NULL,
	CNPJ CHAR(14) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(80) NOT NULL,
	RazaoSocial VARCHAR(80) NOT NULL,
	HorarioFuncionamento TIME NOT NULL
)
alter table Clinica 
alter column HorarioFuncionamento Varchar(30) not null

------------------------------------------------------
/* Com chave estrangeira */
CREATE TABLE Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(IdTipoUsuario),
	Email VARCHAR(80) NOT NULL,
	Senha CHAR(10) NOT NULL,
	Nome VARCHAR(80) NOT NULL
)

CREATE TABLE Pacientes
(
	IdPacientes INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	RG CHAR(10) NOT NULL UNIQUE,
	CPF CHAR(11) NOT NULL UNIQUE,
	DataNascimento DATE NOT NULL,
	Telefone VARCHAR(15) NOT NULL,
	CEP CHAR(10) NOT NULL,
	Endereco VARCHAR(100) NOT NULL
)

CREATE TABLE Medicos
(
	IdMedicos INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdClinica INT FOREIGN KEY REFERENCES Clinica(IdClinica),
	IdEspecialidade INT FOREIGN KEY REFERENCES Especialidade(IdEspecialidade),
	CRM CHAR(12) NOT NULL UNIQUE
)

CREATE TABLE Consultas
(
	IdConsultas INT PRIMARY KEY IDENTITY,
	IdPacientes INT FOREIGN KEY REFERENCES Pacientes(IdPacientes),
	IdMedicos INT FOREIGN KEY REFERENCES Medicos(IdMedicos),
	IdSituacao INT FOREIGN KEY REFERENCES Situacao(IdSituacao),
	Prontuario VARCHAR(80) NOT NULL,
	DataAgendamento DATE NOT NULL,
	Descricao VARCHAR(80) NOT NULL
)

CREATE TABLE FeedBack
(
	IdFeedBack INT PRIMARY KEY IDENTITY,
	IdConsultas INT FOREIGN KEY REFERENCES Consultas(IdConsultas),
	Descricao VARCHAR(80) NOT NULL
)
-----------------------------------------------------

SELECT * FROM TipoUsuario
SELECT * FROM Situacao
SELECT * FROM Especialidade
SELECT * FROM Clinica
SELECT * FROM Usuario
SELECT * FROM Pacientes
SELECT * FROM Medicos
SELECT * FROM Consultas
SELECT * FROM FeedBack