create database TaskManager;

use TaskManager;

create table Employees (
id int not null auto_increment primary key,
name nvarchar(20),
hours int,
title nvarchar(40)
);

create table ToDos (
id int not null auto_increment primary key,
`name` nvarchar(25),
`description` nvarchar(100),
assignedTo int,
hoursNeeded int,
isCompleted bit,
foreign key (assignedTo) references Employees(id)
);

insert into Employees 
values(0, 'Phil', 40, 'Boss'),
(0, 'Greg', 40, 'Software Developer'),
(0, 'Sarah', 35, 'Data Engineer');

insert into ToDos 
values(0, 'Save the world', 'Stop the world from being ended', 1, 1, 0),
(0, 'Destroy the world', 'Stop the world from being saved', 2, 39, 0);

