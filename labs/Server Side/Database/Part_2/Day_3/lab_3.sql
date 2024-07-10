
-- Using ITI DB

-- 1) Create a view that displays student full name, course name if the student has a grade more than 50.
	create view studAbv50
	-- with encryption		-- for creating the script.
	as
		select
			'Student Name' = CONCAT_WS(' ', S.St_Fname, S.St_Lname),
			'Course Name' = C.Crs_Name
		from
			Stud_Course as S_C
			inner join Student as S
			on S_C.St_Id = S.St_Id
			inner join Course as C
			on S_C.Crs_Id = C.Crs_Id
		where
			S_C.Grade > 50

		-- Test the view
			select * from studAbv50


-- 2) Create an Encrypted view that displays manager names and the topics they teach.
	create view mngrWithTopics
	-- with encryption		-- for creating the script
	as
		select
			'Manager Name' = I.Ins_Name,
			'Topic Name' = T.Top_Name
		from
			Department as D
			inner join Instructor as I
			on D.Dept_Manager = I.Ins_Id
			inner join Ins_Course as I_C
			on I.Ins_Id = I_C.Ins_Id
			inner join Course as C
			on I_C.Crs_Id = C.Crs_Id
			inner join Topic as T
			on C.Top_Id = T.Top_Id

		-- Test
			select * from mngrWithTopics


-- 3) Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department.
	create view InsInSDJava
	as
		select
			'Instructor Name' = I.Ins_Name,
			'Department Name' = D.Dept_Name
		from
			Instructor as I
			inner join Department as D
			on I.Dept_Id = D.Dept_Id
		where
			D.Dept_Name = 'SD'
			or
			D.Dept_Name = 'Java'

	-- Test
		select * from InsInSDJava


-- 4) Create a view “V1” that displays student data for student who lives in Alex or Cairo.
	  -- Note: Prevent the users to run the following query 
	  -- Update V1 set st_address=’tanta’
	  -- Where st_address=’alex’;
	create view V1
	as
		select
			'ID' = S.St_Id,
			'First Name' = S.St_Fname,
			'Last Name' = S.St_Lname,
			'Address' = S.St_Address,
			'Age' = S.St_Age,
			'Department' = S.Dept_Id,
			'Students Super' = S.St_super
		from
			Student as S
		where
			S.St_Address = 'Cairo'
			or
			S.St_Address = 'Alex'
	with check option

	-- Test
		-- doesn't match the check
		update v1 set Address = 'Tanta' where Address = 'Alex'
		update v1 set Address = 'Tanta' where [First Name] = 'Marwa'
		-- matches the check
		update v1 set Address = 'Alex' where [First Name] = 'Marwa'
		update v1 set Address = 'Cairo' where [First Name] = 'Marwa'

----------------------------------------------------------------------------------------------

-- Using Company DB

-- 5) Create a view that will display the project name and the number of employees work on it.
	create view projectsWNumOfEmp
	as
		select
			'Project Name' = P.Pname,
			'Number of Employees' = COUNT(W.ESSn)
		from
			Works_for as W
			inner join Project as P
			on W.Pno = P.Pnumber
			inner join Employee as E
			on W.ESSn = E.SSN
		group by
			P.Pname
	-- Test
		select * from projectsWNumOfEmp
		go

-- 6) Create the following schema and transfer the following tables to it:
	  -- Company Schema 
			-- Department table (Programmatically)
			-- Project table (by wizard)
	  -- Human Resource Schema
			-- Employee table (Programmatically)
		create schema Company
		go
		create schema [Human Resource]
		go
		
		alter schema Company transfer Departments
		go
		-- Projects table done using wizard

		alter schema [Human Resource] transfer Employee
		go

-- Using ITI DB

-- 7) Create index on column (manager_Hiredate) that allow u to cluster the data in table Department.
	  -- What will happen?

	  create clustered index i1 on Department(Manager_hiredate)
	  go
	  -- When executed gives error
	  -- Msg 1902, Level 16, State 3, Line 140
	  -- Cannot create more than one clustered index on table 'Department'.
	  -- Drop the existing clustered index 'PK_Department' before creating another.

	  -- The table already has a clustered index using its primary key and sorted by it
	  -- You can't create more than clustered index, because you can't sort the DB twice.
	  -- But u can craete up to 999 non clustered indexes
	  -- The clustered index is the main layer for all nonclustered indexes
	  -- The non clustered is sorting it's column only and the other value is a pointer to the main cluster index layer.


-- 8) Create index that allow u to enter unique ages in student table.
	  -- What will happen?
		alter table Student add constraint age_unique unique (St_Age)
		go
	  -- Gives this error
	  -- Msg 1505
	  --The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student'
	  -- and the index name 'age_unique'.
	  -- The duplicate key value is (<NULL>).

	  -- Cannot create the constraint because there's a duplicated values in column St_Age

-- Using Company DB
-- 9) Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 and increases it by 20% if Salary >=3000.
	declare c1 cursor
	for select Salary from [Human Resource].Employee
	for update
	declare @salary int
	open c1
	fetch c1 into @salary
	while @@FETCH_STATUS=0
		begin
			if @salary<3000
				update [Human Resource].Employee
					set Salary = Salary * 1.1
				where current of c1
			else if @salary >= 3000
				update [Human Resource].Employee
					set Salary = Salary * 1.2
				where CURRENT of c1
			fetch c1 into @salary
		end
	close c1
	deallocate c1


-- 10) Display Department name with its manager name using cursor.
	declare c1 cursor
	for select Dnum from [Company].Departments
	for read only
	declare @Dnum int
	declare @Dname varchar(50)
	declare @MgrName varchar(50)
	open c1
	fetch c1 into @Dnum
	while @@FETCH_STATUS=0
		begin
			select @Dname = D.Dname from [Company].Departments as D where D.Dnum = @Dnum
			select
				@MgrName = CONCAT_WS(' ', E.Fname, E.Lname)
			from
				[Company].Departments as D
				inner join [Human Resource].Employee as E
				on D.MGRSSN = E.SSN
				where D.Dnum = @Dnum
			fetch c1 into @Dnum
			select @Dname, @MgrName
		end
	close c1
	deallocate c1


-- Using ITI DB

-- 11) Try to display all instructor names in one cell separated by comma. Using Cursor.
	declare c1 cursor
	for select Ins_Name from Instructor
	for read only
	declare @names varchar(250), @currName varchar(50)
	open c1
	fetch c1 into @currName
	while @@FETCH_STATUS=0
		begin
			set @names = CONCAT_WS(',', @names, @currName)
			fetch c1 into @currName
		end
	select @names
	close c1
	deallocate c1


-- 12) Try to generate script from DB ITI that describes all tables and views in this DB.
	-- script will not be genrated because of views encryption.