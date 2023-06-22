namespace _02.FootballBetting.Data.Models;

using _02.FootballBetting.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Bet
{
    [Key]
    public string BetId { get; set; }

    [Required]
    public decimal Amount { get; set; }

    public Prediction Prediction { get; set; }

    public DateTime DateTime { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(Game))]
    public int GameId { get; set; }
    public virtual Game Game { get; set; } = null!;

}

