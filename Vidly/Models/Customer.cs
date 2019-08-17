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
        [Required(ErrorMessage ="Please enter Customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]
        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Min18YearIfAMember] //Check điều kiện cho birthday
        [DataType(DataType.Date)]
        [Display(Name ="Date of Birth")]
        public DateTime? Birthday { get; set; }
    }
}