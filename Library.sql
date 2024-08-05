create database Library

--Tables
create table Catagories(
CatagoryID int Primary Key Identity(001,1),
CatagoryName varchar(15) not null
);

create table Members(
MemberID int  primary key identity(9000,1),
TeudatZehut int unique not null,
FirstName varchar (20),
LastName varchar (20),
PhoneNumber varchar(10) not null,
HomeAddress varchar(30),
NumBooksEligable int not null,
MembershipStart date default GETDATE(),
LatestBookDraw date default GETDATE(),

check (NumBooksEligable!>6)
);


create table Books(
BookID int Primary Key IDENTITY(10001,1),
BookName varchar(20) NOT NULL,
Author varchar(20),
DatePurchased date default GETDATE(),
CatagoryID int FOREIGN KEY REFERENCES Catagories(CatagoryID),
Quantity int default 1 
);

create table BookDraws(
DrawDate date default GETDATE(),
BookID int FOREIGN KEY REFERENCES Books(BookID),
MemberID int FOREIGN KEY REFERENCES Members(MemberID),
DueDate date default DATEADD(month, 1, getdate()),
Status nvarchar(10) default 'drawed',
ReturnDate date default null

CONSTRAINT Eprimary PRIMARY KEY (bookID,MemberID)
);

create table Employees(
EmployeeID int primary key identity(1,1) not null,
TeudatZehut int unique not null,
FirstName varchar (20),
LastName varchar (20),
PhoneNumber varchar(10) not null,
HomeAddress varchar(30),
DateOfBirth date,
MonthlyHours int, 
SalaryPerHour int
);

create table Suppliers(
SupplierID int primary key identity(90000,1),
CompanyID int unique not null,
Name varchar(20),
ContactName varchar(20),
PhoneNumber varchar(10),
EmailAddress varchar(25)
);

create table Orders(
OrderID int primary key identity (10000,1),
OrderDate date default GETDATE(),
SupplierID int FOREIGN KEY REFERENCES suppliers(SupplierID),
OrderStatus varchar(15) default 'order created'
);

create table OrderDetails(
OrderID int FOREIGN KEY REFERENCES Orders(OrderID),
BookName varchar(20) not null,
Author varchar(20),
BookPrice decimal not null,
Quantity int default 1
);

--Insert Data
insert into catagories values
('History'),
('Biography'),
('Psychology'),
('Health'),
('Fiction')

insert into Members values
(32323233,'Chaim','Cohen','0533344544','Divrei Chaim 3',3,'2023-04-12'),
(87000870,'Tzvi','Ben-Tov','0533133000','Petach Tikva 8',4,'2022-10-15'),
(32223444,'Avi','Shmuelevitz','0533900900','Oholiav 32',4,'2023-11-21'),
(1232,'Yoni','Jaffe','0533111114','Petach Tikva 13',5,'2021-10-12')

insert into Members(TeudatZehut,LastName,PhoneNumber,NumBooksEligable,MembershipStart)
values('090987652','Klein','0523432222',4,'2022-12-09')

insert into Members(TeudatZehut,LastName,PhoneNumber,NumBooksEligable,MembershipStart)
values('985455557','Berger','052876122',6,'2023-07-04')

insert into Books
values
('Blueprint','M.Tomphson','2020-03-21',2),
('The Cold War','S.P.Brink','2020-02-01',1, 3),
('Rabbi Kotler','Rabbi Yehoshua Karp','2022-03-20',2),
('Master Chinuch','Moshe Templer','2022-01-01',3,4),
('The Black Shaddow','Esther Brick','2021-11-21',5,2),
('Turnaround','Chaim Riese','2019-03-01',5),
('Self Awareness','Esther Shein','2021-10-21',3),
('Nature Types','Esther SHein','2020-03-01',3,6),
('Doctor Moriss','Rabbi Yehoshua Karp','2016-01-20',2,3),
('Relationships','Moshe Templer','2024-01-01',3,3),
('Sunshine','Tzvi Bronner','2017-01-21',5,2),
('The Roman Empire','Rabbi Dovid Berger','2012-03-01',1)

insert into BookDraws(BookID,MemberID)
values
(10005,9002),
(10007,9002),
(10012,9002),
(10004,9005),
(10010,9005),
(10009,9001),
(10014,9003),
(10015,9003),
(10008,9003)
(10004,9002),
(10014,9003),
(10008,9005),
(10011,9005),
(10010,9001)



insert into Employees values
(32323233,'Gila','Cohen','0533344544','Divrei Chaim 3','2001-04-02',24,45),
(31987655,'Rina','Bodner','0533219999','Dover Shalom 11','2004-01-02',24,43),
(09887650,'Ditza','Green','0548484665','Shamgar 12','1998-10-09',12,43),
(31023233,'Chedva','Levi','0533344000','Yermiyahu 63','2000-04-12',20,50)


insert into suppliers values
(2398880,'Feldheim', 'Dina Bergman', '0533123333','dinab@feldheimil.com'),
(1055589,'Tiferet', 'Chaim', '0533124400','ccohen@t.hafatza.co.il'),
(980000,'Shlahevet', 'Edna Brinker', '0529999876','office@Shlahevet.com'),
(23959000,'Ohr Hachaim', 'Simcha Reinman', '0546788666','sr@oh.co.il')


insert into orders (orderdate, supplierID)
values
('2023-09-03',90006),
('2023-11-03',90007)

