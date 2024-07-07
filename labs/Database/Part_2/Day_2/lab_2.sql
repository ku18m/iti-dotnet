
-- 1) Create a scalar function that takes date and returns Month name of that date.
	create function getMonthName(@date date)
	returns varchar(10)
		begin
			return format(@date, 'MMMM')
		end
	-- Test
	go
	select dbo.getMonthName('12-1-2012')
-- 2) Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
	go
	create function getInBetween(@start int, @end int)
	returns @t table (numbers int)
	as
		begin
			declare @value int = @start
			while (@value < @end - 1)
				begin
					set @value += 1
					insert into @t values (@value)
				end
			return
		end
	-- Test
	go
	select * from getInBetween(10, 20)

-- 3) Create inline function that takes Student No and returns Department Name with Student full name.
	go
	create function getDepartment(@st_num int)
	returns table as
		return (
			select
				'Department Name' = isnull(D.Dept_Name, 'N/A'),
				'Student Full Name' = concat_ws(' ',S.St_Fname, S.St_Lname)
			from
				Student as S
				inner join Department as D
				on S.Dept_Id = D.Dept_Id
			where
				S.St_Id = @st_num
		)
	--Test
	go
	select * from getDepartment(9)

-- 4) Create a scalar function that takes Student ID and returns a message to user.
--	  O - If first name and Last name are null then display 'First name & last name are null'
--	  O - If First name is null then display 'first name is null'
--	  O - If Last name is null then display 'last name is null'
--	  O - Else display 'First name & last name are not null'
	go
	create function getNameStatus(@st_id int)
	returns varchar(50)
		begin
			declare @message varchar(50)
			select @message =
				case
					when St_Fname is null and St_Lname is null
					then 'First name & last name are null'
					when St_Fname is null
					then 'first name is null'
					when St_Lname is null
					then 'last name is null'
					else 'First name & last name are not null'
				end
			from
				Student
			where
				St_Id = @st_id
			return @message
		end
		-- Test
		go
		select dbo.getNameStatus(15)

-- 5) Create inline function that takes integer which represents manager ID
--	  and displays department name, Manager Name and hiring date.
	go
	create function getDepManager(@mng_id int)
	returns table as
		return (
			select
				'Department Name' = D.Dept_Name,
				'Manager Name' = I.Ins_Name,
				'Hiring Date' = D.Manager_hiredate
			from
				Department as D
				inner join Instructor as I
				on D.Dept_Manager = I.Ins_Id
			where
				I.Ins_Id = @mng_id
		)
	--Test
	go
	select * from getDepManager(5)

-- 6) Create multi-statements table-valued function that takes a string.
--    If string='first name' returns student first name.
--    If string='last name' returns student last name.
--    If string='full name' returns Full Name from student table
	go
	create function getStudName(@nameFormat varchar(50))
	returns @t table (Name varchar(50))
		begin
			if (@nameFormat = 'first name')
				insert into @t
				select 'First name' = ISNULL(St_Fname, '') from Student
			else if (@nameFormat = 'last name')
				insert into @t
				select 'Last name' = ISNULL(St_Lname, '') from Student
			else if (@nameFormat = 'full name')
				insert into @t
				select 'Full name' = CONCAT_WS(' ', ISNULL(St_Fname, ''), ISNULL(St_Lname, '')) from Student
			return
		end
	--Test
		go
		select * from getStudName('full name')

-- 7) Write a query that returns the Student No and Student first name without the last char.
	go
	select
		'Student No' = St_Id,
		'First Name' = SUBSTRING(St_Fname, 1, len(St_Fname) - 1)
	from
		Student

-- 8) Write query to delete all grades for the students Located in SD Department.
	go
	delete
		S_C
	from
		Stud_Course as S_C
		inner join Student as S
		on S_C.St_Id = S.St_Id
		inner join Department as D
		on S.Dept_Id = D.Dept_Id
	where
		D.Dept_Name = 'SD'
		
-- 9) Using Merge statement between the following two tables [User ID, Transaction Amount]
	go
	-- Creating test data
	create table Last_Transaction (
		Id int primary key,
		eval int not null
	)
	create table Daily_Transaction (
		Id int primary key,
		eval int not null
	)
	insert into Last_Transaction values (1, 500), (2, 600), (3, 700), (5, 700)
	insert into Daily_Transaction values (1, 7000), (2, 600), (3, 9000), (4, 500)
	-- End of data insertion

	merge into
		Last_Transaction as T
	using 
		Daily_Transaction as S
	on
		T.Id = S.Id
	when matched then
		update
			set T.eval = S.eval
	when not matched then
		Insert values(S.Id, S.eval)
	when not matched by Source then
		delete;

