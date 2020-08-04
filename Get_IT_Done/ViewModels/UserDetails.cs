using Get_IT_Done.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_IT_Done.ViewModels
{
    public class UserDetails
    {
        public Users User { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}