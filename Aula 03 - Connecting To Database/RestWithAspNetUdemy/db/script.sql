use rest_with_asp_net_udemy;

CREATE TABLE persons 
(
Id int(10) unsigned null default null,
FirstName varchar(50) null default null,
LastName varchar(50) null default null,
Address varchar(50) null default null,
Gender varchar(50) null default null
)
ENGINE=InnoDB;

ALTER TABLE persons CHANGE Id Id INT(10) AUTO_INCREMENT PRIMARY KEY;