insert into orders(supplierID)
values
(90009),
(90007)
 
 
insert into OrderDetails values
(10001, 'Through Fire','Hillel Zaafrani',62,3),
(10001, 'The Journey','Liba Kurtz',75,2),
(10002, 'Learn to Listen','SW Sara B. Kelwirth',60,3),
(10002, 'Thin Dust','Moshe Templer',65,2),
(10002, 'Emuna Pearls','Rabbi A. Berger',46.5,6),
(10003, 'Rabbi Millers life','Chaya Sara Ringel',54,3),
(10003, 'The Spy','Daniel Moskowitz',58,3),
(10004, 'Origanic Lifestyle','Dr. Rina Tirnau',102,1),
(10004, 'Sunrise','Baila Masin',57.5,4),
(10004, 'Higher Aspirations','Dovid Blum',62,3)


--Updates
update Members
set FirstName ='Benny', HomeAddress = 'Bar Ilan 12'
where MemberID=9012;

update Books
set CatagoryID = 5
where bookid = 10011

update Books
set Quantity = 2
where BookID = 10014

update orders
set OrderStatus = 'recieved'
where SupplierID=90001 and OrderDate = '2024-04-01'

update BookDraws
set MemberID = (select MemberID from Members where TeudatZehut=87000870)
where BookID = (select bookid from books where bookname = 'Sunshine')


update books
set CatagoryID = (select CatagoryID from Catagories where CatagoryName = 'History')
where bookname = 'The Black Shaddow'

delete from Employees 
where employeeID = 3

--sql Commands
select * from bookdraws
select CompanyID, Name, ContactName
from Suppliers 
where PhoneNumber = '0533124400'

select BookID, BookName
from Books
where DatePurchased < '2021-01-01'

select *
from Members
where FirstName like 'A%';

--Triggers

--1
create trigger PreventDeletingMember
on Members
instead of delete
as
begin

	if exists(
		select * from BookDraws
		join deleted on deleted.MemberID = BookDraws.MemberID
		where BookDraws.Status = 'drawed'
	)
	begin
		print 'Cannot delete member that did not return all books'
	end
	else
	begin
		delete from Members
		from Members
		join deleted on deleted.MemberID = Members.MemberID
	end
end

delete from Members where memberid=9005
--2

create trigger PreventDeletingBook
on Books
instead of delete
as
begin

	if exists(
		select * from BookDraws
		join deleted on deleted.BookID = BookDraws.BookID
		where BookDraws.Status = 'drawed'
	)
	begin
		print 'Cannot delete book that is drawed'
	end
	else
	begin
		delete from Books
		from Books
		join deleted on deleted.BookID = Books.BookID
	end
end


--Procedures

--1
create procedure NumBooksCurrentlyEligable
@MemberID int
as
begin
    select members.NumBooksEligable - (select count(MemberID) from bookdraws where MemberID = Members.MemberID and status='drawed') as NumBooksStillEligable
    from members
    where memberid =@MemberID
end

exec NumBooksCurrentlyEligable @MemberID = 9002


--2
create procedure DrawBook
@MemberID int,
@BookID int
as
begin
	insert into BookDraws(BookID,MemberID)
values(@BookID,@MemberID)
end

exec DrawBook @MemberID = 9001, @BookID = 10006

--3
create procedure ViewDrawedBooks
@MemberID int
as
BEGIN
select count(DrawDate) as DrawedBooks from BookDraws 
where MemberID = @MemberID and Status = 'drawed'
END


--4
create procedure ReturnBook
@MemberID int,
@BookID int
as
BEGIN
	UPDATE BookDraws
SET 
    Status = 'returned',
    ReturnDate = GETDATE()
	where BookDraws.MemberID=@MemberID and BookDraws.BookID = @BookID
END

exec ReturnBook @MemberID = 9002, @BookID = 10012


 --5
 create procedure BooksInSupply
 @bookName nvarchar
as
begin
select Books.BookName, Books.Author, Books.Quantity - (select count(BookID) from bookdraws where bookdraws.BookID = books.BookID) as NumBooksLeftInStock
from Books
where  bookname like @bookname
end

exec BooksInSupply @bookname = 'Through Fire'


--6
create procedure SelectBooksByAuthor
	@Author nvarchar(20)
As
BEGIN
	select * from Books
	where Author = @Author
END

exec SelectBooksByAuthor @Author = 'Moshe Templer'


--10 
create procedure NewOrder
@supplier int
as
BEGIN
insert into orders(supplierID)
values(@supplier)
select MAX(orderid) from Orders
End

select supplierid from suppliers
select * from orders
exec NewOrder @supplier = 90006


--11
create procedure AddBookToOrder
@OrderID int,
@BookName varchar,
@Author varchar,
@BookPrice decimal,
@Quantity int 
as
BEGIN
insert into OrderDetails values
(@OrderID, @BookName,@Author,@BookPrice,@Quantity)
END

--2
create procedure ShowOrderSum
	@Order int
As
BEGIN
	select orderid, Sum(BookPrice * quantity) as Total
	from OrderDetails where OrderID = @order
	group by OrderID
END

exec ShowOrderSum @order = 10002



--8
create procedure RecieveOrder
@OrderID int
as
BEGIN
UPDATE Orders
   set orders.OrderStatus = 'order recieved'
   where Orders.OrderID = @OrderID
   
insert into Books (BookName, Author, Quantity)
(select BookName, Author, Quantity from OrderDetails
Where OrderDetails.OrderID=@OrderID)
END

