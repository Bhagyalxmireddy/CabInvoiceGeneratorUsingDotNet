using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabInvoiceGenerater
{
    public class RideRepository
    {
        
        public Dictionary<int, List<Ride>> rideRepository;
        public RideRepository()
        {
            rideRepository = new Dictionary<int, List<Ride>>();
        }

        public void Add(int userId, List<Ride> rideList)
        {
           // List<Ride> ridelist = this.rideRepository.Get(userId);

            if (rideList.Any(e => e == null) || rideList == null)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
            if (rideRepository.ContainsKey(userId))
            {
                rideRepository[userId] = rideList;
            }
            if (rideRepository.ContainsKey(userId) == false)
            {
                rideRepository.Add(userId, rideList);
            }

        }

        public List<Ride> GetRides(int userId)
        {
            try
            {
                return this.rideRepository[userId];
            }
            catch (Exception)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserID");
            }
        }
    }
}

