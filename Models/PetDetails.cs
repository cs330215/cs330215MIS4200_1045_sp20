using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cs330215MIS4200_1045_sp20.Models
{
    public class PetDetails
    {
        [Key]
        public int petOwnerID { get; set; }
        [Display(Name = "Owner ID")]
        public int ownerID { get; set; }
        public virtual Owners Owners { get; set; }
        // the next two properties link the petDetail to the Pets
        [Display(Name = "Pet ID")]
        public int petID { get; set; }
        public virtual Pets Pets { get; set; }

    }
}