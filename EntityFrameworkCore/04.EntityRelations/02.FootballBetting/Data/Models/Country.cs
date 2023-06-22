namespace _02.FootballBetting.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;


public class Country
{
    public Country()
    {
        this.Towns = new HashSet<Town>();
    }
    [Key]
    public int CountryId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CountryNameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Town> Towns { get; set; }
}

