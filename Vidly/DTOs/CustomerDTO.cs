using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{

    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A wild custom error message appears!")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Display(Name = "Date of Birth")] No need for Display attributes
        //[MembershipRequiresLegalAge]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        //We should exclude MembershipType because this is a domain class and this prop creates dependency between DTO and Domain Model
        //We either use primitive types (int,byte...) or we create a custom DTO => MembershipTypeDTO to remove the dependency to Domain Model
        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")] No need for Display attributes
        public byte MembershipTypeId { get; set; }
    }
}