using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    interface IGamerService
    {
        public void Add(IUsersService gamer);
        public void Delete(IUsersService gamer);
        public void Update(IUsersService gamer);
    }
}
