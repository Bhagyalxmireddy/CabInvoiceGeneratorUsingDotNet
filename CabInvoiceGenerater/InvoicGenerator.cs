using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoicGenerator
    {
        public const double MIN_COST_PER_KILOMETER = 10.0;
        public const int MIN_COST_PER_MINUTE = 1;
        public const double MIMINUM_FARE = 5;
        
        public double CalculateFare(double distance, int time)
        {
            double totalFare = distance * MIN_COST_PER_KILOMETER + time * MIN_COST_PER_MINUTE;
            return Math.Max(totalFare, MIMINUM_FARE);
        }
        public double calculateTotalFare(Ride[] rides)
        {
            double totalFare = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
}
