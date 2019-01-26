use rest_with_asp_net_udemy;

CREATE TABLE IF NOT EXISTS books
(
Id int(10) auto_increment primary key,
Title longtext not null,
Author longtext not null,
LaunchDate datetime(6) not null,
Price decimal(65, 2) not null
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;
