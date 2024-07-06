
-- Part 1: Use ITI DB.

-- 1) Retrieve number of students who have a value in their age.
	select
		count(St_Age) as All_Students_with_age
	from
		Student
	where
		St_Age is not null

-- 2) Get all instructors Names without repetition.
	select distinct
		Ins_Name
	from
		Instructor

-- 3) Display student with the following Format (use isNull function)
-- Student ID | Student Full Name | Department name
	select
		St_Id as 'Student ID',
		isNull(St_Fname, '') + ' ' + isNull(St_Lname, '') as 'Student Full Name',
		isNull(D.Dept_Name, 'Not assigned') as 'Department name'
	from
		Student as S
		inner join Department as D
		on S.Dept_Id = D.Dept_Id

-- 4) Display instructor Name and Department Name.
	select
		isNull(I.Ins_Name, 'N/A') as 'Name',
		isNull(D.Dept_Name, 'N/A') as 'Department Name'
	from
		Instructor as I
		left outer join Department as D
		on I.Dept_Id = D.Dept_Id

-- 5) Display student full name and the name of the course he is taking
--    For only courses which have a grade.
	select
		S.St_Fname + ' ' + S.St_Lname as 'Student Name',
		C.Crs_Name as 'Course Name'
	from
		Stud_Course as S_C
		inner join Student as S
		on S_C.St_Id = S.St_Id
		inner join Course as C
		on S_C.Crs_Id = C.Crs_Id
	where
		S_C.Grade is not null

-- 6) Display number of courses for each topic name.
	select
		T.Top_Name as 'Topic Name',
		count(C.Crs_Id) as 'Number of Courses'
	from
		Course as C
		inner join Topic as T
		on C.Top_Id = T.Top_Id
	group by
		T.Top_Name

-- 7) Display max and min salary for instructors.
	select
		max(Salary) as 'Maximum Salary',
		min(Salary) as 'Minimum Salary'
	from
		Instructor

-- 8) Display instructors who have salaries less than the average salary of all instructors.
	select
		*
	from
		Instructor
	where
		Salary < (select avg(Salary) from Instructor)

-- 9) Display the Department name that contains the instructor who receives the minimum salary.
	select -- top(1) Could be used because there's many Instructors recieves the min Salary.
		D.Dept_Name as 'Department That have the lowest salary'
	from
		Instructor as I
		inner join Department as D
		on I.Dept_Id = D.Dept_Id
	where
		I.Salary = (select min(Salary) from Instructor)

-- 10) Select max two salaries in instructor table.
	select distinct top(2) -- Used distinct for repetition.
		Salary
	from
		Instructor
	order by
		Salary desc

-- 11) Select instructor name and his salary but if there is no salary display instructor bonus keyword. “use coalesce Function”
	select
		Ins_Name as 'Name',
		coalesce(cast(Salary as varchar(10)), 'bonus')
	from
		Instructor

-- 12) Select Average Salary for instructors.
	select
		AVG(Salary) as 'Average Salary'
	from
		Instructor

-- 13) Select Student first name and the data of his supervisor.
	select
		S.St_Fname,
		S_Super.*
	from
		Student as S
		inner join
		Student S_Super
		on S.St_super = S_Super.St_Id

-- 14) Write a query to select the highest two salaries in Each Department for instructors who have salaries. “using one of Ranking Functions”
	select
		*
	from (select distinct *, ROW_NUMBER() over (partition by Dept_Id order by Salary desc) as RN
		 from Instructor
		 where Dept_Id is not null and Salary is not null
		) as OrderedT
	where
		OrderedT.RN <= 2

-- 15) Write a query to select a random  student from each department.  “using one of Ranking Functions”
	select
		T.*
	from
		(
			select *, ROW_NUMBER() over (partition by Dept_Id order by newid() desc) as RN
			from Student
			where Dept_Id is not null
		) as T
	where
		T.RN = 1


-- Part 2: Use AdventureWorks DB.

-- 1) Display the SalesOrderID, ShipDate of the SalesOrderHeader table (Sales schema)
--    to show SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’.
	select
		S.SalesOrderID,
		S.ShipDate
	from
		Sales.SalesOrderHeader as S
	where
		S.OrderDate >= '7-28-2002'
		and
		S.OrderDate <= '7-29-2014'
	
-- 2) Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only).
	select
		P.ProductID,
		P.Name
	from
		Production.Product as P
	where
		P.StandardCost < 110

