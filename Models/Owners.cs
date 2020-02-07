using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cs330215MIS4200_1045_sp20.Models
{
    public class Owners
    {
        public int ownerID { get; set; }
        public string ownerFirstName { get; set; }
        [Display(Name = "First Name")]
        public string ownerLastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public ICollection<Pets> Pets { get; set; }
        public string fullName
        {
            get
            {
                return ownerLastName + ", " + ownerFirstName;
            }
        }
    }
}