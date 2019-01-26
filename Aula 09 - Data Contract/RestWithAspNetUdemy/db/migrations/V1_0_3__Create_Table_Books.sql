use rest_with_asp_net_udemy;

CREATE TABLE IF NOT EXISTS books
(
Id varchar(127) not null,
Title longtext not null,
Author longtext not null,
LaunchDate datetime(6) not null,
Price decimal(65, 2) not null,
PRIMARY KEY (Id)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;
