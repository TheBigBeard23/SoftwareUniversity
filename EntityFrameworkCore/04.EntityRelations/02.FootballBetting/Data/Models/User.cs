namespace _02.FootballBetting.Data.Models;

using Common;
using System.ComponentModel.DataAnnotations;

public class User
{
    public User()
    {
        this.Bets = new HashSet<Bet>();
    }
    [Key]
    public int UserId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserUsernameMaxLength)]
    public string Username { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserPasswordMaxLength)]
    public string Password { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserEmailMaxLength)] 
    public string Email { get; set; }

    [Required]
    [MaxLength(ValidationConstants.UserNameMaxLength)]
    public string Name { get; set; }

    public decimal Balance { get; set; }

    public ICollection<Bet> Bets { get; set; }
}
