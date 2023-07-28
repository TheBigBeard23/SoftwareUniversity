using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventmi.Core.Models
{
    public class EventDetailsModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The {0} must contains between {2} and {1} characters")]
        public string Name { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        public DateTime Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        public DateTime End { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The {0} must contains between {2} and {1} characters")]
        public string Place { get; set; } = null!;
    }
}
