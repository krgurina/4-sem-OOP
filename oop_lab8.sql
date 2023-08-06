create database Lab8
use Lab8
create table Lectors (
Id int primary key,
Name nvarchar(20),
Surname nvarchar(20),
Patronomyc nvarchar(20),
Departament nvarchar(20),
Auditory nvarchar(20),
Number nvarchar(20),
Image nvarchar(50)
)

create table Disciplines (
Id int identity(1, 1) primary key,
Name nvarchar(50),
Semester int,
Course int,
NumOfLectures int,
NumOfLabs int,
TypeOfControl nvarchar(20),
LectorID int foreign key references Lectors(Id)
)
