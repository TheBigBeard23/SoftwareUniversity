namespace Library.Data.Model
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Comment("Categories for the books")]
    public class Category
    {
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; } = new HashSet<Book>();
    }
}