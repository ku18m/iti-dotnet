
-- 1) Create a stored procedure without parameters to show the number of students per department name.[use ITI DB]
	create proc numOfStudPerDep
	as
		select
			'Department Name' = D.Dept_Name,
			'Number of Students' = COUNT(S.St_Id)
		from
			Student as S
			inner join Department as D
			on S.Dept_Id = D.Dept_Id
		group by
			D.Dept_Name
		go
	-- Test
		exec numOfStudPerDep
		go

-- 2) Create a stored procedure that will check for the # of employees in the project p1
--		if they are more than 3 print message to the user “'The number of employees in the project p1 is 3 or more'”
--		if they are less display a message to the user “'The following employees work for the project p1'”
--		in addition to the first name and last name of each one. [Company DB]
	alter proc checkProjEmp @Pnum int
	as
	begin
		declare @numOfEmp int
		select
			@numOfEmp = COUNT(distinct W.ESSn)
		from
			Works_for as W
		where
			W.Pno = @Pnum

		if @numOfEmp > 3
			select 'The number of employees in the project ' + cast(@Pnum as varchar(10)) + ' is 3 or more'
		else if @numOfEmp > 0
			begin
			declare @names varchar(500)
				select
					@names = STRING_AGG(E.Fname + ' ' + E.Lname, ',')
				from
					Works_for as W
					inner join [Human Resource].Employee as E
					on W.ESSn = E.SSN
				where
					W.Pno = @Pnum
				select 'The following employees work for the project ' + cast(@Pnum as varchar(10)) + ' ' + @names
			end
		end
		go
	-- Test
		exec checkProjEmp 400
		go

-- 3) Create a stored procedure that will be used in case there is an old employee has left the project and a new one become instead of him.
--		The procedure should take 3 parameters (old Emp. number, new Emp. number and the project number)
--		and it will be used to update works_on table. [Company DB]
	alter proc updateProjEmp(@oldEmp int, @newEmp int, @Pnum int)
	as
		begin try
			update
				Works_for
			set
				ESSn = @newEmp
			where
				ESSn = @oldEmp
				and
				Pno = @Pnum
		end try
		begin catch
			select 'An error occured'
		end catch
		go
	-- Test
		exec updateProjEmp 968574, 123456, 700
		go

-- 4) add column budget in project table and insert any draft values in it then:
		alter table Company.Project add budget int null
		go
--		Create an Audit table with the following structure
--		ProjectNo | UserName | ModifiedDate | Budget_Old | Budget_New
--		  p2 	  |  Dbo 	 |  2008-01-31	|	 95000 	 |   200000
		create table Audit (
			ProjectNo int,
			UserName varchar(50) not null,
			ModifiedDate Date not null,
			Budget_Old int,
			Budget_New int not null
		)
		go
--		This table will be used to audit the update trials on the Budget column (Project table, Company DB)
--		Example:
--			If a user updated the budget column then the project number, user name that made that update,
--			the date of the modification and the value of the old and the new budget will be inserted into the Audit table.
--		Note: This process will take place only if the user updated the budget column.
		create trigger ProjBudgAudit
		on Company.Project
		after update
		as
			if update(budget)
				begin
					declare @Pnum int
					declare @newBudget int
					declare @oldBudget int

					select @oldBudget = budget from deleted
					select @newBudget = budget, @Pnum = Pnumber from inserted

					insert into Audit values(@Pnum, SUSER_NAME(), GETDATE(), @oldBudget, @newBudget)
				end
		go
	-- Tested using wizard.

-- 5) Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--		“Print a message for user to tell him that he can’t insert a new record in that table”.
	create trigger denyUpdate
	on Department
	instead of insert
	as
		select 'You cannot insert in this table'
	go
	-- Test using TSQL to get check the message
		insert into Department (Dept_Id) values(100)
		go
-- 6) Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
	alter trigger [Human Resource].marchDeny
	on [Human Resource].Employee
	instead of insert
	as
		if format(GETDATE(), 'MMMM') != 'March'
			begin
				insert into [Human Resource].Employee
				select * from inserted
			end
	go

	-- Tested using July
	insert into [Human Resource].Employee (SSN) values (1000)
	go
-- 7) Create a trigger on student table after insert to add Row in Student Audit table (Server User Name , Date, Note)
--		where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”.
	-- Create the Audit table.
		create table AuditStudent (
			[Server User Name] varchar(50),
			[Date] date,
			Note varchar (150)
		)
		go
	-- Create the trigger.
		create trigger insertStudAudit
		on Student
		after insert
		as
			declare @insertedId int
			declare @note varchar(150)
			select @insertedId = St_Id from inserted
			set @note = SUSER_NAME() + ' Insert New Row with Key = ' + CAST(@insertedId as varchar(10)) + ' in table Student'
			insert into AuditStudent values (SUSER_NAME(), GETDATE(), @note)
		go

	-- Test
		insert into Student (St_Id) values (20000)
		go

-- 8) Create a trigger on student table instead of delete to add Row in Student Audit table
--		(Server User Name, Date, Note) where note will be“ try to delete Row with Key=[Key Value]”.
	create trigger denyDeletion
	on Student
	instead of delete
	as
		declare @St_Id int
		declare @note varchar(150)
		select @St_Id = St_Id from deleted
		set @note = SUSER_NAME() + ' try to delete row with key = ' + cast(@St_Id as varchar(10))

		insert into AuditStudent values (SUSER_NAME(), GETDATE(), @note)
	go

	-- Test
		delete from Student where St_Id = 1000