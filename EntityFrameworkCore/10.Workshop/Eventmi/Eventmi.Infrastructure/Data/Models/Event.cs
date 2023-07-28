namespace Eventmi.Infrastructure.Data.Models
{

    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Събития")]
    public class Event
    {
        /// <summary>
        /// Индетификатор на запис
        /// </summary>
        [Key]
        [Comment("Индетификатор на запис")]
        public int Id { get; set; }

        /// <summary>
        /// Име на събитието
        /// </summary>
        [Required]
        [StringLength(50)]
        [Comment("Име на събитието")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Начало на събитието
        /// </summary>
        [Required]
        [Comment("Начало на събитието")]
        public DateTime Start { get; set; }

        /// <summary>
        /// Край на събитието
        /// </summary>
        [Required]
        [Comment("Край на събитието")]
        public DateTime End { get; set; }

        /// <summary>
        /// Място на събитието
        /// </summary>
        [Required]
        [StringLength(100)]
        [Comment("Място на събитието")]
        public string Place { get; set; } = null!;

    }
}
