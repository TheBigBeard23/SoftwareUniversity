namespace _02.FootballBetting.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Color
{
    public Color()
    {
        this.PrimaryKitTeams = new HashSet<Team>();
        this.SecondaryKitTeams = new HashSet<Team>();
    }

    [Key]
    public int ColorId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ColorNameMaxLength)]
    public string Name { get; set; }

    [InverseProperty(nameof(Team.PrimaryKitColor))]
    public ICollection<Team> PrimaryKitTeams { get; set; }

    [InverseProperty(nameof(Team.SecondaryKitColor))]
    public ICollection<Team> SecondaryKitTeams { get; set; }


}

