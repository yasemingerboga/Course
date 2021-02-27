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
        public void Message(string message)
        {
            Console.WriteLine("The sale was made via website.");
            invoice.GetInvoice();
            if (message == "Add")
            {
                campaignService.Add();
            }
            else if (message == "Update")
            {
                campaignService.Update();
            }
            else if (message == "Delete")
            {
                campaignService.Delete();
            }
        }
    }
}
