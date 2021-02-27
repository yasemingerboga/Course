using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class Gamer : IUsersService
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public String BirthYear { get; set; }
        public string IdentityNumber { get; set; }
    }
}
