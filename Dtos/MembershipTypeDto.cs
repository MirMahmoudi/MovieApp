using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieApp.Dtos
{
    public class MembershipTypeDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}