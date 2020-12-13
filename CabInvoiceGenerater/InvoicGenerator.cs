using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerater
{
    public class InvoicGenerator
    {
        readonly double MIN_COST_PER_KILOMETER = 10.0;
        readonly int MIN_COST_PER_MINUTE = 1;
        readonly double MIMINUM_FARE = 5;
        double totalFare;
        RideType rideType;

        InvoicSummary invoicSummary = null;
        RideRepository rideRepository = null;

        public InvoicGenerator()
        {
            invoicSummary = new InvoicSummary();
            rideRepository = new RideRepository();
        }
        public InvoicGenerator(RideType rideType)
        {
            this.rideType = rideType;

            if (rideType.Equals(RideType.NORMAL))
            {
                this.MIN_COST_PER_KILOMETER = 10;
                this.MIN_COST_PER_MINUTE = 1;
                this.MIMINUM_FARE = 5;
            }
            else if (rideType.Equals(RideType.PREMIUM))
            {
                this.MIN_COST_PER_KILOMETER = 15;
                this.MIN_COST_PER_MINUTE = 2;
                this.MIMINUM_FARE = 20;
            }
            else
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Ride type is Invalid");
            }
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
