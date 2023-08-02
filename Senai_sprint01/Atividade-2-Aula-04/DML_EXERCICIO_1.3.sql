--DML MANIPULACAO INSERIR DADOS
INSERT INTO Clinica(Endereco)
VALUES('Rua Alacran 156')

INSERT INTO Raca(Nome)
VALUES('PUG')

INSERT INTO TipoPet(Nome)
VALUES('CANINO')

INSERT INTO Dono(Nome)
VALUES('Marcos')
---------------------------------------------
--COM CHAVE ESTRANGEIRA
INSERT INTO Veterinario(IdClinica,Nome)
VALUES(1,'Rua Alacran 156')

INSERT INTO Pets(IdTipoPet,IdRaca,IdDono,Nome,DataNascimento)
VALUES(1,1,1,'Layla',28-05-2019)

UPDATE Pets
SET DataNascimento = '28052019' WHERE IdPets = 3

INSERT INTO Atendimento(IdPets,IdVeterinario,Registro)
VALUES(3,1,'123456')
---------------------------------------------
SELECT * FROM Clinica
SELECT * FROM Raca
SELECT * FROM TipoPet
SELECT * FROM Veterinario
SELECT * FROM Dono
SELECT * FROM Pets
SELECT * FROM Atendimento