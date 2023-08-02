--DML - INSERIR DADOS NAS TABELAS

USE Exercicio_1_1;

--INSERIR DADOS NA TABELA
INSERT INTO Pessoa(Nome,CNH)
VALUES('Vitória','1234567890'),('Vinicius','0987654321')

--INSERT INTO Pessoa VALUES('Carlos','1234567890')

-----------------------------------------------------------

INSERT INTO Email(IdPessoa,Endereco)
VALUES(1,'vitoria@gmail.com'),(2,'vinicius@gmail.com')

-----------------------------------------------------------

INSERT INTO Telefone(IdPessoa,Numero)
VALUES(1,'929823454'),(2,'927643267')



SELECT * FROM Pessoa;
SELECT * FROM Email;
SELECT * FROM Telefone;
