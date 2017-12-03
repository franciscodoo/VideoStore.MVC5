using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "A wild custom error message appears!")]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Display(Name = "Date of Birth")]
        [MembershipRequiresLegalAge]
        public DateTime? Birthdate { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}