use ITI

select st_fname , dept_name
from Student , Department

select st_fname , dept_name
from Student cross join Department

--Equi        inner
select st_fname , dept_name
from Student , Department
where Department.Dept_Id = Student.Dept_Id

select st_fname , dept_name
from Student , Department
where Department.Dept_Id = Student.Dept_Id and St_Address='alex'

select st_fname , dept_name
from Student S, Department D
where D.Dept_Id = S.Dept_Id 

select *
from Student S, Department D
where D.Dept_Id = S.Dept_Id 

select st_fname, D.*
from Student S, Department D
where D.Dept_Id = S.Dept_Id 

select st_fname , dept_name
from Student S, Department D
where D.Dept_Id = S.Dept_Id and st_age between 20 and 25
order by Dept_Name

select st_fname , dept_name
from Student S inner join Department D
	on D.Dept_Id = S.Dept_Id

select st_fname , dept_name
from Student S inner join Department D
	on D.Dept_Id = S.Dept_Id 

--outer
select st_fname , dept_name
from Student S left outer join Department D
	on D.Dept_Id = S.Dept_Id 

select st_fname , dept_name
from Student S right outer join Department D
	on D.Dept_Id = S.Dept_Id 

select st_fname , dept_name
from Student S full outer join Department D
	on D.Dept_Id = S.Dept_Id 

--self join
Select B.St_Fname as studname , A.St_Fname as supername
from Student A , Student B
where A.St_Id = B.St_super  --(A,PK,Parent,Supervisors),(B,FK,child,students)

Select B.* ,A.*
from Student A , Student B
where A.St_Id = B.St_super 

Select B.St_Fname as studname , A.*
from Student A , Student B
where A.St_Id = B.St_super 

Select distinct A.St_Fname
from Student A , Student B
where A.St_Id = B.St_super 

Select B.St_Fname as studname , A.St_Fname as supername
from Student A right outer join  Student B
on A.St_Id = B.St_super 

---------------------------------
--Join  multi tables
select st_fname , crs_name , grade
from Student S , Stud_Course SC , Course C
where S.St_Id = SC.St_Id and 
	  C.Crs_Id =SC.Crs_Id

select st_fname , crs_name , grade
from Student S inner join Stud_Course SC 
	on S.St_Id = SC.St_Id 
inner join 
Course C
	on C.Crs_Id =SC.Crs_Id

select st_fname , crs_name , grade ,dept_name
from Student S inner join Stud_Course SC 
	on S.St_Id = SC.St_Id 
inner join 
Course C
	on C.Crs_Id =SC.Crs_Id
inner join
Department D
	on d.Dept_Id=s.Dept_Id

--Join  DML
update Stud_Course
	set grade+=10

update Stud_Course
	set grade+=10
where st_id=1

update Stud_Course
	set grade+=10
where st_address='alex'

select grade
from Student s , Stud_Course sc
where s.St_Id = sc.St_Id and st_address='alex'

update Stud_Course
	set grade+=10
from Student s , Stud_Course sc
where s.St_Id = sc.St_Id and st_address='alex'

---------------------------------------------------
select st_fname
from Student

select st_fname
from Student
where st_fname is not null

select isnull(st_fname,'')
from Student

select isnull(st_fname,'stud has no name')
from Student

select isnull(st_fname,st_lname)
from Student

select coalesce(st_fname,st_lname,st_address,'no data')
from Student

delete from Department where Dept_Id=100

update Department	
	set Dept_Id=1
where Dept_Id=200

create table test2
(
 id int Primary key identity, --autoincreament
 ename varchar(20)
)

insert into test2 values('omar')

delete from test2

dbcc check_ident('test2',reseed,0)

select * from test2

create table test3
(
 id int identity, --autoincreament
 ssn int primary key,
 ename varchar(20)
)

insert into test3 values(2222,'ali'),(9999,'eman'),(65432,'omar')

select * from test3
------------------------------------
--like
select *
from Student
where st_fname='ahmed'

select *
from Student
where st_fname like '_a%'
     
_ one char
% zero or more char

'a%h'
'%d_'
'____'
'_m__'
'____%'


'ahm%'
'[ahm]%'   or
'[^ahm]%' not not
'[a-h]%'   range

'[(am)(gh)]%'  --group

'%[%]'      fsdfsdfsdf%
'%[_]%'    ahmed_ali
'[_]%[_]'   _ahmed_

--------------------------
create table depts
(
  did int primary key,
  dname varchar(20)
)

create table emps
(
 eid int identity(1,1),
 ename varchar(20),
 eadd varchar(20) default 'cairo',
 hiredate date default getdate(),
 sal int,
 overtime int,
 netsal as(isnull(sal,0)+isnull(overtime,0)) persisted, --computed+saved
 bd date,
 age as (year(getdate())-year(bd)), --computed
 gender varchar(1),
 hour_rate int not null,
 dnum int ,
 constraint c1 primary key(eid,ename),
 constraint c2 unique(sal),
 constraint c3 unique(overtime),
 constraint c4 check(sal>1000),
 constraint c5 check(overtime between 100 and 500),
 constraint c6 check(eadd in ('alex','mansoura','cairo')),
 constraint c7 check(gender='f' or gender='m'),
 constraint c8 foreign key(dnum) references depts(did)
	on delete set NULL on update cascade
)

alter table emps drop constraint c3



select netsal,age
from emps



select getdate()
select year(getdate())
select month(getdate())


dbcc check_ident('emps',reseed,1)

dbcc check_ident('emps',reseed,5)


--Joins
--DB integrity  constraints


 
