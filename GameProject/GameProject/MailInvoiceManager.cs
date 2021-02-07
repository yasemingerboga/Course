using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class MailInvoiceManager : IInvoiceService
    {
        public void GetInvoice()
        {
            Console.WriteLine("Mail has been sent.");
        }
    }
}
