create database ITI_Instructors;


use ITI_Instructors;


create table Instructor (
	-- Columns
	I_id int identity(100, 1) primary key,
	I_Fname varchar(50),
	I_Lname varchar(50),
	I_address varchar(50),
	I_hireDate date default getDate(),
	I_salary int default 3000,
	I_overTime int unique,
	I_bd date,
	I_age as (year(getDate()) - year(I_bd)),
	I_netSalary as (I_salary + I_overTime) persisted,

	-- Constraints
	constraint allowedAddresses check(I_address in ('Cairo', 'Alex')),
	constraint salariesRange check(I_salary between 1000 and 5000),
);


create table Course (
	-- Columns
	C_id int identity(100, 1) primary key,
	C_name varchar(128),
	C_duration int unique
);


create table Lab (
	-- Columns
	L_id int identity(100, 1),
	L_location varchar(128),
	L_capacity int,
	C_id int not null,

	-- Constraints
	constraint labCompositePrimaryKey primary key(L_id, C_id),
	constraint lab_crsRelationship foreign key(C_id) references Course(C_id)
		on update cascade
		on delete cascade,
	constraint maximumCapacity check(L_capacity < 20)
);


create table Instructors_Courses (
	-- Columns
	I_id int not null,
	C_id int not null,

	--Constraints
	constraint ins_crsCompositePrimaryKey primary key(I_id, C_id),
	constraint instMRelationship foreign key(I_id) references Instructor(I_id)
		on update cascade
		on delete cascade,
	constraint crsMRelationship foreign key(C_id) references Course(C_id)
		on update cascade
		on delete cascade,
);