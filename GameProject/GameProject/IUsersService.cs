using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    interface IUsersService
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String BirthYear { get; set; }
        public String IdentityNumber { get; set; }
    }
}
