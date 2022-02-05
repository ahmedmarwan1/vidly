using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly_.Models;

namespace Vidly_.DTOS
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter customer's Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTypeId { get; set; }
        public MemberShipTypeDto MembershipType { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}