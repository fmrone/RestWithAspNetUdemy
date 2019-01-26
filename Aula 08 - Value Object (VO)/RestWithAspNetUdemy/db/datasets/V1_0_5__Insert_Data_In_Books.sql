use rest_with_asp_net_udemy;

insert into books (Id, Title, Author, LaunchDate, Price)
select UUID(), 'Teste1', 'Teste1', '2019-01-25', 49.00 union
select UUID(), 'Teste2', 'Teste2', '2019-01-25', 59.00 union
select UUID(), 'Teste3', 'Teste3', '2019-01-25', 59.00;
