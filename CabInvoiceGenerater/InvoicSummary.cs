using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoicSummary
    {
        public int numOfRides;
        public double totalFare;
        public double averageFare;

        public InvoicSummary(int numOfRides, double totalFare)
        {
            this.numOfRides = numOfRides;
            this.totalFare = totalFare;
            this.averageFare = this.totalFare / this.numOfRides;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is InvoicSummary)) return false;
            InvoicSummary inputObject = (InvoicSummary)obj;
            return this.numOfRides == inputObject.numOfRides && 
                                      this.totalFare == inputObject.totalFare &&
                                      this.averageFare == inputObject.averageFare;
        }
        public override int GetHashCode()
        {
            return this.numOfRides.GetHashCode() ^ this.totalFare.GetHashCode() ^ this.averageFare.GetHashCode();
        }
    }
}
