using Get_IT_Done.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Get_IT_Done.ViewModels
{
    public class UserForm
    {
        //public Users Users { get; set; }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DOBValidator]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Desired Membership Plan")]
        public int MembershipTypeId { get; set; }

        public List<MembershipType> MembershipTypes { get; set; }

        public UserForm()
        {
            Id = Guid.Empty;
        }

        public UserForm(Users User)
        {
            Id = User.Id;
            UserName = User.UserName;
            DateOfBirth = User.DateOfBirth;
            MembershipTypeId = User.MembershipTypeId;
        }
    }
}