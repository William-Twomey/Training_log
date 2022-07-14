using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_log.ViewModels
{
    public partial class LiftsVM
    {
        public int Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Weight KG")]
        [Required]
        public double WeightLifted { get; set; }
        [Display(Name = "Repititions")]
        [Required]
        public int Reps { get; set; }
    }
}