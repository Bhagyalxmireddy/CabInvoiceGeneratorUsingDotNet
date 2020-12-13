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
        double totalFare;

        InvoicSummary invoicSummary = null;
        RideRepository rideRepository = null;

        public InvoicGenerator()
        {
            invoicSummary = new InvoicSummary();
            rideRepository = new RideRepository();
        }
        
        public double CalculateFare(Ride ride)
        {
            if (ride == null)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Ride is Invalid");
            }
            if (ride.distance <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance is Invalid");
            }
            if (ride.time <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time is Invalid");
            }

            double totalFare = ride.distance * MIN_COST_PER_KILOMETER + ride.time * MIN_COST_PER_MINUTE;
            return Math.Max(totalFare, MIMINUM_FARE);
        }

        public double TotalFareForMultipleRides(List<Ride> rides)
        {
            this.totalFare = 0;
            foreach (var ride in rides)
            {
                this.totalFare = totalFare + CalculateFare(ride);
            }
            return this.totalFare;
        }
        public InvoiceService GetInvoiceSummary(List<Ride> rides)
        {
            double fare = TotalFareForMultipleRides(rides);
            InvoiceService data = invoicSummary.GetInvoice(rides.Count, totalFare);
            return data;
        }
        public void AddRides(int userId, List<Ride> rides)
        {
            rideRepository.Add(userId, rides);
        }
        public InvoiceService GetUserInvoice(int userId)
        {
            List<Ride> rides = rideRepository.GetRides(userId);
            InvoiceService data = GetInvoiceSummary(rides);
            return data;
        }
    }
}
