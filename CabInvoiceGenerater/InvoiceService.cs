using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoiceService
    {
        public int numOfRides;
        public double totalFare;
        public double avgFare;

        public InvoiceService(int numOfRides, double totalFare, double avgFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.avgFare = avgFare;
        }
    }
}
