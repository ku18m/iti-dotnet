using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ITI_Courses.Models_Old;

public partial class ItiContext : DbContext
{
    public ItiContext()
    {
    }

    public ItiContext(DbContextOptions<ItiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditStudent> AuditStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DailyTransaction> DailyTransactions { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<InsCourse> InsCourses { get; set; }

    public virtual DbSet<InsInSdjava> InsInSdjavas { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<LastTransaction> LastTransactions { get; set; }

    public virtual DbSet<MngrWithTopic> MngrWithTopics { get; set; }

    public virtual DbSet<StudAbv50> StudAbv50s { get; set; }

    public virtual DbSet<StudCourse> StudCourses { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<V1> V1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<AuditStudent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("AuditStudent");

            entity.Property(e => e.Note)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ServerUserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Server User Name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CrsId);

            entity.ToTable("Course");

            entity.Property(e => e.CrsId)
                .ValueGeneratedNever()
                .HasColumnName("Crs_Id");
            entity.Property(e => e.CrsDuration).HasColumnName("Crs_Duration");
            entity.Property(e => e.CrsName)
                .HasMaxLength(50)
                .HasColumnName("Crs_Name");
            entity.Property(e => e.TopId).HasColumnName("Top_Id");

            entity.HasOne(d => d.Top).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TopId)
                .HasConstraintName("FK_Course_Topic");
        });

        modelBuilder.Entity<DailyTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Daily_Tr__3214EC07A48A2F01");

            entity.ToTable("Daily_Transaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Eval).HasColumnName("eval");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId);

            entity.ToTable("Department", tb => tb.HasTrigger("denyUpdate"));

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("Dept_Id");
            entity.Property(e => e.DeptDesc)
                .HasMaxLength(100)
                .HasColumnName("Dept_Desc");
            entity.Property(e => e.DeptLocation)
                .HasMaxLength(50)
                .HasColumnName("Dept_Location");
            entity.Property(e => e.DeptManager).HasColumnName("Dept_Manager");
            entity.Property(e => e.DeptName)
                .HasMaxLength(50)
                .HasColumnName("Dept_Name");
            entity.Property(e => e.ManagerHiredate).HasColumnName("Manager_hiredate");

            entity.HasOne(d => d.DeptManagerNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.DeptManager)
                .HasConstraintName("FK_Department_Instructor");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__1299A8618E6F2E11");

            entity.ToTable("Employee");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emp_name");
        });

        modelBuilder.Entity<InsCourse>(entity =>
        {
            entity.HasKey(e => new { e.InsId, e.CrsId });

            entity.ToTable("Ins_Course");

            entity.Property(e => e.InsId).HasColumnName("Ins_Id");
            entity.Property(e => e.CrsId).HasColumnName("Crs_Id");
            entity.Property(e => e.Evaluation).HasMaxLength(50);

            entity.HasOne(d => d.Crs).WithMany(p => p.InsCourses)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ins_Course_Course");

            entity.HasOne(d => d.Ins).WithMany(p => p.InsCourses)
                .HasForeignKey(d => d.InsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ins_Course_Instructor");
        });

        modelBuilder.Entity<InsInSdjava>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InsInSDJava");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .HasColumnName("Department Name");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(50)
                .HasColumnName("Instructor Name");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.InsId);

            entity.ToTable("Instructor");

            entity.Property(e => e.InsId)
                .ValueGeneratedNever()
                .HasColumnName("Ins_Id");
            entity.Property(e => e.DeptId).HasColumnName("Dept_Id");
            entity.Property(e => e.InsDegree)
                .HasMaxLength(50)
                .HasColumnName("Ins_Degree");
            entity.Property(e => e.InsName)
                .HasMaxLength(50)
                .HasColumnName("Ins_Name");
            entity.Property(e => e.Salary).HasColumnType("money");

            entity.HasOne(d => d.Dept).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Instructor_Department");
        });

        modelBuilder.Entity<LastTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Last_Tra__3214EC07F30FFCA8");

            entity.ToTable("Last_Transaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Eval).HasColumnName("eval");
        });

        modelBuilder.Entity<MngrWithTopic>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("mngrWithTopics");

            entity.Property(e => e.ManagerName)
                .HasMaxLength(50)
                .HasColumnName("Manager Name");
            entity.Property(e => e.TopicName)
                .HasMaxLength(50)
                .HasColumnName("Topic Name");
        });

        modelBuilder.Entity<StudAbv50>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("studAbv50");

            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("Course Name");
            entity.Property(e => e.StudentName)
                .HasMaxLength(61)
                .HasColumnName("Student Name");
        });

        modelBuilder.Entity<StudCourse>(entity =>
        {
            entity.HasKey(e => new { e.CrsId, e.StId });

            entity.ToTable("Stud_Course");

            entity.Property(e => e.CrsId).HasColumnName("Crs_Id");
            entity.Property(e => e.StId).HasColumnName("St_Id");

            entity.HasOne(d => d.Crs).WithMany(p => p.StudCourses)
                .HasForeignKey(d => d.CrsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stud_Course_Course");

            entity.HasOne(d => d.St).WithMany(p => p.StudCourses)
                .HasForeignKey(d => d.StId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stud_Course_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StId);

            entity.ToTable("Student", tb =>
                {
                    tb.HasTrigger("denyDeletion");
                    tb.HasTrigger("insertStudAudit");
                });

            entity.Property(e => e.StId)
                .ValueGeneratedNever()
                .HasColumnName("St_Id");
            entity.Property(e => e.DeptId).HasColumnName("Dept_Id");
            entity.Property(e => e.StAddress)
                .HasMaxLength(100)
                .HasColumnName("St_Address");
            entity.Property(e => e.StAge).HasColumnName("St_Age");
            entity.Property(e => e.StFname)
                .HasMaxLength(50)
                .HasColumnName("St_Fname");
            entity.Property(e => e.StLname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("St_Lname");
            entity.Property(e => e.StSuper).HasColumnName("St_super");

            entity.HasOne(d => d.Dept).WithMany(p => p.Students)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK_Student_Department");

            entity.HasOne(d => d.StSuperNavigation).WithMany(p => p.InverseStSuperNavigation)
                .HasForeignKey(d => d.StSuper)
                .HasConstraintName("FK_Student_Student");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopId);

            entity.ToTable("Topic");

            entity.Property(e => e.TopId)
                .ValueGeneratedNever()
                .HasColumnName("Top_Id");
            entity.Property(e => e.TopName)
                .HasMaxLength(50)
                .HasColumnName("Top_Name");
        });

        modelBuilder.Entity<V1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V1");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("First Name");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Last Name");
            entity.Property(e => e.StudentsSuper).HasColumnName("Students Super");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
