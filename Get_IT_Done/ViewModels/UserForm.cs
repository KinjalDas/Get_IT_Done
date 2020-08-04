using Get_IT_Done.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_IT_Done.ViewModels
{
    public class UserForm
    {
        public Users Users { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}