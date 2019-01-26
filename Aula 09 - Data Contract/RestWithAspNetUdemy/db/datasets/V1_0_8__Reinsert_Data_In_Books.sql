use rest_with_asp_net_udemy;

insert into books (Title, Author, LaunchDate, Price)
select 'Teste1', 'Teste1', '2019-01-25', 49.00 union
select 'Teste2', 'Teste2', '2019-01-25', 59.00 union
select 'Teste3', 'Teste3', '2019-01-25', 78.00;
