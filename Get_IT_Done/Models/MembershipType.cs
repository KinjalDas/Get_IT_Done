using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Get_IT_Done.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public int Duration { get; set; }
        public int Charges { get; set; }
    }
}