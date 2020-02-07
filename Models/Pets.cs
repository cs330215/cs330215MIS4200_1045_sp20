using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace cs330215MIS4200_1045_sp20.Models
{
    public class Pets
    {
        public int petID { get; set; }
        public string petName { get; set; }
        public string petType { get; set; }
        public string petBreed { get; set; }
        public ICollection<Owners> Owners { get; set; }
        
    }
}