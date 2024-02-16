﻿using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Common.EntityValidationConstants.Category;

namespace HouseRentingSystem.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;
        public string Description { get; set; }

    }
}