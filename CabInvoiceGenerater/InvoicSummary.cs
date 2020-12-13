using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoicSummary
    {

        InvoiceService service;
        public InvoiceService GetInvoice(int noOfRides, double totalFare)
        {
            double averageFare = totalFare / noOfRides;
            service = new InvoiceService(noOfRides, totalFare, averageFare);

            return service;
        }
    }
}
