using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly_.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Enter customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MemberShipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}