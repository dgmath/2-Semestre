-- DQL

/*
Criar script que exiba os seguintes dados:

- Id Consulta
- Data da Consulta
- Horario da Consulta
- Nome da Clinica
- Nome do Paciente
- Nome do Medico
- Especialidade do Medico
- CRM
- Prontuário ou Descricao
- FeedBack(Comentario da consulta)

Criar função para retornar os médicos de uma determinada especialidade

*Criar procedure para retornar a idade de um determinado usuário específico
*/

SELECT 
	Consultas.IdConsultas AS [Id da Consulta],
	Consultas.DataAgendamento AS [Data da Consulta],
	Consultas.HorarioConsulta AS [Horário da Consulta],
	Clinica.NomeFantasia AS [Nome da Clinica],
	Usuario_Paciente.Nome AS Paciente,
	Usuario.Nome AS Medico,
	Especialidade.Tipo AS Especialidade,
	Medicos.CRM,
	Consultas.Prontuario,
	FeedBack.Descricao AS FeedBack




FROM
	Consultas
	LEFT JOIN Medicos ON Consultas.IdMedicos = Medicos.IdMedicos
	
	
	INNER JOIN Especialidade ON  Especialidade.IdEspecialidade = Medicos.IdEspecialidade

	
	INNER JOIN Clinica ON  Medicos.IdClinica = Clinica.IdClinica

	
	LEFT JOIN FeedBack ON FeedBack.IdConsultas = Consultas.IdConsultas

	LEFT JOIN Pacientes ON Consultas.IdPacientes = Pacientes.IdPacientes

	INNER JOIN Usuario
	ON Medicos.IdUsuario = Usuario.IdUsuario

	INNER JOIN Usuario AS Usuario_Paciente
	ON Pacientes.IdUsuario = Usuario_Paciente.IdUsuario
	

	/*SELECT 
	USUARIO.Nome AS PACIENTE,
	
	*
	FROM CONSULTAS
	INNER JOIN Medicos ON Medicos.IdMedicos = Consultas.IdMedicos
	INNER JOIN Pacientes ON Pacientes.IdPacientes = Consultas.IdPacientes
	INNER JOIN Usuario ON Usuario.IdUsuario = Pacientes.IdPacientes
		*/




	CREATE FUNCTION BuscaMedicos
	(
		@Especialidade_M VARCHAR (100) 
	)
	RETURNS TABLE
	AS
	RETURN
	(
	SELECT MedicoUsuario.Nome AS Médico,
	Especialidade.Tipo AS Especialidade
	FROM Especialidade
	INNER JOIN Medicos ON Medicos.IdEspecialidade = Especialidade.IdEspecialidade
	INNER JOIN Usuario AS MedicoUsuario ON Medicos.IdUsuario = MedicoUsuario.IdUsuario
	WHERE Especialidade.Tipo = @Especialidade_M
	);

	SELECT * from BuscaMedicos('Clínico Geral')





	