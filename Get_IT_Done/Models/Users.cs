﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Get_IT_Done.Models
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        //[Display(Name = "User Name")]
        public string UserName { get; set; }

        //[Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[DOBValidator]
        public DateTime? DateOfBirth { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required]
        //[Display(Name = "Desired Membership Plan")]
        public int MembershipTypeId { get; set; }
    }
}