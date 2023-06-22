namespace _01.StudentSystem.Data.Models;

using Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
public class Course
{
    public Course()
    {
        StudentCourses = new HashSet<StudentCourse>();
        Resources = new HashSet<Resource>();
        Homeworks = new HashSet<Homework>();
    }
    [Key]
    public int CourseId { get; set; }

    [Required]
    [Unicode]
    [MaxLength(ValidationConstants.CourseNameMaxLength)]
    public string Name { get; set; }

    [Required]
    [Unicode]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal? Price { get; set; }

    public ICollection<StudentCourse> StudentCourses { get; set; }

    public ICollection<Resource> Resources { get; set; }

    public ICollection<Homework> Homeworks { get; set; }
}


