using Get_IT_Done.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_IT_Done.DTOs
{
    public class UsersDTO
    {
        public Guid Id { get; set; }

        [Required]
        public string UserName { get; set; }

        //[DOBValidator]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }
    }
}