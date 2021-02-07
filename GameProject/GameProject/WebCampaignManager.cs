using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class WebCampaignManager : ICampaignService
    {
        public int Discount()
        {
            return 50;
        }

        public void Message()
        {
            Console.WriteLine("Campaign for website applied.");
        }
    }
}
