

using Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

namespace _01.StudentSystem.Data.Models;
public class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [Unicode]
    [MaxLength(ValidationConstants.ResourceNameMaxLength)]
    public string Name { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ResourceUrlMaxLength)]
    public string Url { get; set; }

    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    public Course Course { get; set;}
}

