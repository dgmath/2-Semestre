--DQL

-- listar as pessoas em ordem alfabética reversa, mostrando seus telefones, seus e-mails e suas CNHs

--SCRIPT SEM USAR JOIN

SELECT 
	P.Nome as Nome_Usuario,
	Telefone.Numero AS Telefone,
	E.Endereco AS Email, 
	P.CNH

FROM 
	Pessoa AS P,
	Telefone,
	Email AS E

WHERE 
	P.IdPessoa = E.IdPessoa
	AND P.IdPessoa = Telefone.IdPessoa

ORDER BY 
	Nome DESC



INSERT INTO Pessoa
VALUES
('Catarina', '234567890'),
('Rebecca', '987654345'),
('Victor', '864324567'),
('Lucas', '234565436');

SELECT * FROM Pessoa