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
			go

		-- 2) Insert the manger data
			insert into Employee values('Mohsen', hierarchyid::GetRoot())
			go
		-- 3) Insert the assistant manager data, no need for a function because it's the second path after node.
			insert into Employee values('Adel', hierarchyid::GetRoot().GetDescendant(null, null)), ('Ali', hierarchyid::GetRoot().GetDescendant(null, null))
			go
		-- 4) Insert department mangers data
		--	  Now I need a function to generate a unique hierarchyid for every dep manager.
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