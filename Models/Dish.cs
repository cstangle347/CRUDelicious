using System;
using System.ComponentModel.DataAnnotations;

namespace Crud.Models

{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Chef { get; set; }

        [Range(1, 5, ErrorMessage = "Must be between 1 and 5")]  
        public int Tastiness { get; set; }

        [Range(1,int.MaxValue, ErrorMessage = "Must be greater than 0")]
        public int Calories { get; set; }

        [Required]        
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}