using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class GameManager : IGamerService
    {
        UserValidationManager userValidationManager;
        public GameManager(UserValidationManager userValidationManager)
        {
            this.userValidationManager = userValidationManager;
        }
        public void Add(IUsersService gamer)
        {
            if (userValidationManager.Validation(gamer))
            {
                Console.WriteLine(gamer.Name + " Gamer added.");
            }
            else
            {
                Console.WriteLine("Gamer could not added.");
            }

        }
        public void Delete(IUsersService gamer)
        {
            Console.WriteLine(gamer.Name + " Gamer deleted.");
        }
        public void Update(IUsersService gamer)
        {
            Console.WriteLine(gamer.Name + " Gamer updated.");
        }
    }
}
