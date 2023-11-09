using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Weblab2.Models;

public partial class _8i12LozhkomoevContext : DbContext
{
    public _8i12LozhkomoevContext()
    {
    }

    public _8i12LozhkomoevContext(DbContextOptions<_8i12LozhkomoevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExamForm> ExamForms { get; set; }

    public virtual DbSet<GradeSheet> GradeSheets { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Institute> Institutes { get; set; }

    public virtual DbSet<PaymentForm> PaymentForms { get; set; }

    public virtual DbSet<SemesterSubject> SemesterSubjects { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentInGroup> StudentInGroups { get; set; }

    public virtual DbSet<StudyingForm> StudyingForms { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-KOFUHBU;Database=8I12_Lozhkomoev;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_100_CI_AS");

        modelBuilder.Entity<ExamForm>(entity =>
        {
            entity.HasKey(e => e.ExamFormId).HasName("PK_Формы контроля");

            entity.ToTable("Exam_form");

            entity.Property(e => e.ExamFormId)
                .ValueGeneratedNever()
                .HasColumnName("Exam_form_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GradeSheet>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.GroupId, e.SemesterSubjectId, e.ExamDate }).HasName("PK_Зачетная_ведомость");

            entity.ToTable("Grade_sheet");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.SemesterSubjectId).HasColumnName("Semester_subject_ID");
            entity.Property(e => e.ExamDate)
                .HasColumnType("date")
                .HasColumnName("Exam_date");
            entity.Property(e => e.Letter)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.SemesterSubject).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.SemesterSubjectId)
                .HasConstraintName("FK_Зачетная_ведомость_Дисциплины_в_семестре");

            entity.HasOne(d => d.Student).WithMany(p => p.GradeSheets)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Зачетная_ведомость_Студенты");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK_Группы");

            entity.ToTable("Group");

            entity.Property(e => e.GroupId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Group_ID");
            entity.Property(e => e.InstituteId).HasColumnName("Institute_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.SpecializationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Specialization_ID");
            entity.Property(e => e.StudyingDuration).HasColumnName("Studying_duration");
            entity.Property(e => e.StudyingFormId).HasColumnName("Studying_form_ID");
            entity.Property(e => e.YearOfAdmission).HasColumnName("Year_of_admission");

            entity.HasOne(d => d.Institute).WithMany(p => p.Groups)
                .HasForeignKey(d => d.InstituteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Группы_Институты");

            entity.HasOne(d => d.Specialization).WithMany(p => p.Groups)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Группы_Направления_подготовки");

            entity.HasOne(d => d.StudyingForm).WithMany(p => p.Groups)
                .HasForeignKey(d => d.StudyingFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Группы_Формы_обучения");
        });

        modelBuilder.Entity<Institute>(entity =>
        {
            entity.HasKey(e => e.InstituteId).HasName("PK_Институты");

            entity.ToTable("Institute");

            entity.Property(e => e.InstituteId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Institute_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PaymentForm>(entity =>
        {
            entity.HasKey(e => e.PaymentFormId).HasName("PK_Формы_оплаты");

            entity.ToTable("Payment_form");

            entity.Property(e => e.PaymentFormId)
                .ValueGeneratedNever()
                .HasColumnName("Payment_form_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SemesterSubject>(entity =>
        {
            entity.HasKey(e => e.SemesterSubjectId).HasName("PK_Дисциплины_в_семестре");

            entity.ToTable("Semester_subject");

            entity.Property(e => e.SemesterSubjectId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Semester_subject_ID");
            entity.Property(e => e.ExamFormId).HasColumnName("Exam_form_ID");
            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.HoursPerWeek).HasColumnName("Hours_per_week");
            entity.Property(e => e.LecturerId).HasColumnName("Lecturer_ID");
            entity.Property(e => e.SemesterNumber).HasColumnName("Semester_number");
            entity.Property(e => e.SubjectId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Subject_ID");

            entity.HasOne(d => d.ExamForm).WithMany(p => p.SemesterSubjects)
                .HasForeignKey(d => d.ExamFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Дисциплины_в_семестре_Формы контроля");

            entity.HasOne(d => d.Group).WithMany(p => p.SemesterSubjects)
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Дисциплины_в_семестре_Группы");

            entity.HasOne(d => d.Lecturer).WithMany(p => p.SemesterSubjects)
                .HasForeignKey(d => d.LecturerId)
                .HasConstraintName("FK_Дисциплины_в_семестре_Преподаватели");

            entity.HasOne(d => d.Subject).WithMany(p => p.SemesterSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Дисциплины_в_семестре_Дисциплины");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasKey(e => e.SpecializationId).HasName("PK_Направления_подготовки");

            entity.ToTable("Specialization");

            entity.Property(e => e.SpecializationId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Specialization_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Студенты");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Student_ID");
            entity.Property(e => e.Address)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.EnglishLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("English_level");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_name");
        });

        modelBuilder.Entity<StudentInGroup>(entity =>
        {
            entity.HasKey(e => new { e.StudentId, e.GroupId }).HasName("PK_Студенты_в_группах");

            entity.ToTable("Student_in_group");

            entity.HasIndex(e => e.StudentId, "IX_Студенты_в_группах");

            entity.Property(e => e.StudentId).HasColumnName("Student_ID");
            entity.Property(e => e.GroupId).HasColumnName("Group_ID");
            entity.Property(e => e.PaymentFormId).HasColumnName("Payment_form_ID");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentInGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_Студенты_в_группах_Группы");

            entity.HasOne(d => d.PaymentForm).WithMany(p => p.StudentInGroups)
                .HasForeignKey(d => d.PaymentFormId)
                .HasConstraintName("FK_Студенты_в_группах_Формы_оплаты");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentInGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_Студенты_в_группах_Студенты");
        });

        modelBuilder.Entity<StudyingForm>(entity =>
        {
            entity.HasKey(e => e.StudyingFormId).HasName("PK_Формы_обучения");

            entity.ToTable("Studying_form");

            entity.Property(e => e.StudyingFormId)
                .ValueGeneratedNever()
                .HasColumnName("Studying_form_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK_Дисциплины");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Subject_ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK_Преподаватели");

            entity.ToTable("Teacher");

            entity.Property(e => e.TeacherId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Teacher_ID");
            entity.Property(e => e.AcademicRank)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Academic_rank");
            entity.Property(e => e.FamilyStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Family_status");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_name");
            entity.Property(e => e.InstituteId).HasColumnName("Institute_ID");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Job_title");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Middle_name");

            entity.HasOne(d => d.Institute).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.InstituteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Преподаватели_Институты");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
