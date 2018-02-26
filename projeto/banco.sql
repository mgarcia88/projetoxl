create table tb_produtos (pro_id int not null primary key identity,
pro_nome varchar(200),
pro_valor decimal(9,2),
pro_quantidade int,
pro_unidade varchar(100))

insert into tb_produtos (pro_nome, pro_valor, pro_quantidade, pro_unidade)
values('Produto 01',120,10,'Unitario')

select * from tb_produtos

create table tb_importacao (imp_id int not null primary key identity,
imp_arquivo varchar(500),
imp_data_inicio datetime)


drop table tb_importacao

select * from tb_importacao

SET IDENTITY_INSERT [Tbl_Clientes] ON