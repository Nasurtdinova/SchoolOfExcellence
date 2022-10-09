using SchoolOfExcellence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOfExcellence
{
    public static class CurrentUser
    {
        public static User User { get; set; }
        public static Headmaster Headmaster { get; set; }
        public static Teacher Teacher { get; set; }
    }
}
