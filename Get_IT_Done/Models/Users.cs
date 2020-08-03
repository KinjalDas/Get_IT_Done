using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_IT_Done.Models
{
    public class Users
    {
        [Key]
        public Guid UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public MembershipType MembershipType { get; set; }
        public int MembershipTypeId { get; set; }
    }
}