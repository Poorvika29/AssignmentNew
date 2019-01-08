Use DbOne

select * from TblEmp;

Create procedure spgetallemp
as
begin
 Select EmpID,EmpName from TblEmp
end

exec spgetallemp

create procedure AddEmp
@EmpName varchar(20),
@Department Varchar(5)
as 
begin
    BEGIN TRANSACTION
        DECLARE @ID int;
        SELECT @ID = coalesce((select max(EmpID) + 1 from TblEmp), 1)
    COMMIT 
	insert into TblEmp (EmpID,EmpName,Department) values (@ID,@EmpName,@Department)
end

drop procedure AddEmp;

;
Create procedure spEditEmp      
@Id int,
@EmpName nvarchar(50),      
--@City nvarchar (50),
@Department nvarchar (10)
as      
Begin      
 Update tblEmployee Set
 EmpName = @EmpName,
-- City = @City,
 Department = @Department
 Where EmpID = @Id 
End

Create procedure spDeleteEmp
@Id int
as
begin
	delete from TblEmp where EmpID = @ID
end

exec spDeleteEmp



drop table TblDept
drop table TblEmpDetails

create table TblDept
(
ID int primary key identity(1,1),
Name varchar(20)
);

Create table TblEmpDetails
(
EmpID int primary key identity(101,1) ,
EmpName varchar(20),
Gender VArchar(6),
DepartmentId int foreign key references  TblDept(ID),
);
select * from TblDept
select * from TblEmpDetails


insert into TblDept values ('IT');
insert into TblDept values ('ACC');
insert into TblDept values ('OP');

insert into TblEmpDetails values ('Poorvika','Female',1);
insert into TblEmpDetails values ('Meghna','Female',2);
insert into TblEmpDetails values ('Dipti','Female',3);
insert into TblEmpDetails values ('Akshay','Male',1);
insert into TblEmpDetails values ('Rohan','Male',2);
insert into TblEmpDetails values ('Joel','Male',3);
insert into TblEmpDetails values ('Shubhi','Female',1);
insert into TblEmpDetails values ('Kiran','Female',2);



CREATE TABLE tbl_Doctor
(
	Id INT NOT NULL PRIMARY KEY identity(101,1),
	DocName varchar(50) not null,
	WorkEx int NOT NULL,
	Location varchar(20) NOT NULL,
	Fee int NOT NULL,
	Category varchar(50) NOT NULL,
)

insert into tbl_Doctor values ('Monica',5,'Hyderabad',500,'Dentist');
insert into tbl_Doctor values ('Dr. John',5,'Delhi',500,'Dermatologist');


select * From tbl_Doctor;


Create procedure spgetalldoc
as
begin
 Select * from tbl_Doctor
end

exec spgetalldoc



create procedure spadddoctor
(
	@docname varchar(50) ,
	@gender varchar(6),
	@workex int ,
	@location varchar(20),
	@fee int,
	@speciality varchar(50),
	@date datetime
)
as begin
insert into tbl_Doctor_ values (@docname,@gender,@workex,@location,@fee,@speciality,@date)
end

exec spadddoctor 'Shubhi','Female',23,'Hyderabad',56,'Dentist','11/01/2018'

select * from tbl_Doctor_

CREATE TABLE tbl_Doctor_
(
	Id INT NOT NULL PRIMARY KEY identity(101,1),
	DocName varchar(50) not null,
	Gender varchar(6) Not null,
	WorkEx int NOT NULL,
	Location varchar(20) NOT NULL,
	Fee int NOT NULL,
	Category varchar(50) NOT NULL,
	date datetime 
);

create procedure spgetalldoctors
as
begin
select * from tbl_Doctor_
end;

exec spgetalldoctors







Create table tblDepartment
(
 Id int primary key identity,
 Name nvarchar(50)
)

Insert into tblDepartment values('IT')
Insert into tblDepartment values('HR')
Insert into tblDepartment values('Payroll')

Create table tblEmployee1
(
 EmployeeId int Primary Key Identity(1,1),
 Name nvarchar(50),
 Gender nvarchar(10),
 City nvarchar(50),
 DepartmentId int
)

Alter table tblEmployee1
add foreign key (DepartmentId)
references tblDepartment(Id)

Insert into tblEmployee1 values('Mark','Male','London',1)
Insert into tblEmployee1 values('John','Male','Chennai',3)
Insert into tblEmployee1 values('Mary','Female','New York',3)
Insert into tblEmployee1 values('Mike','Male','Sydeny',2)
Insert into tblEmployee1 values('Scott','Male','London',1)
Insert into tblEmployee1 values('Pam','Female','Falls Church',2)
Insert into tblEmployee1 values('Todd','Male','Sydney',1)
Insert into tblEmployee1 values('Ben','Male','New Delhi',2)
Insert into tblEmployee values('Sara','Female','London',1)



create table tblDoctor
(
	Id int identity(10,1) primary key,
	Name Varchar(50) NOT NULL,
	Gender Varchar(6) NOT NULL,
	WorkEx int NOT NULL,
	Location varchar(20) NOT NULL,
	Fee int NOT NULL,
	EmailId varchar(50),
	Website varchar(100),
	Speciality int ,
	date datetime,
	CONSTRAINT FK_Speciality FOREIGN KEY (Speciality)
    REFERENCES tblSpeciality(SpecId)
)
insert into tblDoctor values ('Poorvika1','Female','10','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018');
insert into tblDoctor values ('Poorvika2','Female','11','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika3','Female','12','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika4','Female','13','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika5','Female','14','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika6','Female','15','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika7','Female','16','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika8','Female','17','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika9','Female','18','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblDoctor values ('Poorvika10','Female','19','Pune','1000','poorvika@gmail.com','www.asd.com',13,'12-11-2018','a','a');
insert into tblSpeciality values ('Dermatologist');
insert into tblSpeciality values ('Neurologist');
insert into tblSpeciality values ('Dentist');
insert into tblSpeciality values ('Eye Specialist');
select * from tblDoctor

select * from tblSpeciality

create table tblSpeciality
(
	SpecId int identity(10,1) primary key,
	Speciality Varchar(50) NOT NULL,
)
select a.Speciality , count(*) as total from tblSpeciality a join tblDoctor b 
on a.SpecId = b.Speciality group by a.Speciality

ALTER TABLE tblSpeciality
ADD IsSelected BIT

Update tblSpeciality Set IsSelected = 0 Where SpecId = 10

Alter table tblDoctor Add Photo nvarchar(100), AlternateText nvarchar(100);

Update tblDoctor set Photo='C:\Users\Poorvika Ujjaini\Downloads\WebApi\DoctorModel\Photos\doctorimg.png',AlternateText = 'John Smith Photo' where Id = 10
Update tblDoctor set Photo='~\Photos\doctorimg.png',AlternateText = 'John Smith Photo' where Id = 11;
Update tblDoctor set Photo='~\Photos\doctorimg.png',AlternateText = 'John Smith Photo' where Id = 12;

