using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float SignUpFee { get; set; }

        public int DurationInMonths { get; set; }

        public int DiscountRate { get; set; }
    }
}