using System;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IUsersService gamer = new Gamer()
            {
                Name = "Yasemin",
                Surname = "Gerboğa",
                BirthYear = "1999",
                ID = 1,
                IdentityNumber = "11111111111"
            };
            GameManager gameManager = new GameManager(new UserValidationManager());
            gameManager.Add(gamer);
            ISalesService salesService = new MobileSalesManager(new SmsInvoiceManager(),new MobileCampaignManager());
            salesService.Message("Update");
            ISalesService salesService1 = new WebSalesManager(new MailInvoiceManager(),new WebCampaignManager());
            salesService1.Message("Add");
        }
    }
}
