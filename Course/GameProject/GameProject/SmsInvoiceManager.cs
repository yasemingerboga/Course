using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class SmsInvoiceManager : IInvoiceService
    {
        public void GetInvoice()
        {
            Console.WriteLine("Sms has been sent.");
        }
    }
}
