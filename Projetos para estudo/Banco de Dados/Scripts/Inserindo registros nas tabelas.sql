use varejo_db
Go

insert into dbo.cliente_tb(
nome_cli,
cpf,
rg,
data_nascimento,
telefone,
email,
endereco,
cep
)
values
(
'Rafael de Souza Soares',
134256,
233159565,
'30/10/1990',
3298882,
'rafaelsouzasoares2@gmail.com',
'Rua João Felicidade, N 62, Vila Isabel, Três Rios/RJ', 
25815560
)

select * from cliente_tb