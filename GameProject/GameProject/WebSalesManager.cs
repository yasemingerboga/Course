using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class WebSalesManager : ISalesService
    {
        IInvoiceService invoice;
        ICampaignService campaignService;
        public WebSalesManager(IInvoiceService invoice, ICampaignService campaignService)
        {
            this.invoice = invoice;
            this.campaignService = campaignService;
        }
        public void Message()
        {
            Console.WriteLine("The sale was made via website.");
            invoice.GetInvoice();
            campaignService.Message();
        }
    }
}
