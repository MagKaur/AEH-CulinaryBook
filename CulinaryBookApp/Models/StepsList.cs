﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CulinaryBookApp.Models
{
    [Table("STEPS_LIST")]
    public class StepsList : DbObject
    {
        [ForeignKey("STEP")] public int Id_Step { get; set; }
        public Step Step { get; set; }

        [Required] public int Step_Number { get; set; }

        [ForeignKey("RECIPE")]
        public int Id_Recipe { get; set; }
        public Recipe Recipe { get; set; }
    }
}