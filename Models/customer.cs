using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cs330215MIS4200_1045_sp20
{
    public class customer
    {
        public int customerID { get; set; }
        public string customerFirstName { get; set; }
        public string customerLastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime customerSince { get; set; }
    }
}