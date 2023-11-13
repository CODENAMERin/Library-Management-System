Create Database library_system
Create table Login(
	username varchar(20),
	password varchar(20)
)
insert into Login(username, password)values('admin','123456')

select * from Login 

Create procedure sp_login
@username varchar(20),
@password varchar(20)
AS
Begin
	Select * from login where username=@username and password = @password
END

---------------------------------------

Create table tbl_books
(
BookID INT IDENTITY(1,1),
BookName varchar(30),
AuthorName varchar(30),
publication varchar(30),
purchaseDate varchar(40),
BookPrice varchar(20),
Quantity varchar(30)
)

SELECT * FROM tbl_books

-------------------------------------

Create Procedure SP_add_books
@BookName varchar(30),
@AuthorName varchar(30),
@publication varchar(30),
@purchaseDate varchar(40),
@BookPrice varchar(20),
@Quantity varchar(30)
AS
BEGIN
	INSERT INTO tbl_books(
	BookName, AuthorName, publication, 
	purchaseDate, BookPrice, Quantity)
	VALUES(
	@BookName, @AuthorName, @publication,
	@purchaseDate, @BookPrice, @Quantity
	)
END

-----------------------------------------

Create Procedure ViewBooks
@BookName varchar(30)
AS
BEGIN
	IF (@BookName = '')
	BEGIN
		Select * from tbl_books
	END
	ELSE
	BEGIN
		Select * From tbl_books Where BookName=@BookName
	END
END

----------------------------------------

Create Table students
(
	Student_Name varchar(20),
	Student_Number varchar(30),
	Department varchar(30),
	contact varchar(20),
	Email varchar(30),
	Semester varchar(20)
)

Create procedure sp_addStudents
	@Student_Name varchar(20),
	@Student_Number varchar(30),
	@Department varchar(30),
	@contact varchar(20),
	@Email varchar(30),
	@Semester varchar(20)
	AS
	BEGIN
		INSERT INTO students(
		Student_Name, Student_Number, Department, contact, Email, Semester
		)
		VALUES(
		@Student_Name, @Student_Number, @Department, @contact, @Email, @Semester
		)
	END

SELECT * FROM students

-------------------------------

Create Procedure ViewStudents
@StudentNO varchar(30)
AS
BEGIN
	IF (@StudentNO = '')
	BEGIN
		Select * from students
	END
	ELSE
	BEGIN
		Select * From students Where Student_Number=@StudentNO
	END
END

SELECT * from students
-----------------------------------

Create Procedure sp_getbooks
AS
BEGIN
	Select BookName from tbl_books
END

----------------------------------------

Create table issue_book
(
	Issue_ID int IDENTITY(1,1),
	Student_Name varchar(30),
	Student_no varchar(30),
	Department varchar(30),
	Contact varchar(30),
	Email varchar(30),
	BookName varchar(30),
	Issue_Date varchar(50),
	Return_Date varchar(50)
)

----------------------------------------

Create Procedure sp_addissuebook
	@Student_Name varchar(30),
	@Student_no varchar(30),
	@Department varchar(30),
	@Contact varchar(30),
	@Email varchar(30),
	@BookName varchar(30),
	@Issue_Date varchar(50),
	@Return_Date varchar(50)
AS
BEGIN
	Insert into issue_book(
		Student_Name, Student_no, Department, Contact, Email,
		BookName, Issue_Date, Return_Date
	)
	VALUES(
		@Student_Name, @Student_no, @Department,
		@Contact, @Email, @BookName,
		@Issue_Date, @Return_Date
	)
END

SELECT * FROM issue_book

------------------------------------------

Create Procedure ViewIssueBook
@StudentNO varchar(30)
AS
BEGIN
	IF (@StudentNO = '')
	BEGIN
		Select * from issue_book
	END
	ELSE
	BEGIN
		Select * From issue_book Where Student_no=@StudentNO and
		Return_Date = ''
	END
END

----------------------------------

Create Procedure Update_issueBook
@ID varchar(30),
@Return_Date varchar(30)
AS
BEGIN
	Update issue_book set Return_Date = @Return_date
	where Issue_ID = @ID
END

SELECT * FROM issue_book

------------------------------------------

Create procedure Reports
@report varchar (30)
AS
BEGIN
	IF(@report = 'Issue')
	BEGIN
		select * from issue_book where 
		Return_Date = ''
	END
	ELSE IF(@report = 'Return')
	BEGIN
		select * from issue_book where 
		Return_Date = ''
	END
END

