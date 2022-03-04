using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Birthdate { get; set; }

        public bool IsSubscribedNewsLetter { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }
    }
}