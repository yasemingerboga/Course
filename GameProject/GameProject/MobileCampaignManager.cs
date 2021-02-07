using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class MobileCampaignManager : ICampaignService
    {
        public void Add()
        {
            Console.WriteLine("Campaign for mobile added.");
        }

        public void Delete()
        {
            Console.WriteLine("Campaign for mobile deleted.");
        }

        public void Update()
        {
            Console.WriteLine("Campaign for mobile updated.");
        }
    }
}
