use varejo_db
Go

create table dbo.cliente_tb(
cliente_id int identity(1,1) primary key,
nome_cli varchar(100) not null,
cpf int not null,
rg int not null,
data_nascimento date,
telefone int,
email varchar(100),
endereco varchar(200),
cep int
)

create table dbo.produto_tb(
produto_id int identity(1,1) primary key,
nome_prod varchar(100) not null,
descricao varchar(100),
preco decimal(12,2)
)

create table dbo.funcionario_tb(
funcionario_id int identity(1,1) primary key,
nome_func varchar(100) not null,
cargo varchar(100) not null,
data_nascimento date,
cpf int not null,
rg int not null
)

create table venda_tb(
venda_id int identity(1,1) primary key,
produto_id int,
cliente_id int, 
funcionario_id int,
data date,
forma_pagamento varchar(50),
descricao varchar(100),
constraint FK_produto_id foreign key(produto_id) references dbo.produto_tb(produto_id),
constraint FK_cliente_id foreign key(cliente_id) references dbo.cliente_tb(cliente_id),
constraint FK_funcionario_id foreign key(funcionario_id) references dbo.funcionario_tb(funcionario_id)
)