-- 3) Display ProductID, Name if its weight is unknown.
	select
		P.ProductID,
		P.Name
	from
		Production.Product as P
	where
		P.Weight is null

-- 4) Display all Products with a Silver, Black, or Red Color
	select
		*
	from
		Production.Product as P
	where
		P.Color = 'Silver'
		or
		P.Color = 'Black'
		or
		P.Color = 'Red'

-- 5) Display any Product with a Name starting with the letter B
	select
		*
	from
		Production.Product as P
	where
		P.Name like 'B%'

-- 6) Run the following Query
	UPDATE Production.ProductDescription
	SET Description = 'Chromoly steel_High of defects'
	WHERE ProductDescriptionID = 3
-- Then write a query that displays any Product description with underscore value in its description.
	select
		D.*
	from
		Production.ProductDescription as D
	where
		D.Description like '%\_%' escape '\'

-- If it needs the product.
--	select
--		P.*
--	from
--		Production.Product as P
--		inner join Production.ProductModelProductDescriptionCulture as P_M_D
--		on P.ProductModelID = P_M_D.ProductModelID
--		inner join Production.ProductDescription as D
--		on P_M_D.ProductDescriptionID = D.ProductDescriptionID
--	where
--		D.Description like '%\_%' escape '\'

-- 7) Calculate sum of TotalDue for each OrderDate in Sales.SalesOrderHeader table for the period between  '7/1/2001' and '7/31/2014'
	select
		H.OrderDate,
		sum(H.TotalDue) as 'Sum of total due'
	from
		Sales.SalesOrderHeader as H
	where
		H.OrderDate >= '7-1-2001'
		or
		H.OrderDate >= '7-31-2014'
	group by
		H.OrderDate

-- 8) Display the Employees HireDate (note no repeated values are allowed)
	select distinct
		E.HireDate
	from
		HumanResources.Employee as E

-- 9) Calculate the average of the unique ListPrices in the Product table
	select
		AVG(UniqueProductT.ListPrice) as 'AVG of Unique list price'
	from
		(select distinct ListPrice from Production.Product) as UniqueProductT

-- 10) Display the Product Name and its ListPrice within the values of 100 and 120
--	   the list should has the following format "The [product name] is only! [List price]"
--     (the list will be sorted according to its ListPrice value).
	select
		'The ' + P.Name + 'is only! ' + cast(P.ListPrice as varchar(50)) as 'Title'
	from
		Production.Product as P
	where
		P.ListPrice >= 100
		and
		P.ListPrice <= 120
	order by
		P.ListPrice

-- 11) Transfer the rowguid ,Name, SalesPersonID, Demographics from Sales.Store table  in a newly created table named [store_Archive].
	select
		S.rowguid,
		S.Name,
		S.SalesPersonID,
		S.Demographics
	into
		Sales.store_archive
	from
		Sales.Store as S

-- 12) Check your database to see the new table and how many rows in it?
	select
		S.rowguid,
		S.Name,
		S.SalesPersonID,
		S.Demographics
	from
		Sales.store_archive as S

-- 13) Try the previous query but without transferring the data? 
	select
		S.rowguid,
		S.Name,
		S.SalesPersonID,
		S.Demographics
	into
		Sales.empty_store_archive
	from
		Sales.Store as S
	where
		1 = 2 -- Falsy condition.

-- 14) Using union statement, retrieve the today’s date in different styles using convert or format funtion.
	select format(getdate(),'dd-MM-yyyy') as 'Date formats' -- Numeric date format
	union
	select format(getdate(),'dddd MMMM yyyy') -- Full string date format
	union
	select format(getdate(),'ddd MMM yy') -- Minimize the day
	union
	select format(getdate(),'dd-MM-yyyy hh:mm') -- Date with time
	union
	select format(getdate(),'dd-MM-yyyy hh:mm:ss tt') -- Date with full time
	union
	select format(getdate(),'dddd') -- Current full day string
	union
	select format(getdate(),'ddd') -- Current short day string
	union
	select format(getdate(),'MMMM') -- Current full month string
	union
	select format(getdate(),'MMM') -- Current short month string
	union
	select format(getdate(),'hh:mm:ss tt') -- Current time with seconds and zone
	union
	select format(getdate(),'hh:mm:ss') -- Current time with seconds
	union
	select format(getdate(),'HH:mm:ss') -- Current time with seconds
	union
	select format(getdate(),'hh:mm') -- Current time
	union
	select format(getdate(),'hh') -- Current hour
	union
	select format(getdate(),'HH') -- Current hour in 24hrs
