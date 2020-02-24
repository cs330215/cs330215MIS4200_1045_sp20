using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cs330215MIS4200_1045_sp20.Models
{
    public class Owners
    {
        [Key]
        public int ownerID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ownerFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string ownerLastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "Phone")]
        public string phone { get; set; }
        public ICollection<PetDetails> PetDetails { get; set; }
        [Display(Name = "Full Name")]
        public string fullName
        {
            get
            {
                return ownerLastName + ", " + ownerFirstName;
            }
        }
    }
}