create database Library;

use Library;

create table Guest (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null
)

create table Book (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null,
)

create table BookGuest (
	id int primary key identity,
	bookId int,
	constraint FK_LibraryDB_bookId foreign key(bookId) references Book(id),
	guestId int,
	constraint FK_LibraryDB_guestId foreign key(guestId) references Guest(id)
)

create table Author (
	id int primary key identity,
	[name] nvarchar(50) check([name]<>N'') unique not null
)

create table BookAuthor (
	id int primary key identity,
	bookId int,
	constraint FK_BookAuthor_bookId foreign key(bookId) references Book(id),
	authorId int,
	constraint FK_BookAuthor_authorId foreign key(authorId) references Author(id)
)

create table LibraryBook (
	id int primary key identity,
	BookAuthorId int,
	constraint FK_LibraryBook_BookAuthorId foreign key(BookAuthorId) references BookAuthor(id),
	BookGuestId int,
	constraint FK_LibraryBook_BookGuestId foreign key(BookGuestId) references BookGuest(id)
)

insert into Book values ('���� ���');
insert into Book values ('������ ����');
insert into Book values ('���������')

insert into Author values ('���� ��������');
insert into Author values ('����� ������');
insert into Author values ('�������� ���');

insert into BookAuthor values (1,2);
insert into BookAuthor values (2,3);
insert into BookAuthor values (3,1);

insert into Guest values ('������');
insert into Guest values ('�������');
insert into Guest values ('���� ���������');
 
where id != (select bookId from BookGuest);

insert into BookGuest values (2, 2);
insert into BookGuest values (1, 3);
insert into BookGuest values (3, 1);
insert into BookGuest values (5, 4);