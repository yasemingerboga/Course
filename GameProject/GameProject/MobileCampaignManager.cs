using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class MobileCampaignManager : ICampaignService
    {
        public int Discount()
        {
            return 25;
        }

        public void Message()
        {
            Console.WriteLine("Campaign for mobile applied.");
        }
    }
}
