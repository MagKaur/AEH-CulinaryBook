﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBook.ConsoleApp.Models
{
    [Table("INGREDIENTS_LIST")]
    public class IngredientsList : DbObject
    {
        [ForeignKey("Ingredient")]
        public int Id_Ingredient { get; set; }
        public Ingredient Ingredient { get; set; }
        
        [ForeignKey("Recipe")]
        public int Id_Recipe { get; set; }
        public Recipe Recipe { get; set; }
        
        [Required]
        public decimal Quantity { get; set; }
    }
}