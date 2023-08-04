--DML MANIPULACAO INSERIR DADOS

USE O_Exercicio_1_3;

INSERT INTO Clinica(Endereco)
VALUES('Rua Alacran 156'),('Rua Longa Distância 156')

INSERT INTO Raca(Nome)
VALUES('SHI')

INSERT INTO TipoPet(Nome)
VALUES('AVE')

INSERT INTO Dono(Nome)
VALUES('Marcos'),('Ana')
---------------------------------------------
--COM CHAVE ESTRANGEIRA
INSERT INTO Veterinario(IdClinica,Nome,CRMV)
VALUES(1,'Eduardo','12345678'),(2,'Catarina','87654321')


INSERT INTO Pets(IdTipoPet,IdRaca,IdDono,Nome,DataNascimento)
VALUES(1,1,2,'Layla','08/05/2009'),(2,2,1,'Mel','28/05/2019')

INSERT INTO Atendimento(IdPets,IdVeterinario,Registro)
VALUES(1,3,'123456'),(2,4,'654321')
---------------------------------------------
SELECT * FROM Clinica
SELECT * FROM Raca
SELECT * FROM TipoPet
SELECT * FROM Veterinario
SELECT * FROM Dono
SELECT * FROM Pets
SELECT * FROM Atendimento