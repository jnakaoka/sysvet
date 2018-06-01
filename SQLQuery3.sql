CREATE TABLE Pet(
	Id int primary key IDENTITY (1, 1) not null,
	Nome varchar(300),
	Tipo varchar(300),
	Idade int,
	Flg_Adotado int,
	Id_Pessoa int FOREIGN KEY (ID_Pessoa) REFERENCES Pessoa (Id),
	Dt_Adocao Datetime 
        
)