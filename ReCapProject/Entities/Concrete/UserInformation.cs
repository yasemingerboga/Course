using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserInformation : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserCreditCardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FindeksPoint { get; set; }
        public string ImagePath { get; set; }
    }
}
