using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class UserValidationManager : IUserValidationService
    {
        public bool Validation(IUsersService users)
        {
            if (users.Name == "Yasemin" && users.Surname == "Gerboğa" &&
                users.IdentityNumber == "11111111111" && users.ID == 1 && users.BirthYear == "1999")
            {
                return true;
            }
            else return false;
        }
    }
}
