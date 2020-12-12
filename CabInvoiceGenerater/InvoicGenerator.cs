using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoicGenerator
    {
        public const double NORMAL_MIN_COST_PER_KILOMETER = 10.0;
        public const int NORMAL_COST_PER_MINUTE = 1;
        public const double MIMINUM_FARE = 5;
        
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * NORMAL_MIN_COST_PER_KILOMETER + time * NORMAL_COST_PER_MINUTE;
            return Math.Max(totalFare, MIMINUM_FARE);
        }
    }
}
