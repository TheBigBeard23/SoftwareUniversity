namespace _02.FootballBetting.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;

public class Position
{
    public Position()
    {
        this.Players = new HashSet<Player>();
    }

    [Key]
    public int PositionId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PositionNameMaxLength)]
    public string Name { get; set; }

    public virtual ICollection<Player> Players { get; set; }
}

