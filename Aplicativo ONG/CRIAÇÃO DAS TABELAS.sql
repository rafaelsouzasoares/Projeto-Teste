use ong_db
GO

if(OBJECT_ID('ong_db.dbo.projeto_tb') is null)
begin
	create table dbo.projeto_tb
	(
		id int primary key identity(1,1) not null,
		nome_projeto varchar(100) not null,
		cpnj varchar(14) not null,
		senha varchar(50) not null,
		endereco varchar(500),
		telefone varchar(10),
		email varchar(100),
		tipo varchar(50),
		data_inicio date,
		descricao varchar(300) not null,
	)
end

GO

if(OBJECT_ID('ong_db.dbo.voluntario_tb') is null)
begin
	create table dbo.voluntario_tb
	(
		id int primary key identity(1,1) not null, 
		nome_voluntario varchar(100) not null,
		cpf varchar(11) not null,
		senha varchar(50) not null,
		data_nascimento date,
		endereco varchar(100),
		telefone varchar(10),
		email varchar(100),
		profissao varchar(100),
		sexo varchar(1)
	)
end

GO

if(OBJECT_ID('ong_db.dbo.voluntariado_tb') is null)
begin
	create table dbo.voluntariado_tb
	(
		id_projeto int not null,
		id_voluntario int not null,
		data_entrada date,
		data_saida date,

		Constraint pk_voluntariado primary key (id_projeto, id_voluntario),
		Constraint fk_voluntariado_projeto foreign key (id_projeto) references dbo.projeto_tb(id),
		Constraint fk_voluntariado_voluntario foreign key (id_voluntario) references dbo.voluntario_tb(id)
	)
end

GO

if(OBJECT_ID('ong_db.dbo.ideia_tb') is null)
begin
	create table dbo.ideia_tb
	(
		id int identity(1,1) not null,
		titulo varchar(100) not null,
		descricao varchar(300) not null
	)
end

GO

if(OBJECT_ID('ong_db.dbo.comunicado_projeto_tb') is null)
begin
	create table dbo.comunicado_projeto_tb
	(
		id int identity(1,1) not null,
		id_projeto int not null,
		titulo varchar(100) not null,
		descricao varchar(500) not null,
		data_inicio date,

		Constraint pk_comunicado primary key (id, id_projeto),
		Constraint fk_comunicado_voluntario foreign key(id_projeto) references dbo.projeto_tb(id)
	)
end

GO

if(OBJECT_ID('ong_db.dbo.comunicado_voluntario_tb') is null)
begin
	create table dbo.comunicado_voluntario_tb
	(
		id int identity(1,1) not null,
		id_voluntario int not null,
		titulo varchar(100) not null,
		descricao varchar(500) not null,
		data_inicio date,

		Constraint pk_comunicado primary key (id, id_voluntario),
		Constraint fk_comunicado_voluntario foreign key(id_voluntario) references dbo.voluntario_tb(id)
	)
end


