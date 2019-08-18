using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        [Required]
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        //[Min18YearIfAMember] //Check điều kiện cho birthday
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }
    }
}