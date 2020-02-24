using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cs330215MIS4200_1045_sp20.Models
{
    public class Pets
    {
        [Key]
        public int petID { get; set; }
        [Required]
        [Display(Name = "Pet Name")]
        public string petName { get; set; }
        [Required]
        [Display(Name = "Pet Type")]
        public string petType { get; set; }
        [Required]
        [Display(Name = "Pet Breed")]
        public string petBreed { get; set; }
        public ICollection<PetDetails> PetDetails { get; set; }
        
    }
}