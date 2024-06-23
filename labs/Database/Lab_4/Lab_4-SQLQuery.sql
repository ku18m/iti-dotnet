use Company_SD;
go


-- 1
-- Display (Using Union Function)
	-- a.	The name and the gender of the dependence that's gender is Female and depending on Female Employee.
	-- b.	And the male dependence that depends on Male Employee.

select
	D.Dependent_name,
	D.Sex
from
	Employee as E
	inner join Dependent as D
	on E.SSN = D.ESSN
where
	E.Sex = 'F'
	and
	D.Sex = 'F'
union
select
	D.Dependent_name,
	D.Sex
from
	Employee as E
	inner join Dependent as D
	on E.SSN = D.ESSN
where
	E.Sex = 'M'
	and
	D.Sex = 'M';


-- 2
-- For each project, list the project name and the total hours per week (for all employees) spent on that project.

select
	P.Pname,
	sum(W.Hours) as 'Total Hours'
from
	Project as P
	inner join Works_for as W
	on P.Pnumber = W.Pno
group by P.Pname;


-- 3
-- Display the data of the department which has the smallest employee ID over all employees' ID.

select
	D.*
from
	Employee as E
	inner join Departments as D
	on E.Dno = D.Dnum
where
	E.Dno is not null
	and
	E.SSN = (select min(SSN) from Employee);


-- 4
-- For each department, retrieve the department name and the maximum, minimum and average salary of its employees.

select
	D.Dname,
	max(E.Salary) as 'Max Salary',
	min(E.Salary) as 'Min Salary',
	avg(E.Salary) as 'Avg Salary'
from
	Employee as E
	inner join Departments as D
	on E.Dno = D.Dnum
group by D.Dname;


-- 5
-- List the full name of all managers who have no dependents.

select
    E.Fname + ' ' + E.Lname as E_name
from
    Employee as E
    left outer join Dependent as D
    on E.SSN = D.ESSN
where
    D.ESSN is null;

-- 6
-- For each department
-- if its average salary is less than the average salary of all employees
-- display its number, name and number of its employees.

select
	D.Dname
from
	Employee as E
	inner join Departments as D
	on E.Dno = D.Dnum
group by
	D.Dname
having
	avg(E.Salary) < (select avg(Salary) from Employee);


-- 7
-- Retrieve a list of employee’s names and the projects names they are working on
-- ordered by department number and within each department,
-- ordered alphabetically by last name, first name.

select
	E.Fname + ' ' + E.Lname as 'E_name',
	P.Pname
from
	Employee as E
	inner join Departments as D
	on E.Dno = D.Dnum
	inner join Project as P
	on D.Dnum = P.Dnum
order by
	D.Dnum, E.Lname, E.Fname;


-- 8
-- Try to get the max 2 salaries using sub query.

select
	max(E.Salary) as 'Max Salary',
	(select max(Salary) from Employee where Salary < (select max(Salary) from Employee)) as 'Sec Max Salary'
from
	Employee as E;


-- 9
-- Get the full name of employees that is similar to any dependent name.

select
	E.Fname + ' ' + E.Lname as 'Similar Employees',
	D.*
from
	Employee as E
	cross join Dependent as D
where
	D.Dependent_name like '%' + E.Fname + '%'
	or
	D.Dependent_name like '%' + E.Lname + '%';
	-- D.Dependent_name like '%' + E.Fname + ' ' + E.Lname + '%'	-- If you need it like the full name only.


-- 10
-- Display the employee number and name if at least one of them have dependents (use exists keyword).

select
	E.SSN,
	concat_ws(' ', E.Fname, E.Lname) as 'Name'
from
	Employee as E
where
	exists (select * from Dependent where E.SSN = ESSN);


-- 11
-- In the department table insert new department called "DEPT IT”, with id 100, employee with SSN = 112233
-- as a manager for this department, The start date for this manager is '1-11-2006'

insert into Departments (
		Dname,
		Dnum,
		MGRSSN,
		[MGRStart Date]
	) values (
		'DEPT ITI',
		100,
		112233,
		'1-11-2006'
	);


-- 12
-- Do what is required if you know that : Mrs.Noha Mohamed(SSN=968574)  moved to be the manager of the new department (id = 100),
-- and they give you(your SSN =102672) her position (Dept. 20 manager)

begin try
	begin transaction
		-- a. First try to update her record in the department table.
		update Departments
		set MGRSSN = 968574
		where Dnum = 100;

		-- b. Update your record to be department 20 manager.
		update Departments
		set MGRSSN = 102672
		where Dnum = 20;

		-- c. Update the data of employee number=102660 to be in your teamwork (he will be supervised by you) (your SSN =102672).
		update Employee
		set Superssn = 102672
		where SSN = 102660;
	commit
end try
begin catch
	rollback
	select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch


-- 13
-- Unfortunately, the company ended the contract with Mr. Kamel Mohamed (SSN=223344)
-- so try to delete his data from your database in case you know that you will be temporarily in his position.
-- Hint: (Check if Mr. Kamel has dependents, works as a department manager, supervises any employees or works in any projects and handle these cases).

begin try
	begin transaction
		update Departments
		set
			MGRSSN = 102672,
			[MGRStart Date] = getdate()
		where MGRSSN = 223344;
		
		update Employee
		set Superssn = 102672
		where Superssn = 223344;

		delete from Works_for where ESSn = 223344;

		delete from Dependent where ESSN = 223344;

		delete from Employee where SSN = 223344;
	commit
end try
begin catch
	rollback
	select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch


-- 14
-- Try to update all salaries of employees who work in Project ‘Al Rabwah’ by 30%.

begin try
	begin transaction
		update E
		set E.Salary *= 1.3
		from
			Employee as E
			inner join Works_for as W
			on E.SSN = W.ESSn
			inner join Project as P
			on P.Pnumber = W.Pno
		where
			P.Pname = 'Al Rabwah';
	commit
end try
begin catch
	rollback
	select ERROR_LINE(),ERROR_MESSAGE(),ERROR_NUMBER()
end catch
