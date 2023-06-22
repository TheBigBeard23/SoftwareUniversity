namespace _01.StudentSystem.Data;

using _01.StudentSystem.Data.Models;
using Common;
using Microsoft.EntityFrameworkCore;

internal class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {

    }
    public StudentSystemContext(DbContextOptions options)
        : base(options)
    {

    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Homework> Homework { get; set; } = null!;
    public DbSet<Resource> Resources { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<StudentCourse> StudentCourses { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity
            .HasKey(sc => new { sc.StudentId, sc.CourseId });

            entity
            .HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses);

            entity
            .HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses);

        });
    }
}

