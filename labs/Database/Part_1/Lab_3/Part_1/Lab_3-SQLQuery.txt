use Company_SD;

-- 1
-- Display the Department id, name and id and the name of its manager.

select
	D.Dnum as Did,
	D.Dname as Dname,
	E.SSN as Eid,
	E.Fname+' '+E.Lname as Ename
from
	Departments as D
	left outer join Employee as E  -- Could be inner if u need to filter Departments that doesn't have a manager.
	on
	E.SSN = D.MGRSSN;


-- 2
-- Display the name of the departments and the name of the projects under its control.

select
	Dname, Pname
from
	Departments as D
	left outer join Project as P  -- Could be inner if u need to filter Departments with no Projects under control.
	on
	D.Dnum = P.Dnum;


-- 3
-- Display the full data about all the dependence associated with the name of the employee they depend on him/her.

select
	E.Fname + ' ' + E.Lname as Ename,
	Dep.*
from
	Employee as E
	inner join Dependent as Dep
	on
	E.SSN = Dep.ESSN;


-- 4
-- Display the Id, name and location of the projects in Cairo or Alex city.

select
	Pnumber as Pid,
	Pname,
	Plocation
from
	Project
where
	City in ('Cairo', 'Alex');


-- 5
-- Display the Projects full data of the projects with a name starts with "a" letter.

select
	*
from
	Project
where
	Pname like 'A%';


-- 6
-- display all the employees in department 30 whose salary from 1000 to 2000 LE monthly.

select
	*
from
	Employee
where
	Dno = 30
	and
	Salary between 1000 and 2000;


-- 7
-- Retrieve the names of all employees in department 10 who works more than or equal10 hours per week on "AL Rabwah" project.

select
	Fname + ' ' + Lname as Ename
from
	Employee as E
	inner join Works_for as W
	on
	E.SSN = W.ESSn
	inner join Project as P
	on
	P.Pnumber = W.Pno
where
	P.Pname = 'AL Rabwah'
	and
	E.Dno = 10
	and
	W.Hours >= 10;


-- 8
-- Find the names of the employees who directly supervised with Kamel Mohamed.

select
	Child.Fname + ' ' + Child.Lname
from
	Employee Parent
	inner join Employee Child
	on
	Parent.SSN = Child.Superssn
where
	(Parent.Fname + ' ' + Parent.Lname) = 'Kamel Mohamed';


-- 9
-- Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.

select
	E.Fname + ' ' + E.Lname as Ename,
	P.Pname
from
	Employee as E
	left outer join Works_for as W
	on
	E.SSN = W.ESSn
	inner join Project as P
	on
	P.Pnumber = W.Pno
order by
	P.Pname;


-- 10
-- For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate.

select
	P.Pnumber,
	D.Dname,
	E.Lname,
	E.Address,
	E.Bdate
from
	Project as P
	inner join Departments as D
	on
	D.Dnum = P.Dnum
	inner join Employee as E
	on
	E.SSN = D.MGRSSN
where
	P.City = 'Cairo';


-- 11
-- Display All Data of the managers.

select
	E.*
from
	Departments as D
	inner join Employee as E
	on
	E.SSN = D.MGRSSN;


-- 12
-- Display All Employees data and the data of their dependents even if they have no dependents.

select
	E.*,
	D.*
from
	Dependent as D
	right outer join Employee as E
	on
	E.SSN = D.ESSN;


-- 13
-- Insert your personal data to the employee table as a new employee in department number 30, SSN = 102672, Superssn = 112233, salary=3000.

insert into Employee
	values (
	'Mohamed',
	'Kamal',
	102672,
	'8-1-1999',
	'Cairo, Egypt',
	'M',
	3000,
	112233,
	30
	);


-- 14
-- Insert another employee with personal data your friend as new employee in department number 30, SSN = 102660,
-- but don’t enter any value for salary or supervisor number to him.

insert into Employee
	values (
	'Mohamed',
	'Saber',
	102660,
	'9-23-1999',
	'Cairo, Egypt',
	'M',
	NULL,
	NULL,
	30
	);


-- 15
-- Upgrade your salary by 20 % of its last value.

update Employee
set
	Salary *= 1.2
where
	SSN = 102672;
