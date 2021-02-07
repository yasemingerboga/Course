using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class MobileSalesManager : ISalesService
    {
        IInvoiceService invoice;
        ICampaignService campaignService;
        public MobileSalesManager(IInvoiceService invoice, ICampaignService campaignService)
        {
            this.invoice = invoice;
            this.campaignService = campaignService;
        }
        public void Message()
        {
            Console.WriteLine("The sale was made via mobile.");
            invoice.GetInvoice();
            campaignService.Message();
        }
    }
}
