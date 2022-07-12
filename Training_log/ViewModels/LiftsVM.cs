using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Training_log.ViewModels
{
    public class LiftsVM
    {
        public int Id { get; set; }

        [Display(Name = "Weight")]
        [Required]
        public double WeightLifted { get; set; }
        [Display(Name = "Repititions")]
        [Required]
        public int Reps { get; set; }
    }
}