-- 10) Try to Create Login Named(ITIStud) who can access Only student and Course tablesfrom ITI DB,
--     then allow him to select and insert data into tables and deny Delete and update.
	-- Using GUI.


-- 11) Give one Example about Hierarchyid datatype.
		-- Employees Table
		-- The root node represents the manager and it's path is '/' (GetRoot() method).
		-- The second directory is for manager assistants and it's path is '/1' using GetRoot().GetDescendant(null, null) because it's the same path.
		-- The third directory is for department manager '/1/$depmgrNum' using GetDescendant() method of manager assistant id.
		-- The fourth directory is for employees '/1/$depmgrNum/$empNum' using GetDescendant() method of dep Manager id.

		-- 1) Create the Employees Table.
			create table Employee (
				emp_id int primary key identity,
				emp_name varchar(50),
				emp_HID hierarchyid
			);

		-- 2) Insert the manger data
			insert into Employee values('Mohsen', hierarchyid::GetRoot())

		-- 3) Insert the assistant manager data, no need for a function because it's the second path after node.
			insert into Employee values('Adel', hierarchyid::GetRoot().GetDescendant(null, null)), ('Ali', hierarchyid::GetRoot().GetDescendant(null, null))

		-- 4) Insert department mangers data
		--	  Now I need a function to generate a unique hierarchyid for every dep manager.
			go
			create function getNewDepMgrId()
			returns hierarchyid
				begin
					declare @lastDepMgrID hierarchyid;
					declare @newHierarchy hierarchyid;

					select top(1) 
						@lastDepMgrID = emp_HID
					from
						Employee
					where
						emp_HID.GetLevel() = 2 -- Dep Managers Level is 2 => '0/1/2'
					order by
						emp_id DESC;
					
					set @newHierarchy = hierarchyid::GetRoot().GetDescendant(null, null).GetDescendant(@lastDepMgrID, null)
					

					return @newHierarchy;
				end
			go

			-- Test the function with values insertion.
			insert into Employee values('Mona', dbo.getNewDepMgrId())
			go

		-- 5) Insert a new employee, but now I need a function for two reasons based on the data base design
			  -- The first reason is the same as department manager function, is to generate a unique id.
			  -- The second reason is to get his department manager HID maybe based on it's id or based on dep name,
			  -- So it depends on the database design but I'll use the department manager Id in this example.
				create function getNewEmpId(@depMgrId int)
				returns hierarchyid
					begin
						declare @depMgrHID hierarchyid;
						declare @lastEmpHID hierarchyid;
						declare @newHierarchy hierarchyid;

						-- Get the department manager HID.
						select
							@depMgrHID = emp_HID
						from
							Employee
						where
							emp_id = @depMgrId

						-- Get the last employee added HID to generate the next one.
						select top(1) 
							@lastEmpHID = emp_HID
						from
							Employee
						where
							emp_HID.GetAncestor(1) = @depMgrHID			-- Get only the employees that have the same manager
						order by
							emp_id DESC;
					
						set @newHierarchy = @depMgrHID.GetDescendant(@lastEmpHID, null)
					
						return @newHierarchy;
					end
				go

				-- Test the function with values insertion.
				insert into Employee values('Mazen', dbo.getNewEmpId(7)) -- Test with mgr with id 7
				insert into Employee values('Israa', dbo.getNewEmpId(17)) -- Test with mgr with id 17
				insert into Employee values('Ahmed', dbo.getNewEmpId(18)) -- Test with mgr with id 18

			-- Now time to right a queries that show's the power of hierarchyid.

			-- Get the employees who's working under department manager Mona
			-- You can do the same thing with any condition you want
			-- Mona is just an example.
			select
				*
			from
				Employee
			where
				emp_HID.GetAncestor(1) = (select emp_HID from Employee where emp_name = 'Mona')

			-- Get the employee Mazen manager.
			select
				*
			from
				Employee
			where
				emp_HID = (select emp_HID.GetAncestor(1) from Employee where emp_name = 'Mazen')


-- There's a lot of example will be generated based on business, it was a small tutorial of using hierarchyid.