use ong_db;
GO

create table dbo.projeto_tb(
id int primary key identity(1,1) not null,
nome_projeto varchar(100) not null,
endereco varchar(500),
telefone varchar(10),
email varchar(100),
tipo varchar(50),
data_inicio date,
descricao varchar(300) not null,
)

GO;

create table dbo.voluntario_db(
id int primary key identity(1,1) not null, 
nome_voluntario varchar(100) not null,
cpf varchar(11) not null,
data_nascimento date,
endereco varchar(100),
telefone varchar(10),
email varchar(100),
profissao varchar(100),
sexo varchar(1),
)

GO;

create table dbo.voluntariado_db(
id_projeto int not null,
id_voluntario int not null,
data_entrada date,
data_saida date,

Constraint pk_voluntariado primary key (id_projeto, id_voluntario),
Constraint fk_voluntariado_projeto foreign key (id_projeto) references dbo.projeto_tb(id),
Constraint fk_voluntariado_voluntario foreign key (id_voluntario) references dbo.voluntario_db(id)
)