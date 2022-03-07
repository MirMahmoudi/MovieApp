using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MovieApp.Models;

namespace MovieApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public static readonly int MembershipUnknown = 0;

        public static readonly int MembershipPayAsYouGo = 1;
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        // This Error message will be appeared if the client side validation is not exist or not work
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(250)]
        public string Name { get; set; }
        
        [Required]
        [SubscribedToNewsLetter]
        public bool IsSubscribedNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }

        public string Title
        {
            get { return Id == 0 ? "New Customer" : "Edit Customer"; }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id= customer.Id;
            Name = customer.Name;
            IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }

        public CustomerFormViewModel(CustomerFormViewModel customer)
        {
            Id= customer.Id;
            Name = customer.Name;
            IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
            Birthdate = customer.Birthdate;
        }
    }
}