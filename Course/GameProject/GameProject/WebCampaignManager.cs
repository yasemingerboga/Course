using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class WebCampaignManager : ICampaignService
    {
        public void Add()
        {
            Console.WriteLine("Campaign for website added.");
        }

        public void Delete()
        {
            Console.WriteLine("Campaign for website deleted.");
        }

        public void Update()
        {
            Console.WriteLine("Campaign for website updated.");
        }
    }
}
