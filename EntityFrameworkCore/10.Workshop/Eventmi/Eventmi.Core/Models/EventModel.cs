namespace Eventmi.Core.Models
{

    using System.ComponentModel.DataAnnotations;

    public class EventModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The {0} must contains between {2} and {1} characters")]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required")]
        public DateTime Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required")]
        public DateTime End { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} field is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The {0} must contains between {2} and {1} characters")]
        public string Place { get; set; } = null!;
    }
}
