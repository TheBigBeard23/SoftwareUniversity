namespace _02.FootballBetting.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

public class Player
{
    public Player()
    {
        this.PlayerStatistics = new HashSet<PlayerStatistic>();
    }
    [Key]
    public int PlayerId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.PlayerNameMaxLength)]
    public string Name { get; set; }

    public int SquadNumber { get; set; }

    public bool IsInjured { get; set; }

    [ForeignKey(nameof(Team))]
    public int? TeamId { get; set; }
    public virtual Team Team { get; set; }

    [ForeignKey(nameof(Position))]
    public int PostitionId { get; set; }
    public virtual Position Position { get; set; }

    public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
}

